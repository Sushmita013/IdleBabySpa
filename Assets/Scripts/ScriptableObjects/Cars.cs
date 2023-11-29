using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class Cars : ScriptableObject
{
    public List<GameObject> carPrefabs;
     
} 