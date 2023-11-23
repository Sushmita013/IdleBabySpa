using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;

public class ParentController : MonoBehaviour
{
    public ParentNPC parent;
    internal NavMeshAgent navMeshAgent;
    internal NavMeshAgent parentnavMesh;
    internal GameObject instantiatedParent;
    internal GameObject baby;
    internal GameObject parentObject;
    internal Animator animator;
    internal Baby babyController;
    public float time;
    internal ParkingSlot parking;
    internal Transform spawnPoint;

    private float duration;
    private float duration1;
    private Transform chairPoint;
    private Transform destination;

    private QueueManager queueManager;
    //public float totalBill;

    private int parentRotation;

    public List<bool> serviceComplete;

    public int roomNo;

    public Action onCompleteAction;

    private Service service; 

    void Start()
    {
        animator = parentObject.GetComponent<Animator>();
        parentnavMesh = parentObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (navMeshAgent.isStopped)
            return;

        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    //if (navmeshAgent.isActiveAndEnabled)
                    //    navmeshAgent.ResetPath();

                    navMeshAgent.isStopped = true;
                    onCompleteAction?.Invoke();
                }
            }
        }
    }

    public void MoveToTarget(Transform target, Action onComplete = null)
    {
        //animator.Play("Walking", 0);
        onCompleteAction = null;
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
        onCompleteAction = onComplete;
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
            queueManager = other.GetComponent<QueueManager>();
            queueManager.spawnedGuest.Add(navMeshAgent.gameObject);
            queueManager.waitingQueue.AddInQueue(this);
            //StartCoroutine(MoveToReception(parent, navMeshAgent));
        }
        if (other.tag == "Reception")
        {
            duration = other.GetComponent<Receptionist>().duration;
            //StartCoroutine(ReceptionEntry(parent, navMeshAgent));
        }
        if (other.tag=="MassageTable")
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f);
            navMeshAgent.ResetPath(); 
            duration = other.GetComponent<WorkerNPC>().duration;
            chairPoint = other.GetComponent<WorkerNPC>().chairPoint; 
            parentRotation = other.GetComponent<WorkerNPC>().parentRotation;  
            //parentObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f);
            StartCoroutine(GetMassage(parent));
        }
        if(other.tag=="HaircutChair")
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
            navMeshAgent.ResetPath(); 
            duration = other.GetComponent<WorkerNPC>().duration;
            chairPoint = other.GetComponent<WorkerNPC>().chairPoint;
            parentRotation = other.GetComponent<WorkerNPC>().parentRotation;
            StartCoroutine(GetHaircut(parent)); 
        }
        if(other.tag=="Cashier")
        {
            //duration1 = other.GetComponent<Billing>().duration;
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

    public void MoveToReception(ParentNPC parentData)
    {
        Debug.Log("MoveToReception");
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent"); 
    }
    public IEnumerator ReceptionEntry(ParentNPC parentData)
    {
        Debug.Log("ReceptionEntry"); 
        PlayAnimation(parentData.anim[1]);
        babyController.PlayAnimation("standing idle"); 
        yield return new WaitForSeconds(duration);
        MoveToNextDestination(parent); 
    }
    public void MoveToNextDestination(ParentNPC parentData)
    {
        Debug.Log("MoveToNextDestination");  
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent");
        queueManager.MoveGuestToDestination(FindDestination()); 
        //agent.SetDestination(FindDestination().position);  
    }
    public void MoveToNextService(ParentNPC parentData)
    {
        Debug.Log("MoveToNextService");  
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent");
        MoveToTarget(FindDestination()); 
        //navMeshAgent.SetDestination(FindDestination().position);  
    }

    //public IEnumerator GetMassage(ParentNPC parentData, NavMeshAgent agent)
    //{
    //    //Debug.Log("GetMassage");  
    //    PlayAnimation(parentData.anim[2]);
    //    StartCoroutine(babyController.Massage()); 
    //    yield return new WaitForSeconds(2);
    //    //StartCoroutine(Masseuse.instance.Action());
    //    PlayAnimation(parentData.anim[2]); 
    //    yield return new WaitForSeconds(duration);
    //    PlayAnimation(parentData.anim[3]);
    //    StartCoroutine(babyController.MassageComplete()); 
    //    if (GameManager.instance.haircutUnlocked)
    //    {
    //        StartCoroutine(MoveToHaircut(parent, navMeshAgent));
    //    }
    //    else
    //    { 
    //        StartCoroutine(MoveToCashier( parent, navMeshAgent));
    //    }
    //}
    public IEnumerator GetMassage(ParentNPC parentData)
    { 
        Debug.Log("GetMassage");
        PlayAnimation(parentData.anim[2]);
        babyController.PlayAnimation("keep baby on table"); 
        yield return new WaitForSeconds(3f);
        baby.transform.DOScale(new Vector3(3f, 3f, 3f), 0.5f);
        baby.transform.localPosition = new Vector3(1.3f, -0.705f, 0.090f);
        //diaperGO.SetActive(false);
        babyController.babyClothes.SetActive(false);
        babyController.bodyDiaper.SetActive(true);
        PlayAnimation(parentData.anim[3]);
        babyController.PlayAnimation("baby on table idle");
        //PlayAnimationMassage("Taking oil");
        parentObject.GetComponent<NavMeshAgent>().enabled = true;
        parentnavMesh.SetDestination(chairPoint.position);
        yield return new WaitForSeconds(2.5f);
        parentnavMesh.ResetPath(); 
        parentObject.transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]); 
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]);
        //PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(duration-5);
        PlayAnimation(parentData.anim[6]); 
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        parentnavMesh.SetDestination(destination.position); 
        yield return new WaitForSeconds(2f);
        baby.transform.DOScale(new Vector3(2f, 2f, 2f), 0.5f);
        baby.transform.localPosition = new Vector3(0, 0.131f, 1.406f);
        babyController.bodyDiaper.SetActive(false);
        babyController.babyClothes.SetActive(true);
        parentnavMesh.ResetPath(); 
        //PlayAnimationMassage("standing idle");
        parentnavMesh.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f); 
        PlayAnimation(parentData.anim[7]);
        babyController.PlayAnimation("take baby from table"); 
        serviceComplete[0] = true; 
        yield return new WaitForSeconds(4);
        service.isAvailable = true;
        parentObject.GetComponent<NavMeshAgent>().enabled = false;
        MoveToNextService(parent);
    }


    public IEnumerator GetHaircut(ParentNPC parentData)
    {
        Debug.Log("GetHaircut");
        yield return new WaitForSeconds(0.5f);
        transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
        PlayAnimation(parentData.anim[8]);
        babyController.PlayAnimation("Keeping baby on chair"); 
        yield return new WaitForSeconds(4f);
        babyController.PlayAnimation("baby on chair idle");
        PlayAnimation(parentData.anim[3]); 
        //PlayAnimationMassage("Taking oil");
        parentObject.GetComponent<NavMeshAgent>().enabled = true;
        parentnavMesh.SetDestination(chairPoint.position); 
        yield return new WaitForSeconds(2.5f);
        parentnavMesh.ResetPath();
        parentObject.transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]);
        //PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(duration - 5); 
        PlayAnimation(parentData.anim[6]);
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        parentnavMesh.SetDestination(destination.position);
        yield return new WaitForSeconds(2f);
        //PlayAnimationMassage("standing idle");
        parentObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
        PlayAnimation(parentData.anim[9]);
        babyController.PlayAnimation("baby going with parent from chair"); 
        serviceComplete[1] = true; 
        yield return new WaitForSeconds(4);
        service.isAvailable = true;
        parentObject.GetComponent<NavMeshAgent>().enabled = false;
        MoveToNextService(parent);
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
        yield return new WaitForSeconds(duration1);
        //GameManager.instance.totalSoftCurrency += totalBill;
        CanvasManager.instance.UpdateSoftCurrency();
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);  
    }  
     
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    } 

    public Transform FindDestination()
    {
        Transform serviceDestination = null;
        for (int i = 0; i <= serviceComplete.Count; i++)
        {
            if (!serviceComplete[i])
            {
                roomNo = i;
                break;
            }
            //else
            //{
            //    Debug.Log("All services done. Proceed to exit");
            //    serviceDestination = spawnPoint;
            //}
        }

        switch (roomNo)
        {
            case 0:
                serviceDestination=GetMassageService();
                break;
            case 1:
                serviceDestination= GetHaircutService();
                break;
            case 2:
                serviceDestination= GetSwimService();
                break;
            case 3:
                serviceDestination= GetPhotoshootService();
                break; 
        }

        return serviceDestination;
    }

    public Transform GetMassageService()
    {
        Service destinationtemp = AvailabilityManager.instance.GetAvailableMassageService();

        if (destinationtemp != null)
        {
            destination = destinationtemp.destinationPoint;
            service = destinationtemp.GetComponentInParent<Service>();
        }
        //else
        //{
        //    return null;
        //    //destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
        //}
        return destination;
    }
    public Transform GetHaircutService()
    {
        Service destinationtemp = AvailabilityManager.instance.GetAvailableHaircutService();

        if (destinationtemp != null)
        {
            destination = destinationtemp.destinationPoint;
            service = destinationtemp.GetComponentInParent<Service>(); 
        }

        //if (AvailabilityManager.instance.GetAvailableHaircutService() != null)
        //{
        //    destination = AvailabilityManager.instance.GetAvailableHaircutService().destinationPoint;
        //    //serviceComplete[1] = true;
        //}
        //else
        //{
        //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
        //}
        return destination;
    }
    public Transform GetSwimService()
    {
        Service destinationtemp = AvailabilityManager.instance.GetAvailableSwimService();

        if (destinationtemp != null)
        {
            destination = destinationtemp.destinationPoint;
            service = destinationtemp.GetComponentInParent<Service>(); 
        }
        //if (AvailabilityManager.instance.GetAvailableSwimService() != null)
        //{
        //    destination = AvailabilityManager.instance.GetAvailableSwimService().destinationPoint;
        //    //serviceComplete[2] = true;
        //}
        //else
        //{
        //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
        //}
        return destination;
    }
    public Transform GetPhotoshootService()
    {
        Service destinationtemp = AvailabilityManager.instance.GetAvailablePhotoService();

        if (destinationtemp != null)
        {
            destination = destinationtemp.destinationPoint;
            service = destinationtemp.GetComponentInParent<Service>(); 
        }
        //if (AvailabilityManager.instance.GetAvailablePhotoService() != null)
        //{
        //    destination = AvailabilityManager.instance.GetAvailablePhotoService().destinationPoint;
        //    //serviceComplete[3] = true;
        //}
        //else
        //{
        //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
        //}
        return destination;
    }
}
