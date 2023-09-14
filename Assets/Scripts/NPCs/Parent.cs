using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Parent : MonoBehaviour
{
    public Animation anim;

    public bool isEngaged;

    public bool isWaiting;

    public bool isWalking; 

    public float serviceDuration;

    private Animator animator;

    public List<Transform> movepoints;

    void Start()
    {
        
    } 

    public void Movement()
    {
        //if-----
        PlayAnimation("ANim1");
        //else
        PlayAnimation("Anim2");
    }

    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }
}
