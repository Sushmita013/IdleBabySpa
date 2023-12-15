using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    public float force, radius;
    private void Start()
    {
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            Rigidbody rb = rigidbodies[i];
            rb.AddExplosionForce(force, transform.position+Vector3.up*2.5f, radius,2,ForceMode.Impulse);
        }
    }
}
