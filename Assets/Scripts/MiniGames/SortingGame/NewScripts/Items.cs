using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int ObjectID;
    public float defaultSize;

    private void Start()
    {
        defaultSize = transform.localScale.x;
    }
}
