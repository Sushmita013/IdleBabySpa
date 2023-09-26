using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CarManager : MonoBehaviour
{
    public List<Cars> carPrefabs;

    private List<GameObject> instantiatedCars = new List<GameObject>();

    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        StartCoroutine(InstantiateRandomCars());
    }

    private IEnumerator InstantiateRandomCars()
    {
        foreach (Cars carData in carPrefabs)
        {
            // Randomly select a prefab from the list
            GameObject carPrefab = carData.carPrefabs[Random.Range(0, carData.carPrefabs.Count)];

            GameObject car = Instantiate(carPrefab, carData.movePoints[0].position, Quaternion.identity);
            GameObject childTransform = car.transform.Find("Father_NPC").gameObject;
            carData.parent = childTransform;
            //foreach (Transform child in car.transform)
            //{
            //    carData.wheels.Add(child);
            //}
            navMeshAgent = car.GetComponent<NavMeshAgent>();
            instantiatedCars.Add(car);

            StartCoroutine(MoveCar(car, carData, navMeshAgent));
            //StartCoroutine(RotateWheels(car, carData));
            yield return new WaitForSeconds(7f);
        }
    }

    private IEnumerator MoveCar(GameObject car, Cars carData, NavMeshAgent agent)
    {

        agent.SetDestination(carData.movePoints[1].position);
        yield return new WaitForSeconds(7);
        agent.SetDestination(carData.movePoints[2].position);
        yield return new WaitForSeconds(3);
        //carData.parent.SetActive(true); 
        //int currentWaypointIndex = 1;

        //car.transform.DOMove(carData.movePoints[currentWaypointIndex].position, 5f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    currentWaypointIndex++;
        //    car.transform.DORotate(new Vector3(0, 90, 0), 0.4f).SetEase(Ease.Linear);
        //});
        //yield return new WaitForSeconds(5.5f);
        //car.transform.DOMove(carData.movePoints[currentWaypointIndex].position, 2f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    currentWaypointIndex++;
        //});
    } 

    //private IEnumerator MoveCar(GameObject car, Cars carData, NavMeshAgent agent)
    //{
    //    int currentWaypointIndex = 1;

    //    while (currentWaypointIndex < carData.movePoints.Count)
    //    {
    //        // Get the next waypoint
    //        Vector3 nextWaypoint = carData.movePoints[currentWaypointIndex].position;

    //        // Move the car using NavMeshAgent
    //        agent.SetDestination(nextWaypoint);

    //        // Wait until the car reaches the waypoint
    //        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
    //        {
    //            yield return null;
    //        }

    //        currentWaypointIndex++;

    //        // Check if the car has reached the last waypoint (parking spot)
    //        if (currentWaypointIndex == carData.movePoints.Count)
    //        {
    //            // Optionally, move the car to the next available parking spot here
    //        }
    //    }
    //}


    private IEnumerator RotateWheels(GameObject car, Cars carData)
    {
        while (true)
        {
            foreach (Transform wheel in carData.wheels)
            {
                wheel.Rotate(Vector3.forward * carData.wheelRotationSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }
}
