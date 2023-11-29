using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using TMPro;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;
    public List<GameObject> carPrefabs;
    public Transform carParent;
    public Transform exitPoint;

    //public List<GameObject> instantiatedCars = new List<GameObject>(); 
    public List<bool> parkingSlotAvailability = new List<bool>();
    public List<ParkingSlot> parkingSlots;
    public int availableParkingSlots;

    public Advertisement billboard;
    public float carSpawnDuration;
    public TMP_Text spotsText;

    public int unlockedSlotsCount;

    private void Start()
    {
        //carSpawnDuration = 10;
        GetDuration();
        instance = this;
        // Initialize parking slot availability list
        EnableParkingSlot();
        availableParkingSlots = unlockedSlotsCount;
        UpdateSpots(); 
        StartCoroutine(InstantiateRandomCars()); 
    }

    private IEnumerator InstantiateRandomCars()
    { 
        GameObject car = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Count)], carParent.position,carParent.rotation);

        NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
        if (CheckForAvailableSlot())
        { 
        var index=FindNextAvailableParkingSlot();
        agent.SetDestination(parkingSlots[index].destinationPoint.position); 
        parkingSlotAvailability[index] = false; 
        parkingSlots[index].GetComponent<BoxCollider>().enabled = true; 
        }
        else 
        {
            agent.SetDestination(exitPoint.position);
            Destroy(car, 15);
        }
        yield return new WaitForSeconds(GetDuration());
        StartCoroutine(InstantiateRandomCars()); 
        //foreach (Cars carData in carPrefabs)
        //{
        //    GameObject carPrefab = carData.carPrefabs[Random.Range(0, carData.carPrefabs.Count)]; 
        //    GameObject car = Instantiate(carPrefab, carData.movePoints[0].position, Quaternion.identity);
        //    GameObject childTransform = car.transform.Find("SpawnPoint").gameObject;
        //    carData.spawnPoint = childTransform;
        //    NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
        //    //instantiatedCars.Add(car);
        //    agent.SetDestination(carData.movePoints[1].position);
        //    yield return new WaitForSeconds(8f);
        //    StartCoroutine(MoveCar(carData,agent)); 
        //    yield return new WaitForSeconds(GetDuration());
        //    StartCoroutine(InstantiateRandomCars()); 
        //} 

    }

    public bool CheckForAvailableSlot()
    {
        bool isAvailable=false;
        for (int i = 0; i < parkingSlotAvailability.Count; i++)
        {
            if (parkingSlotAvailability[i])
            {
                isAvailable = true;
            }
        }
        return isAvailable;
    }
    //public IEnumerator MoveCar(Cars carData, NavMeshAgent agent)
    //{
    //    int parkingSlotIndex = FindNextAvailableParkingSlot();

    //    if (parkingSlotIndex != -1)
    //    {
    //        availableParkingSlots -= 1;
    //        UpdateSpots();
    //        carData.destinationIndex = parkingSlotIndex;
    //        agent.SetDestination(carData.movePoints[parkingSlotIndex + 2].position);
    //        parkingSlots[parkingSlotIndex].GetComponent<Collider>().enabled = true;
    //        parkingSlotAvailability[parkingSlotIndex] = false; // Mark the parking slot as occupied
    //    }
    //    else
    //    {
    //        Debug.LogError("No available parking slots!");
    //        agent.SetDestination(carData.movePoints[8].position);
    //        yield return new WaitForSeconds(15);
    //        Destroy(agent.gameObject);
    //    }
    //}

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

    public void ExitCar(int index)
    {  
        //UpdateSpots(); 
        parkingSlotAvailability[index] = true; // Mark the parking slot as available
           
    }

    public float GetDuration()
    {
        carSpawnDuration = 60 / billboard.personPerMin;
        return carSpawnDuration;

    }

    public void UpdateSpots()
    {
        spotsText.text = availableParkingSlots.ToString();
    }

    public void EnableParkingSlot()
    {
        for (int i = 0; i < parkingSlots.Count; i++)
        {
            if (i < unlockedSlotsCount)
            {
                parkingSlotAvailability.Add(true); // Initially, all slots are available
            }
            else
            {
                parkingSlotAvailability.Add(false); // Initially, all slots are available 
            }
        }
    }

}

