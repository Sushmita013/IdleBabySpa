using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailabilityManager : MonoBehaviour
{
    public static AvailabilityManager instance;
        
    public List<RoomManager> rooms;    

    //public WaitingQueue waitingQueue;
    //public WaitingQueue waitingQueue1;
    //public WaitingQueue waitingQueue2;
    //public WaitingQueue waitingQueue3;

    void Start()
    {
        instance = this;
    }

    public RoomManager FindSmallesWaitingQueue(List<RoomManager> rooms)
    {
        RoomManager room = rooms[0];
        for(int i = 1; i < rooms.Count; i++)
        {
            if (room.waiting.queueIndex > rooms[i].waiting.queueIndex)
            {
                room = rooms[i];
            } 
        }
        return room;
    }

    public bool IsRoomAvailable()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if ( !rooms[i].waiting.isFull())
            {
                return true;
            } 
        }
        return false;
    }
    //public WorkerNPC GetAvailableService()
    //{
    //    WorkerNPC availableService = null; 
    //    do
    //    {
    //    int randomVal = Random.Range(0, serviceList.Count);
    //        availableService = serviceList[randomVal]; 

    //    } while (!availableService.isAvailable);  
         
    //    availableService.isAvailable = false;
    //    return availableService;
    //}
    //public WorkerNPC GetAvailableMassageService()
    //{
    //    WorkerNPC availableService = null;

    //    for (int i = 0; i < massageServiceList.Count; i++)
    //    {
    //        if (massageServiceList[i].isAvailable)
    //        { 
    //            availableService = massageServiceList[i];
    //            availableService.isAvailable = false;
    //        break;
    //        } 
    //    }
    //    return availableService; 
    //}
    //public WorkerNPC GetAvailableHaircutService()
    //{
    //    WorkerNPC availableService = null;

    //    for (int i = 0; i < haircutServiceList.Count; i++)
    //    {
    //        if (haircutServiceList[i].isAvailable)
    //        { 
    //            availableService = haircutServiceList[i];
    //            availableService.isAvailable = false;
    //        break;
    //        }
    //        //else
    //        //{
    //        //    Debug.Log("Room is filled");
    //        //    availableService = null; 
    //        //}
    //    }
    //    return availableService; 
    //}
    //public WorkerNPC GetAvailableSwimService()
    //{
    //    WorkerNPC availableService = null;

    //    for (int i = 0; i < swimServiceList.Count; i++)
    //    {
    //        if (swimServiceList[i].isAvailable)
    //        { 
    //            availableService = swimServiceList[i];
    //            availableService.isAvailable = false;
    //        break;
    //        }
    //        //else
    //        //{
    //        //    Debug.Log("Room is filled");
    //        //    availableService = null; 
    //        //}
    //    }
    //    return availableService; 
    //}
    //public WorkerNPC GetAvailablePhotoService()
    //{
    //    WorkerNPC availableService = null;

    //    for (int i = 0; i < photoServiceList.Count; i++)
    //    {
    //        if (photoServiceList[i].isAvailable)
    //        { 
    //            availableService = photoServiceList[i];
    //            availableService.isAvailable = false;
    //        break;
    //        }
    //        //else
    //        //{
    //        //    Debug.Log("Room is filled");
    //        //    availableService = null; 
    //        //}
    //    }
    //    return availableService; 
    //}

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
