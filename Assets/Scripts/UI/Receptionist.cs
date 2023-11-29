using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Receptionist : MonoBehaviour
{
    public int workerIndex;  

    public Reception room;

    private Animator animator;

    public GameObject occupiedUI;
    public Image fillbar;
    public ParticleSystem effect;

    public bool isOccupied;
    public string animName;

    public float duration;
    public ParentController parent;
    //public GameObject billUI;

    //public TMP_Text billAmount;


    void Start()
    {
        GetDuration();
        effect.Stop();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ParentNPC")
        {  
            StartCoroutine(Action());
            parent = other.GetComponent<ParentController>();
        }
    }
    public IEnumerator Action()
    {   
        occupiedUI.SetActive(true);
        fillbar.DOFillAmount(1, GetDuration());
        PlayAnimation(animName);
        yield return new WaitForSeconds(GetDuration());
        parent.MoveToNextDestination(parent.parent); 
        effect.Play();
        occupiedUI.SetActive(false);
        PlayAnimation("Idle");  
        fillbar.DOFillAmount(0, 0.1f);
    }
    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }

    public float GetDuration()
    {
        duration = 60/(room.cashierList[workerIndex - 1].cashierSpeed);
        return duration;
    }
}
