using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using TMPro;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;
    public List<GameObject> carPrefabs;
    public Transform carParent;
    public Transform exitPoint;

    //public List<GameObject> instantiatedCars = new List<GameObject>(); 
    public List<bool> parkingSlotAvailability = new List<bool>();
    public List<ParkingSlot> parkingSlots;
    public int availableParkingSlots;

    public Advertisement billboard;
    public float carSpawnDuration;
    public TMP_Text spotsText; 
    public int unlockedSlotsCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }
    private void Start()
    {   
        LoadData();
    }

    public IEnumerator InstantiateRandomCars()
    { 
        GameObject car = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Count)], carParent.position,carParent.rotation);

        NavMeshAgent agent = car.GetComponent<NavMeshAgent>();
        if (CheckForAvailableSlot())
        { 
         var index=FindNextAvailableParkingSlot(); 
        agent.SetDestination(parkingSlots[index].destinationPoint.position); 
        parkingSlotAvailability[index] = false; 
        StartCoroutine(EnableCollider(index)); 
            //parkingSlots[index].GetComponent<BoxCollider>().enabled = true; 
        }
        else 
        {
            agent.SetDestination(exitPoint.position);
            Destroy(car, 15);
        }
        yield return new WaitForSeconds(GetDuration());
        StartCoroutine(InstantiateRandomCars());    
    }

    public IEnumerator EnableCollider(int i)
    {
        yield return new WaitForSeconds(10); 
        parkingSlots[i].GetComponent<BoxCollider>().enabled = true;  
    }

    public bool CheckForAvailableSlot()
    {
        bool isAvailable=false;
        for (int i = 0; i < parkingSlotAvailability.Count; i++)
        {
            if (parkingSlotAvailability[i])
            {
                isAvailable = true;
            }
        }
        return isAvailable;
    } 

    private int FindNextAvailableParkingSlot()
    {
        for (int i = 0; i < parkingSlotAvailability.Count; i++)
        {
            if (parkingSlotAvailability[i])
            { 
                return i; // Return the index of the first available parking slot
            }
        }
        return -1; // No available parking slots
    }

    public void ExitCar(int index)
    {  
        //UpdateSpots(); 
        parkingSlotAvailability[index] = true; // Mark the parking slot as available
           
    }

    public float GetDuration()
    {
        carSpawnDuration = 60 / billboard.personPerMin;
        return carSpawnDuration;

    }

    public void UpdateSpots()
    { 
        spotsText.text = availableParkingSlots.ToString();
    }

    public void EnableParkingSlot()
    { 
        for (int i = 0; i < parkingSlots.Count; i++)
        {
            if (i < unlockedSlotsCount)
            {
                parkingSlotAvailability.Add(true); // Initially, all slots are available
            }
            else
            {
                parkingSlotAvailability.Add(false); // Initially, all slots are available 
            }
        }
    }

    public void UnlockSlots()
    {
        for (int i = unlockedSlotsCount-3; i < parkingSlotAvailability.Count; i++)
        {
            if (i < unlockedSlotsCount)
            {
                parkingSlotAvailability[i] = true;
                Debug.Log("marked available");
            }
            else
            {
                parkingSlotAvailability[i] = false;
            }
        }
    } 

    public void LoadData()
    { 
        // Initialize parking slot availability list
        EnableParkingSlot();
        availableParkingSlots = unlockedSlotsCount;
        UpdateSpots(); 
    }

}

