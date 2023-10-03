using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class ParkingSlot : MonoBehaviour
{
    public GameObject exitPoint;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            StartCoroutine(RotateCar(other.gameObject));
        }
    }

    public IEnumerator RotateCar(GameObject car)
    {
        yield return new WaitForSeconds(1f);
        car.transform.DORotate(new Vector3(0, 90, 0), 0.25f);
        yield return new WaitForSeconds(2);
        car.transform.DORotate(new Vector3(0, 90, 0), 0.25f);

    }
}
