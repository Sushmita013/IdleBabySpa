using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class ParkingSlot : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform controllerPoint; 

    public FatherController father;
    public MotherController mother;

    public ParentNPC parent;

    public List<Transform> exitPoints;
    public GameObject destroyPoint;

    public GameObject car;

    public int parkingIndex;


    void Start()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            car = other.gameObject;
            StartCoroutine(RotateCar(other.gameObject));
        }
    }

    public IEnumerator RotateCar(GameObject car)
    { 
        yield return new WaitForSeconds(1);
        car.transform.DORotate(new Vector3(0, 90, 0), 0.25f);
        StartCoroutine(ParentSpawn());
        yield return new WaitForSeconds(2); 
        GetComponent<Collider>().enabled = false;
        //yield return new WaitForSeconds(50f); 
        //destroyPoint.GetComponent<Collider>().enabled = true;  
        //GetComponent<Collider>().enabled = true; 
    }

    public void ExitCar(GameObject car)
    {  
        NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
        agent.angularSpeed = 0;
        agent.SetDestination(exitPoints[0].position);
        if (parkingIndex == 1)
        {
            for (int i = 0; i < CarManager.instance.parkingSlotAvailability.Count; i++)
            {
                //CarManager.instance.parkingSlotAvailability[i] = true;
                CarManager.instance.ExitCar(i);
            }
        }
        StartCoroutine(CarExit(car));
    }

    public IEnumerator CarExit(GameObject car)
    {
        NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
        yield return new WaitForSeconds(3);
        agent.angularSpeed = 120; 
        agent.SetDestination(exitPoints[1].position);
        yield return new WaitForSeconds(3.5f);
        agent.SetDestination(exitPoints[2].position);
        yield return new WaitForSeconds(20);
        Destroy(agent.gameObject);
    }
     

    public IEnumerator ParentSpawn()
    { 
        yield return new WaitForSeconds(0.75f);
        GameObject parentPrefab = parent.parentNpc[Random.Range(0, parent.parentNpc.Count)];
        GameObject parentGO = Instantiate(parentPrefab, spawnPoint.position, Quaternion.identity);
        ParentController parentController = parentGO.GetComponent<ParentController>(); 
        parentGO.SetActive(true);

        parentController.instantiatedParent = parentGO;
        parentController.baby = parentGO.transform.Find("Baby").gameObject;
        parentController.babyController = parentController.baby.GetComponent<Baby>();
        parentController.animator = parentGO.GetComponent<Animator>();
        parentController.navMeshAgent = parentGO.GetComponent<NavMeshAgent>();
        parentController.spawnPoint = destroyPoint.transform;
        parentController.parking = this;   
        parentController.MoveToWalkway();
    }

    //public IEnumerator SpawnParent()
    //{
    //    GameObject parentPrefab = parentController[Random.Range(0, parentController.Count)];
    //    yield return new WaitForSeconds(0.75f);
    //    GameObject parent = Instantiate(parentPrefab, controllerPoint.position, Quaternion.identity);

    //    // Check if the spawned parent GameObject has a FatherController component
    //    FatherController fatherComponent = parent.GetComponent<FatherController>();

    //    // Check if the spawned parent GameObject has a MotherController component
    //    MotherController motherComponent = parent.GetComponent<MotherController>();

    //    if (fatherComponent != null)
    //    {
    //        StartCoroutine(fatherComponent.InstantiateParent(spawnPoint));
    //        fatherComponent.spawnPoint = spawnPoint; 
    //        // The spawned parent GameObject is a FatherController 
    //    }
    //    else if (motherComponent != null)
    //    {
    //        StartCoroutine(motherComponent.InstantiateParent(spawnPoint));
    //        // The spawned parent GameObject is a MotherController 
    //        motherComponent.spawnPoint = spawnPoint;
    //    }
    //    else
    //    {
    //        // The spawned parent GameObject does not have either component
    //        Debug.Log("Spawned parent is not a FatherController or a MotherController");
    //    }
    //} 
}
