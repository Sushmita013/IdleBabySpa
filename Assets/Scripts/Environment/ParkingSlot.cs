using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class ParkingSlot : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform controllerPoint;

    public List<GameObject> parentController;

    public FatherController father;
    public MotherController mother;


    void Start()
    {
        parentController.Add(father.gameObject);
        parentController.Add(mother.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            StartCoroutine(RotateCar(other.gameObject));
        }
    }

    public IEnumerator RotateCar(GameObject car)
    { 
        yield return new WaitForSeconds(1);
        car.transform.DORotate(new Vector3(0, 90, 0), 0.25f);
        StartCoroutine(SpawnParent(spawnPoint));
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = false;
    } 

    public IEnumerator SpawnParent(Transform spawn)
    {
        GameObject parentPrefab = parentController[Random.Range(0, parentController.Count)];
        yield return new WaitForSeconds(1f);
        GameObject parent = Instantiate(parentPrefab, controllerPoint.position, Quaternion.identity);

        // Check if the spawned parent GameObject has a FatherController component
        FatherController fatherComponent = parent.GetComponent<FatherController>();

        // Check if the spawned parent GameObject has a MotherController component
        MotherController motherComponent = parent.GetComponent<MotherController>();

        if (fatherComponent != null)
        {
            StartCoroutine(fatherComponent.InstantiateParent(spawnPoint));
            fatherComponent.spawnPoint = spawnPoint; 
            // The spawned parent GameObject is a FatherController 
        }
        else if (motherComponent != null)
        {
            StartCoroutine(motherComponent.InstantiateParent(spawnPoint));
            // The spawned parent GameObject is a MotherController 
            motherComponent.spawnPoint = spawnPoint;
        }
        else
        {
            // The spawned parent GameObject does not have either component
            Debug.Log("Spawned parent is not a FatherController or a MotherController");
        }
    }

}
