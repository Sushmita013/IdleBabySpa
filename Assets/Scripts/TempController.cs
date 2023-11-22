using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TempController : MonoBehaviour
{
    public GameObject parent;

    public Transform spawnPos;

    public QueueManager queueManager;

    public Transform spawnedParent; 

    public Transform destination;

    public int parentNum;

    void Start()
    {
        StartCoroutine(ParentSpawner()); 
    }
    public IEnumerator InstantiateParent()
    {
        GameObject prefab = Instantiate(parent, spawnPos, spawnedParent);
        queueManager.spawnedGuest.Add(prefab);
        prefab.GetComponent<TempParentBaby>().PlayAnimationParent("walking with baby");
        prefab.GetComponent<TempParentBaby>().PlayAnimationBaby("walking with parent");
        queueManager.AddGuestToQueue(prefab);
        yield return new WaitForSeconds(2);
        if (parentNum <=12)
        { 
        destination=AvailabilityManager.instance.GetAvailableService().destinationPoint;
        }
        else
        {
            destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;

        } 
        queueManager.MoveGuestToDestination(destination);
    }
    public IEnumerator ParentSpawner()
    {
        yield return new WaitForSeconds(5); 
        for (int i = 0; i < 28; i++)
        {
            StartCoroutine(InstantiateParent()); 
            parentNum++;
            yield return new WaitForSeconds(2);
        }
    }
}
