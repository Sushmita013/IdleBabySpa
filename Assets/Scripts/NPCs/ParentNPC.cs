using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParentData", menuName = "ScriptableObjects/ParentInfo", order = 1)]
public class ParentNPC : ScriptableObject
{
    public List<GameObject> parentNpc;
    public List<Transform> movepoints;
    public float moveSpeed = 10f;
    public List<string> anim; 
}

