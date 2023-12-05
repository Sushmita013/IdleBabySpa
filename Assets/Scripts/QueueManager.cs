using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;

public class QueueManager : MonoBehaviour
{
    public List<Transform> waitingPositionList; 
    public List<GameObject> guestList;
    //public List<GameObject> itemObject;

    //public Transform spawnPosition; 
    //public List<GameObject> spawnedGuest;

    public Transform destination;

    public float duration;

    public WaitingQueue waitingQueue;

    [Space(20)]
    public Button addGuestBtn;
    public Button moveGuestToDestination;
    //private void Start()
    //{
    //    SpawnGuests();
    //    addGuestBtn.onClick.AddListener(() =>
    //    {
    //        AddGuestToQueue(spawnedGuest[0]);
    //    });
    //    moveGuestToDestination.onClick.AddListener(() =>
    //    {
    //        MoveGuestToDestination();
    //    });

    //}

    //public void SpawnGuests()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        GameObject parentPrefab = itemObject[Random.Range(0, itemObject.Count)]; 
    //        GameObject guest = Instantiate(parentPrefab, spawnPosition.position, parentPrefab.transform.rotation);
    //        spawnedGuest.Add(guest);
    //    }
    //}

    //public bool CanAddGuest()
    //{
    //    return guestList.Count < waitingPositionList.Count;
    //}

    //public void AddGuestToQueue(GameObject guest)
    //{
    //    if (CanAddGuest())
    //    {
    //        guestList.Add(guest);
    //        spawnedGuest.Remove(guest);

    //        NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>(); 
    //        navMeshAgent.SetDestination(waitingPositionList[guestList.IndexOf(guest)].position);

    //        //Animator animator = guest.GetComponent<Animator>();
    //        //if (animator != null)
    //        //{
    //        //    animator.Play("Holding baby and walking");
    //        //}
    //        //guest.transform.DOMove(waitingPositionList[guestList.IndexOf(guest)].position, 4f).OnComplete(() =>
    //        //{
    //        //    animator.Play("Holding baby and standing idle");
    //        //});

    //    }
    //    else
    //    {
    //        Debug.LogError("Queue Is Filled. Please Wait Until the Queue is CLEARED");
    //    }
    //}

    //public GameObject GetFirstInQueue()
    //{
    //    if (waitingQueue.customerInQueue.Count == 0)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        GameObject obj = waitingQueue.customerInQueue[0].gameObject;
    //        waitingQueue.RemoveFromQueue(waitingQueue.customerInQueue[0]);
    //        //waitingQueue.ReOrderQueue();
    //        //RelocateAllTheGuests();
    //        return obj;
    //    }
    //}

    //public void MoveGuestToDestination(Transform destinationPoint)
    //{
    //    GameObject guest = GetFirstInQueue();
    //    if (guest != null)
    //    {
    //        guest.GetComponent<ParentController>().MoveToTarget(destinationPoint);
    //        //NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>();
    //        //navMeshAgent.SetDestination(destinationPoint.position);

    //        //Animator animator = guest.GetComponent<Animator>();
    //        //if (animator != null)
    //        //{
    //        //    animator.Play("Holding baby and walking"); 
    //        //}
    //    }
    //} 

    //public void RelocateAllTheGuests()
    //{
    //    for (int i = 0; i < guestList.Count; i++)
    //    {
    //        GameObject guest = guestList[i];
    //        NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>();

    //        if (navMeshAgent != null)
    //        {

    //            Animator animator = guest.GetComponent<Animator>();
    //            if (animator != null)
    //            {
    //                animator.Play("Holding baby and walking");

    //            }
    //            //navMeshAgent.SetDestination(waitingPositionList[i].position);
    //            guest.transform.DOMove(waitingPositionList[i].position, 1).OnComplete(() =>
    //            {
    //                animator.Play("Holding baby and standing idle");
    //            });

    //        }
    //    }
    //}

}
