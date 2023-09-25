using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DummyCar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(new Vector3(-43, -7.77f, 40));
    }

    // Update is called once per frame
    void Update()
    { 
       
    }
}
