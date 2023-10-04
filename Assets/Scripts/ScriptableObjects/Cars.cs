using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class Cars : ScriptableObject
{
    public List<GameObject> carPrefabs;
    public List<Transform> movePoints;
    public List<Transform> exitPoints;
    //public List<Transform> wheels;
    //public float moveSpeed = 5.0f;
    //public float wheelRotationSpeed = 100.0f;
    public GameObject spawnPoint;

    public int destinationIndex;
} 