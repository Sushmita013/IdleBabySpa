using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCollision : MonoBehaviour
{
    private ParkingSlot parking;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyPoint")
        {
            parking = other.GetComponentInParent<ParkingSlot>();
            gameObject.SetActive(false);  
        }
    }

    private void OnDisable()
    { 
         parking.ExitCar(parking.car);
        parking.destroyPoint.GetComponent<Collider>().enabled = false;
    }


}
