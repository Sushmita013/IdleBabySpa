using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafeteria : MonoBehaviour
{
    public GameObject defaultChair;

    private void OnEnable()
    {
        Destroy(defaultChair);
    }
}
