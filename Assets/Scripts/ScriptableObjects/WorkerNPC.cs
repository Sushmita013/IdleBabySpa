using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorkerNPC : MonoBehaviour
{
    public int workerIndex;

    public Departments roomName;

    public static WorkerNPC instance;

    public RoomManager room;

    private Animator animator;

    public GameObject occupiedUI;
    public Image fillbar;
    public ParticleSystem effect;

    public bool isOccupied;
    public string animName;

    public float duration;

    void Start()
    {
        duration = 4;
        instance = this; 
        effect.Stop(); 
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParentNPC")
        {
            room.customersServed++;
            other.GetComponent<ParentController>().totalBill += room.serviceCost;
            StartCoroutine(Action());
        }
    }
    public IEnumerator Action()
    {
        yield return new WaitForSeconds(2.5f); 
        occupiedUI.SetActive(true);
        fillbar.DOFillAmount(1, duration);
        PlayAnimation(animName);
        yield return new WaitForSeconds(duration);
        effect.Play();
        occupiedUI.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        PlayAnimation("Idle");
    }
    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }
}
