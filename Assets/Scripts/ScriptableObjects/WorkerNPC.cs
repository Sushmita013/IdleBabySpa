using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorkerNPC : MonoBehaviour
{
    public int workerIndex;

    public Departments roomName;
     

    public RoomManager room;

    [SerializeField] Animator animator;

    public GameObject occupiedUI;
    public Image fillbar;
    public ParticleSystem effect;

    public bool isOccupied;
    public string animName;

    public float duration;

    public Transform chairPoint; 
    public int parentRotation;

    public ParticleSystem effectObject;


    void Start()
    {
        //duration = 4;
        GetDuration(); 
        effect.Stop();
        //animator = GetComponent<Animator>();
        //effectObject.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParentNPC")
        {
            room.customersServed++;
            //other.GetComponent<ParentController>().totalBill += room.serviceCost; 
            StartCoroutine(Action());
        }
    } 
    public IEnumerator Action()
    {
        yield return new WaitForSeconds(4.5f); 
        occupiedUI.SetActive(true);
        fillbar.DOFillAmount(1, GetDuration());
        PlayAnimation(animName);
        if (roomName != Departments.Massage)
        { 
        effectObject.Play();
        }
        yield return new WaitForSeconds(GetDuration());
        if (roomName != Departments.Massage)
        { 
        effectObject.Stop();
        }
        effect.Play();
        PlayAnimation("Idle");
        GameManager.instance.totalSoftCurrency += room.serviceCost;
        CanvasManager.instance.UpdateSoftCurrency();
        occupiedUI.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
    }
    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }

    public float GetDuration()
    {
        duration = 60 / (room.worker.workerSpeed);
        return duration;
    }
}
