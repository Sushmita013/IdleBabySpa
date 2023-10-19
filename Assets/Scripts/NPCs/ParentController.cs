using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class ParentController : MonoBehaviour
{
    public ParentNPC parent;
    internal NavMeshAgent navMeshAgent;
    internal GameObject instantiatedParent;
    internal GameObject baby;
    internal Animator animator;
    internal Baby babyController;
    public float time;
    internal ParkingSlot parking;
    internal Transform spawnPoint;

    private float duration;
    private float duration1;

    public float totalBill;  

    void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void MoveToWalkway()
    {
        PlayAnimation(parent.anim[0]);
        navMeshAgent.SetDestination(parent.movepoints[0].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "ParkingWalkway")
        { 
            StartCoroutine(MoveToMassage(parent, navMeshAgent));
        }
        if(other.tag=="MassageTable")
        {
            duration = other.GetComponent<WorkerNPC>().duration;
            StartCoroutine(GetMassage(parent, navMeshAgent));
        }
        if(other.tag=="HaircutChair")
        {
            StartCoroutine(GetHaircut(parent, navMeshAgent)); 
        }
        if(other.tag=="Cashier")
        {
            duration1 = other.GetComponent<Billing>().duration;
            StartCoroutine(MakePaymentToCashier(instantiatedParent,parent,navMeshAgent)); 
        }
        if (other.tag == "DestroyPoint")
        {
            parking = other.GetComponentInParent<ParkingSlot>();
            parking.ExitCar(parking.car);
            Destroy(gameObject, 0.1f);
            //gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        parking.ExitCar(parking.car);
        //parking.destroyPoint.GetComponent<Collider>().enabled = false;
    }

    public IEnumerator MoveToMassage(ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("MoveToMassage");
        //animator = instantiatedParents[0].GetComponent<Animator>();
        yield return null;
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(parentData.movepoints[1].position);
        yield return new WaitForSeconds(16.5f);
        agent.SetDestination(parentData.movepoints[2].position); 
    }

    public IEnumerator GetMassage(ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("GetMassage");
        yield return new WaitForSeconds(0.5f); 
        PlayAnimation(parentData.anim[1]);
        StartCoroutine(babyController.Massage()); 
        yield return new WaitForSeconds(2);
        //StartCoroutine(Masseuse.instance.Action());
        PlayAnimation(parentData.anim[2]); 
        yield return new WaitForSeconds(duration);
        PlayAnimation(parentData.anim[3]);
        StartCoroutine(babyController.MassageComplete()); 
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(MoveToHaircut(parent, navMeshAgent));
        }
        else
        { 
            StartCoroutine(MoveToCashier( parent, navMeshAgent));
        }
    }
    public IEnumerator GetHaircut(ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("GetHaircut");

        PlayAnimation(parentData.anim[4]);
        StartCoroutine(babyController.Haircut());
        yield return new WaitForSeconds(2);
        StartCoroutine(Masseuse.instance.Action3()); 
        PlayAnimation(parentData.anim[2]); 
        yield return new WaitForSeconds(WorkerNPC.instance.duration);
        PlayAnimation(parentData.anim[5]);     
        StartCoroutine(babyController.HaircutComplete());

        StartCoroutine(MoveToCashier( parent, navMeshAgent)); 
    }

    public IEnumerator MoveToCashier(ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("MoveToCashier");

        yield return new WaitForSeconds(0.5f); 
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle"); 
        agent.SetDestination(parentData.movepoints[3].position); 

    }
    public IEnumerator MakePaymentToCashier(GameObject parent,ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("MakePaymentToCashier");
        yield return new WaitForSeconds(0.5f);

        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(parentData.anim[6]);
        babyController.PlayAnimation("baby standing idle with father");
        //StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(duration1+1);
        GameManager.instance.totalSoftCurrency += totalBill;
        CanvasManager.instance.UpdateSoftCurrency();
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);  
    } 
    public IEnumerator MoveToHaircut(ParentNPC parentData, NavMeshAgent agent)
    {
        //Debug.Log("MoveToHaircut");

        yield return new WaitForSeconds(1);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle"); 
        agent.SetDestination(parentData.movepoints[4].position); 
    } 
     
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    } 
}
