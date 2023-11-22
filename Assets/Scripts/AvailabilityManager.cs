using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailabilityManager : MonoBehaviour
{
    public static AvailabilityManager instance;
    public List<Service> serviceList; 
    public List<QueueSlot> queueList; 
    void Start()
    {
        instance = this;
    }

    public Service GetAvailableService()
    {
        Service availableService = null;

        for (int i = 0; i < serviceList.Count; i++)
        {
            if (serviceList[i].isAvailable)
            { 
                availableService = serviceList[i];
            break;
            }
            else
            {
                Debug.Log("Room is filled");
            }   
        }
        availableService.isAvailable = false;
        return availableService; 
    } 

    public QueueSlot GetAvailableQueueSlot()
    {
        QueueSlot availableSlot = null;
        for (int i = 0; i < queueList.Count; i++)
        {
            if (queueList[i].isAvailable)
            {
                availableSlot = queueList[i];
                break;
            }
            else
            {
                Debug.Log("Queues are filled");
            }
        }
        availableSlot.isAvailable = false;
        return availableSlot;
    }
}
