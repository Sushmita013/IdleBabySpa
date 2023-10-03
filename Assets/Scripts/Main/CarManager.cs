//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//using DG.Tweening;

//public class CarManager : MonoBehaviour
//{
//    public static CarManager instance;
//    public List<Cars> carPrefabs;

//    private List<GameObject> instantiatedCars = new List<GameObject>();

//    public NavMeshAgent navMeshAgent;

//    public GameObject father;
//    public GameObject mother; 

//    private void Start()
//    {
//        instance = this;
//        StartCoroutine(InstantiateRandomCars());
//    }

//    private IEnumerator InstantiateRandomCars()
//    {
//        foreach (Cars carData in carPrefabs)
//        {
//            // Randomly select a prefab from the list
//            GameObject carPrefab = carData.carPrefabs[Random.Range(0, carData.carPrefabs.Count)];

//            GameObject car = Instantiate(carPrefab, carData.movePoints[0].position, Quaternion.identity);
//            GameObject childTransform = car.transform.Find("Father_NPC").gameObject;
//            carData.parent = childTransform;
//            //foreach (Transform child in car.transform)
//            //{
//            //    carData.wheels.Add(child);
//            //}
//            navMeshAgent = car.GetComponent<NavMeshAgent>();
//            instantiatedCars.Add(car);

//            StartCoroutine(MoveCar(car, carData, navMeshAgent));
//            //StartCoroutine(RotateWheels(car, carData));
//            yield return new WaitForSeconds(10f); 
//        }
//    } 

//    private IEnumerator MoveCar(GameObject car, Cars carData, NavMeshAgent agent)
//    {

//        agent.SetDestination(carData.movePoints[1].position);
//        yield return new WaitForSeconds(7);
//        agent.SetDestination(carData.movePoints[2].position);
//        yield return new WaitForSeconds(4);
//        //father.SetActive(true);
//        yield return new WaitForSeconds(110f);
//        //father.SetActive(false); 
//        StartCoroutine(ExitCar(car, carData, navMeshAgent));  
//    }
//    private IEnumerator ExitCar(GameObject car, Cars carData, NavMeshAgent agent)
//    {
//        Debug.Log("exit");
//        agent.SetDestination(carData.movePoints[3].position);
//        yield return new WaitForSeconds(6);
//        agent.SetDestination(carData.movePoints[4].position);  
//        yield return null;  
//    }  
//    private IEnumerator RotateWheels(GameObject car, Cars carData)
//    {
//        while (true)
//        {
//            foreach (Transform wheel in carData.wheels)
//            {
//                wheel.Rotate(Vector3.forward * carData.wheelRotationSpeed * Time.deltaTime);
//            }
//            yield return null;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;
    public List<Cars> carPrefabs;
    public List<GameObject> instantiatedCars = new List<GameObject>();
    public int totalCarSpaces;
    public List<bool> parkingSlotAvailability = new List<bool>();

    private void Start()
    {
        instance = this;
        // Initialize parking slot availability list
        for (int i = 0; i < totalCarSpaces; i++)
        {
            parkingSlotAvailability.Add(true); // Initially, all slots are available
        }
        StartCoroutine(InstantiateRandomCars());
    }  

    private IEnumerator InstantiateRandomCars()
    {
        foreach (Cars carData in carPrefabs)
        {
            GameObject carPrefab = carData.carPrefabs[Random.Range(0, carData.carPrefabs.Count)];
            GameObject car = Instantiate(carPrefab, carData.movePoints[0].position, Quaternion.identity);
            //GameObject childTransform = car.transform.Find("Father_NPC").gameObject;
            //carData.parent = childTransform;
            NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
            instantiatedCars.Add(car);
            agent.SetDestination(carData.movePoints[1].position);
            yield return new WaitForSeconds(8f);
            StartCoroutine(MoveCar(carData,agent));
            yield return new WaitForSeconds(3f);
            StartCoroutine(InstantiateRandomCars()); 
        }
    }

    public IEnumerator MoveCar(Cars carData, NavMeshAgent agent)
    {
        int parkingSlotIndex = FindNextAvailableParkingSlot();
        if (parkingSlotIndex != -1)
        {
            carData.destinationIndex = parkingSlotIndex;
            agent.SetDestination(carData.movePoints[parkingSlotIndex + 2].position);
            parkingSlotAvailability[parkingSlotIndex] = false; // Mark the parking slot as occupied
        }
        else
        {
            Debug.LogError("No available parking slots!");
        }
        yield return new WaitForSeconds(20f);
        //StartCoroutine(ExitCar(carData, agent));
    }

    private int FindNextAvailableParkingSlot()
    {
        for (int i = 0; i < parkingSlotAvailability.Count; i++)
        {
            if (parkingSlotAvailability[i])
            {
                return i; // Return the index of the first available parking slot
            }
        }
        return -1; // No available parking slots
    }

    public IEnumerator ExitCar( Cars carData, NavMeshAgent agent)
    {
        Debug.Log("exit");
        agent.SetDestination(carData.exitPoints[0].position);
        yield return new WaitForSeconds(6);
        agent.SetDestination(carData.exitPoints[1].position);
        yield return null; 
        parkingSlotAvailability[carData.destinationIndex] = true; // Mark the parking slot as available
    }
     
}

