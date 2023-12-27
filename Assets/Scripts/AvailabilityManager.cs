using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailabilityManager : MonoBehaviour
{
    public static AvailabilityManager instance;
        
    public List<RoomManager> rooms; 

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
}
