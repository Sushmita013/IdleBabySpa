using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailabilityManager : MonoBehaviour
{
    public static AvailabilityManager instance;
    public List<Service> serviceList; 
    public List<Service> massageServiceList; 
    public List<Service> haircutServiceList; 
    public List<Service> swimServiceList; 
    public List<Service> photoServiceList;      
    public List<QueueSlot> massageQueueList; 
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
            //else
            //{
            //    Debug.Log("Room is filled");
            //    availableService = null;
            //}
        }
        availableService.isAvailable = false;
        return availableService;
    }
    public Service GetAvailableMassageService()
    {
        Service availableService = null;

        for (int i = 0; i < massageServiceList.Count; i++)
        {
            if (massageServiceList[i].isAvailable)
            { 
                availableService = massageServiceList[i];
                availableService.isAvailable = false;
            break;
            } 
        }
        return availableService; 
    }
    public Service GetAvailableHaircutService()
    {
        Service availableService = null;

        for (int i = 0; i < haircutServiceList.Count; i++)
        {
            if (haircutServiceList[i].isAvailable)
            { 
                availableService = haircutServiceList[i];
                availableService.isAvailable = false;
            break;
            }
            //else
            //{
            //    Debug.Log("Room is filled");
            //    availableService = null; 
            //}
        }
        return availableService; 
    }
    public Service GetAvailableSwimService()
    {
        Service availableService = null;

        for (int i = 0; i < swimServiceList.Count; i++)
        {
            if (swimServiceList[i].isAvailable)
            { 
                availableService = swimServiceList[i];
                availableService.isAvailable = false;
            break;
            }
            //else
            //{
            //    Debug.Log("Room is filled");
            //    availableService = null; 
            //}
        }
        return availableService; 
    }
    public Service GetAvailablePhotoService()
    {
        Service availableService = null;

        for (int i = 0; i < photoServiceList.Count; i++)
        {
            if (photoServiceList[i].isAvailable)
            { 
                availableService = photoServiceList[i];
                availableService.isAvailable = false;
            break;
            }
            //else
            //{
            //    Debug.Log("Room is filled");
            //    availableService = null; 
            //}
        }
        return availableService; 
    }

    //public QueueSlot GetAvailableQueueSlot()
    //{
    //    QueueSlot availableSlot = null;
    //    for (int i = 0; i < queueList.Count; i++)
    //    {
    //        if (queueList[i].isAvailable)
    //        {
    //            availableSlot = queueList[i];
    //            availableSlot.isAvailable = false;
    //            break;
    //        }
    //        else
    //        {
    //            Debug.Log("Queues are filled");
    //            availableSlot = null;
    //        }
    //    }
    //    return availableSlot;
    //}
}
