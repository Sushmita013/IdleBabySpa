using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{ 

    void Start()
    {
        Camera.main.transform.position = new Vector3(-100, 60, -32);
        Camera.main.orthographicSize = 25;
    }

     
}
