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
            pole.transform.DORotate(new Vector3(0, -90, -90), 1f); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
        {
            pole.transform.DORotate(new Vector3(0, -90, 0), 1f);
        }
    }
}
