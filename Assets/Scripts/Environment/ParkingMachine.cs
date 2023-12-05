using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParkingMachine : MonoBehaviour
{
    public GameObject pole;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            pole.transform.DOLocalRotate(new Vector3(0, 0, -90), 1f);
            //CarManager.instance.parkingSlots[CarManager.instance.index-1].GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            pole.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
        }
    }
}
