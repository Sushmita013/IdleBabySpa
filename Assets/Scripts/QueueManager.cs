using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;

public class QueueManager : MonoBehaviour
{
    public List<Transform> waitingPositionList;
    public Transform entrancePosition;
    public List<GameObject> guestList;
    public List<GameObject> itemObject;

    public Transform spawnPosition; 
    public List<GameObject> spawnedGuest;

    public Transform destination;

    [Space(20)]
    public Button addGuestBtn;
    public Button moveGuestToDestination;
    private void Start()
    {
        SpawnGuests();
        addGuestBtn.onClick.AddListener(() =>
        {
            AddGuestToQueue(spawnedGuest[0]);
        });
        moveGuestToDestination.onClick.AddListener(() =>
        {
            MoveGuestToDestination();
        });

    }

    public void SpawnGuests()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject parentPrefab = itemObject[Random.Range(0, itemObject.Count)]; 
            GameObject guest = Instantiate(parentPrefab, spawnPosition.position, parentPrefab.transform.rotation);
            spawnedGuest.Add(guest);
        }
    }

    public bool CanAddGuest()
    {
        return guestList.Count < waitingPositionList.Count;
    }

    public void AddGuestToQueue(GameObject guest)
    {
        if (CanAddGuest())
        {
            guestList.Add(guest);
            spawnedGuest.Remove(guest);

            NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>();
            navMeshAgent.Warp(entrancePosition.position); // Teleport to the entrance
            //navMeshAgent.SetDestination(waitingPositionList[guestList.IndexOf(guest)].position);

            Animator animator = guest.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Holding baby and walking");
            }
            guest.transform.DOMove(waitingPositionList[guestList.IndexOf(guest)].position, 4f).OnComplete(() =>
            {
                animator.Play("Holding baby and standing idle");
            });

        }
        else
        {
            Debug.LogError("Queue Is Filled. Please Wait Until the Queue is CLEARED");
        }
    }

    public GameObject GetFirstInQueue()
    {
        if (guestList.Count == 0)
        {
            return null;
        }
        else
        {
            GameObject obj = guestList[0];
            guestList.RemoveAt(0);
            RelocateAllTheGuests();
            return obj;
        }
    }

    public void MoveGuestToDestination()
    {
        GameObject guest = GetFirstInQueue();
        if (guest != null)
        {
            NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>();
            navMeshAgent.SetDestination(destination.position);

            Animator animator = guest.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Holding baby and walking"); 
            }
        }
    }

    public void RelocateAllTheGuests()
    {
        for (int i = 0; i < guestList.Count; i++)
        {
            GameObject guest = guestList[i];
            NavMeshAgent navMeshAgent = guest.GetComponent<NavMeshAgent>();

            if (navMeshAgent != null)
            {

                Animator animator = guest.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.Play("Holding baby and walking");

                }
                //navMeshAgent.SetDestination(waitingPositionList[i].position);
                guest.transform.DOMove(waitingPositionList[i].position, 1).OnComplete(() =>
                {
                    animator.Play("Holding baby and standing idle");
                });

            }
        }
    }

}
