using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class WorkerNPC : MonoBehaviour
{
    public bool isUnlocked;
    public bool isAvailable;

    public Transform destinationPoint;

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

    public GameObject billAmount;

    public TMP_Text amountText; 

    public ParticleSystem effectObject;


    void Start()
    { 
        GetDuration(); 
        effect.Stop();  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParentNPC")
        { 
            if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.GiveService)
            {
                TaskManager.GiveServiceAction?.Invoke(1);
            }
            room.customersServed++;  
            StartCoroutine(Action());
        }
    } 
    public IEnumerator Action()
    {
        yield return new WaitForSeconds(1f); 
        occupiedUI.SetActive(true);
        fillbar.DOFillAmount(1, GetDuration());
        PlayAnimation(animName);
        if (roomName != Departments.Massage || roomName != Departments.Cafeteria)
        { 
        effectObject.Play();
        }
        yield return new WaitForSeconds(GetDuration());
        if (roomName != Departments.Massage || roomName != Departments.Cafeteria)
        { 
        effectObject.Stop();
        }
        effect.Play();
        amountText.text = "+" + room.serviceCost.ToString();
        billAmount.SetActive(true);
        billAmount.transform.DOLocalMoveZ(-4, 1.5f); 
        //billAmount.GetComponent<RectTransform>().DOAnchorPosZ( -6, 1f);
        PlayAnimation("Idle");
        GameManager.instance.totalSoftCurrency += room.serviceCost;
        CanvasManager.instance.UpdateSoftCurrency();
        occupiedUI.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        yield return new WaitForSeconds(1.5f);
        billAmount.SetActive(false); 
        billAmount.transform.DOLocalMoveZ(0, 0.1f);
        //billAmount.GetComponent<RectTransform>().DOAnchorPos(new Vector3(25, -34, -3), 1f);
        SaveManager.instance.SaveDataCall(); 
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
