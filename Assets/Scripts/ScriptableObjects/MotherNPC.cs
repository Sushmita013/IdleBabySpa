using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MotherData", menuName = "ScriptableObjects/MotherInfo", order = 1)]
public class MotherNPC : ScriptableObject
{
    public GameObject motherNpc;
    public List<Transform> movepoints;
    public float moveSpeed = 5f;
    //public Animator animator;
    public List<string> anim; 
}
