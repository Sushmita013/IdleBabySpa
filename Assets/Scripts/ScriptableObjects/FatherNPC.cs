using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FatherData", menuName = "ScriptableObjects/FatherInfo", order = 1)]
public class FatherNPC : ScriptableObject
{
    public GameObject fatherNpc;
    public List<Transform> movepoints;
    public float moveSpeed = 5f; 
    public List<string> anim;
    //public GameObject babyNPC;
}
     
