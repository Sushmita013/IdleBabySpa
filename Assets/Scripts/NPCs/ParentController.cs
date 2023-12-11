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
    private BoxCollider serviceCollider;
    private SphereCollider chairCollider;

    private QueueManager queueManager;
    //public float totalBill;

    private int parentRotation; 

    public int roomNo;

    public Action onCompleteAction;

    private WorkerNPC service;

    public List<RoomManager> roomManagers;

    //public Transform babyTransform;

    public Vector3 babyPos,babyRotation;
    public Vector3 parentPos,parentRot;
    public Vector3 pairPos, pairRotation;

    public RoomManager currentRoom;

    void Start()
    {

        animator = parentObject.GetComponent<Animator>();
        //parentnavMesh = parentObject.GetComponent<NavMeshAgent>();
        babyPos = baby.transform.localPosition;
        babyRotation = baby.transform.localEulerAngles;
        parentRot = parentObject.transform.localEulerAngles;
        parentPos = parentObject.transform.localPosition;
        roomManagers.AddRange(AvailabilityManager.instance.rooms);
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
            //queueManager.spawnedGuest.Add(navMeshAgent.gameObject);
            if (!queueManager.waitingQueue.isFull())
            { 
            queueManager.waitingQueue.AddInQueue(this);
            }
            else
            {
                ExitSpa(parent);
            }
            //StartCoroutine(MoveToReception(parent, navMeshAgent));
        } 
        if (other.tag == "Reception")
        {
            duration = other.GetComponent<Receptionist>().duration;
            //StartCoroutine(ReceptionEntry(parent, navMeshAgent));
        }
        if (other.tag=="MassageTable")
        {
            //transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f);
            navMeshAgent.ResetPath(); 
            duration = other.GetComponent<WorkerNPC>().duration;
            chairPoint = other.GetComponent<WorkerNPC>().chairPoint; 
            parentRotation = other.GetComponent<WorkerNPC>().parentRotation;
            serviceCollider = other.GetComponent<BoxCollider>();
            pairPos = transform.localPosition;
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
            serviceCollider = other.GetComponent<BoxCollider>();
            pairPos = transform.position;
            StartCoroutine(GetHaircut(parent)); 
        }
        if(other.tag=="SwimUnit")
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.1f); 
            navMeshAgent.ResetPath(); 
            duration = other.GetComponent<WorkerNPC>().duration;
            chairPoint = other.GetComponent<WorkerNPC>().chairPoint;
            parentRotation = other.GetComponent<WorkerNPC>().parentRotation;
            serviceCollider = other.GetComponent<BoxCollider>();
            pairPos = transform.localPosition; 
            StartCoroutine(GetSwimming(parent)); 
        }
        if(other.tag=="PhotoProp")
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f); 
            navMeshAgent.ResetPath(); 
            duration = other.GetComponent<WorkerNPC>().duration;
            chairPoint = other.GetComponent<WorkerNPC>().chairPoint;
            parentRotation = other.GetComponent<WorkerNPC>().parentRotation;
            serviceCollider = other.GetComponent<BoxCollider>();
            pairPos = transform.localPosition; 
            StartCoroutine(GetPhotoshoot(parent)); 
        }
        //if (other.tag=="Cashier")
        //{
        //    //duration1 = other.GetComponent<Billing>().duration;
        //    StartCoroutine(MakePaymentToCashier(instantiatedParent,parent,navMeshAgent)); 
        //}
        if (other.tag == "DestroyPoint")
        {
            //parking = other.GetComponentInParent<ParkingSlot>();
            parking.ExitCar(parking.car);
            Destroy(gameObject, 0.1f);
            //gameObject.SetActive(false);
        }
    }

    public void SnapToOriginalPos()
    {
        baby.transform.localPosition = babyPos;
        parentObject.transform.localPosition = parentPos;
        baby.transform.localEulerAngles = babyRotation;
        parentObject.transform.localEulerAngles = parentRot;
    } 
    public void SnapToMassagePos()
    {
        transform.localEulerAngles = new Vector3(0, 90, 0);
        transform.localPosition = pairPos;
        SnapToOriginalPos();  
    }
    public void SnapToHaircutPos()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = pairPos; 
        SnapToOriginalPos(); 
    }
    public void SnapToSwimPos()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0);
        transform.localPosition = pairPos; 
        SnapToOriginalPos(); 
    }
    public void SnapToPhotoPos()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.localPosition = pairPos; 
        SnapToOriginalPos(); 
    }

    public void MoveToReception(ParentNPC parentData)
    {
        Debug.Log("MoveToReception");
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent"); 
    } 
    public void MoveToNextDestination(ParentNPC parentData)
    {
        Debug.Log("MoveToNextDestination");  
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent");
        RoomManager parentDestination = FindDestination();
        if (parentDestination != null)
        {
        queueManager.waitingQueue.RemoveFromQueue(this);
        parentDestination.waiting.AddInQueue(this);
            //destination = parentDestination;
            //MoveToTarget(parentDestination);
        } 

        //agent.SetDestination(FindDestination().position);  
    }
    public void MoveToNextService(ParentNPC parentData)
    {
        Debug.Log("MoveToNextService");  
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent");
        RoomManager parentDestination = FindDestination();

        if (parentDestination != null && !parentDestination.waiting.isFull())
        {
            navMeshAgent.avoidancePriority = 45;
            parentDestination.waiting.AddInQueue(this);
            //destination = parentDestination;
            //MoveToTarget(parentDestination);
        }
        else
        {
            ExitSpa(parent);
        }
        //navMeshAgent.SetDestination(FindDestination().position);  
    } 
    public IEnumerator GetMassage(ParentNPC parentData)
    { 
        Debug.Log("GetMassage"); 
        yield return new WaitForSeconds(0.25f); 
        SnapToMassagePos();
        serviceCollider.enabled=false;
        PlayAnimation(parentData.anim[2]);
        babyController.PlayAnimation("keep baby on table"); 
        yield return new WaitForSeconds(3f);
        baby.transform.DOScale(new Vector3(3f, 3f, 3f), 0.5f);  
        //baby.transform.localPosition = new Vector3(1.3f, -0.705f, 0.090f);
        baby.transform.DOLocalMove( new Vector3(1.3f, -0.705f, -0.65f),0.5f);
        yield return new WaitForSeconds(0.6f);
        RemoveBaby();
        babyController.RemoveBabyClothes();
        //diaperGO.SetActive(false);
        babyController.babyClothes.SetActive(false);
        babyController.bodyDiaper.SetActive(true);
        PlayAnimation(parentData.anim[3]);
        babyController.PlayAnimation("baby on table idle");
        //PlayAnimationMassage("Taking oil");
        //parentObject.GetComponent<NavMeshAgent>().enabled = true;
        MoveToTarget(chairPoint);
        //navMeshAgent.SetDestination(chairPoint.position);
        RemoveBaby();
        yield return new WaitForSeconds(1.25f);
        navMeshAgent.ResetPath(); 
        transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]); 
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]);
        //PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(duration-4.5f);
        PlayAnimation(parentData.anim[6]); 
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        //navMeshAgent.SetDestination(destination.position);
        MoveToTarget(destination); 
        yield return new WaitForSeconds(1.25f);
        AddBaby();
        babyController.HadClothes();
        //baby.transform.localPosition = new Vector3(0, 0.131f, 1.406f);
        babyController.bodyDiaper.SetActive(false);
        babyController.babyClothes.SetActive(true);
        navMeshAgent.ResetPath();
        BabyScaleDown();
        SnapToMassagePos();
        baby.transform.DOLocalMove(new Vector3(0, 0.131f, 0.519f), 0.5f); 
        //PlayAnimationMassage("standing idle");
        //navMeshAgent.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f); 
        PlayAnimation(parentData.anim[7]);
        babyController.PlayAnimation("take baby from table");  
        yield return new WaitForSeconds(4);
        SnapToOriginalPos();
        //serviceCollider.enabled=true;
        //parentObject.GetComponent<NavMeshAgent>().enabled = false;
        service.isAvailable = true;
        var lastRoom = currentRoom;
        MoveToNextService(parent);
        yield return new WaitForSeconds(3);
        lastRoom.waiting.CheckForFreeSlots();
        serviceCollider.enabled = true;
    }


    public IEnumerator GetHaircut(ParentNPC parentData)
    {
        Debug.Log("GetHaircut");
        yield return new WaitForSeconds(0.25f); 
        SnapToHaircutPos();
        //transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
        PlayAnimation(parentData.anim[8]);
        babyController.PlayAnimation("Keeping baby on chair"); 
        yield return new WaitForSeconds(3f);
        serviceCollider.enabled = false; 
        baby.transform.DOScale(new Vector3(3f, 3f, 3f), 0.5f);
        baby.transform.DOLocalMove(new Vector3(-0.193f, -0.784f, -0.623f), 0.1f);
        yield return new WaitForSeconds(0.6f); 
        RemoveBaby();
        babyController.PlayAnimation("baby on chair idle");
        PlayAnimation(parentData.anim[3]);
        //PlayAnimationMassage("Taking oil");
        //parentObject.GetComponent<NavMeshAgent>().enabled = true;
        MoveToTarget(chairPoint); 
        //navMeshAgent.SetDestination(chairPoint.position);
        yield return new WaitForSeconds(3f);
        navMeshAgent.ResetPath();
        transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]);
        //PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(duration - 6f); 
        PlayAnimation(parentData.anim[6]);
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        //navMeshAgent.SetDestination(destination.position);
        MoveToTarget(destination); 
        yield return new WaitForSeconds(3f);
        AddBaby(); 
        navMeshAgent.ResetPath();
        babyController.longHair.SetActive(false);
        babyController.shortHair.SetActive(true);
        BabyScaleDown();
        SnapToHaircutPos();
        baby.transform.DOLocalMove(new Vector3(0, 0.131f, 0.519f), 0.5f); 
        //transform.DOLocalMove(new Vector3(0.01852795f, 0.131f, 1.63435f), 0.5f); 
        //transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        PlayAnimation(parentData.anim[9]);
        babyController.PlayAnimation("baby going with parent from chair");  
        yield return new WaitForSeconds(4);
        SnapToOriginalPos(); 
        //serviceCollider.enabled = true; 
        //parentObject.GetComponent<NavMeshAgent>().enabled = false;
        service.isAvailable = true;
        var lastRoom = currentRoom; 
        MoveToNextService(parent);
        yield return new WaitForSeconds(3);
        lastRoom.waiting.CheckForFreeSlots(); 
        serviceCollider.enabled = true;
    }
    public IEnumerator GetSwimming(ParentNPC parentData)
    {
        Debug.Log("GetSwimming");
        yield return new WaitForSeconds(0.25f); 
        SnapToSwimPos();
        PlayAnimation(parentData.anim[10]);
        babyController.PlayAnimation("baby going in watertank");  
        yield return new WaitForSeconds(3.5f);
        serviceCollider.enabled = false; 
        baby.transform.DOScale(new Vector3(3f, 3f, 3f), 0.1f);
        //baby.transform.rotation = Quaternion.Euler(0,-130,0); 
        baby.transform.DOLocalRotate(new Vector3(0, -130, 0), 0.1f);
        baby.transform.DOLocalMove(new Vector3(1.593f, -0.413f, 4.674f), 0.1f);
        yield return new WaitForSeconds(0.6f);
        DOTween.Kill(baby.transform);
        RemoveBaby();
        //baby.transform.rotation = Quaternion.Euler(0,90,0);
        //baby.transform.position = new Vector3(-20.3500004f, -8.42000008f, -4.25f);
        babyController.babyClothes.SetActive(false);
        babyController.bodyDiaper.SetActive(true);
        babyController.PlayAnimation("baby in watertank idle");
        PlayAnimation(parentData.anim[3]);  
        //parentObject.GetComponent<NavMeshAgent>().enabled = true;
        //navMeshAgent.SetDestination(chairPoint.position);
        MoveToTarget(chairPoint);  
        yield return new WaitForSeconds(2f);
        navMeshAgent.ResetPath();
        transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]); 
        yield return new WaitForSeconds(duration - 5.5f); 
        PlayAnimation(parentData.anim[6]);
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        //navMeshAgent.SetDestination(destination.position);
        MoveToTarget(destination); 
        yield return new WaitForSeconds(2f);
        AddBaby();
        navMeshAgent.ResetPath();
        babyController.bodyDiaper.SetActive(false);
        babyController.babyClothes.SetActive(true);
        BabyScaleDown();
        SnapToSwimPos(); 
        baby.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        baby.transform.DOLocalMove(new Vector3(0, 0.131f, 0.519f), 0.5f); 
        //transform.DOLocalMove(new Vector3(0.01852795f, 0.131f, 1.63435f), 0.5f); 
        //transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f); 
        PlayAnimation(parentData.anim[11]);
        babyController.PlayAnimation("baby going back with parent");  
        yield return new WaitForSeconds(4);
        SnapToOriginalPos(); 
        //parentObject.GetComponent<NavMeshAgent>().enabled = false;
        service.isAvailable = true;
        var lastRoom = currentRoom;

        MoveToNextService(parent);
        yield return new WaitForSeconds(3);
        lastRoom.waiting.CheckForFreeSlots(); 
        serviceCollider.enabled = true; 
    }
    public IEnumerator GetPhotoshoot(ParentNPC parentData)
    {
        Debug.Log("GetPhotoshoot");
        yield return new WaitForSeconds(0.25f); 
        SnapToPhotoPos();
        PlayAnimation(parentData.anim[12]);
        babyController.PlayAnimation("keeping baby on photoProp");  
        yield return new WaitForSeconds(1.5f);
        serviceCollider.enabled = false;
        baby.transform.DOScale(new Vector3(3f, 3f, 3f), 0.3f);
        baby.transform.DOLocalMove(new Vector3(-0.312999994f, -0.449999809f, -0.711000025f), 0.3f);
        //baby.transform.DOLocalMove(new Vector3(-17.3670006f, -8.55500031f, 71.2799988f), 0.5f);
        yield return new WaitForSeconds(0.4f);
        DOTween.Kill(baby.transform); 
        RemoveBaby();
        babyController.PlayAnimation("baby on photoProp idle");
        PlayAnimation(parentData.anim[3]);  
        MoveToTarget(chairPoint);

        //parentObject.GetComponent<NavMeshAgent>().enabled = true;
        //navMeshAgent.ResetPath();
        //navMeshAgent.enabled = false;
        //navMeshAgent.SetDestination(chairPoint.position);

        yield return new WaitForSeconds(3f);
        navMeshAgent.ResetPath();
        transform.DOLocalRotate(new Vector3(0, parentRotation, 0), 0.1f);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2.5f);
        PlayAnimation(parentData.anim[5]); 
        yield return new WaitForSeconds(duration - 4.5f); 
        PlayAnimation(parentData.anim[6]);
        yield return new WaitForSeconds(1.5f);
        PlayAnimation(parentData.anim[3]);
        //navMeshAgent.SetDestination(destination.position);
        MoveToTarget(destination); 
        yield return new WaitForSeconds(3f);
        AddBaby();
        BabyScaleDown();
        SnapToPhotoPos(); 
        navMeshAgent.ResetPath(); 
        baby.transform.DOLocalMove(new Vector3(0, 0.131f, 0.519f), 0.5f); 
        //parentObject.transform.DOLocalMove(new Vector3(0.01852795f, 0.131f, 1.63435f), 0.5f); 
        //parentObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f); 
        PlayAnimation(parentData.anim[13]);
        babyController.PlayAnimation("taking baby on photoProp");  
        //navMeshAgent.enabled = true; 
        //parentObject.GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        SnapToOriginalPos(); 
        service.isAvailable = true;
        var lastRoom = currentRoom;

        MoveToNextService(parent);
        yield return new WaitForSeconds(3);
        lastRoom.waiting.CheckForFreeSlots();
        serviceCollider.enabled = true; 
    }

    public void ExitSpa(ParentNPC parentData)
    {
        Debug.Log("ExitSpa");
        navMeshAgent.avoidancePriority = 99;
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("walking with parent");
        parking.destroyPoint.GetComponent<BoxCollider>().enabled = true;
        MoveToTarget(spawnPoint); 
    }
     
     
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    } 
    public void BabyScaleDown()
    {
        baby.transform.DOScale(new Vector3(2f, 2f, 2f), 0.5f);
        baby.transform.DOLocalMove(new Vector3(0, 0.131f, 1.406f), 0.5f);
    } 
     
    public void RemoveBaby()
    {
        baby.transform.SetParent(null);
    }

    public void AddBaby()
    {
        baby.transform.SetParent(this.transform);
    }

    public RoomManager FindDestination()
    { 
        bool noServiceAvailable=false;
        if (roomManagers.Count <= 0)
        {
            ExitSpa(parent);
            return null;
        }
        RoomManager room = null;
        RoomManager serviceDestination = null;
        List<RoomManager> tempList = new List<RoomManager>();
        tempList.AddRange(roomManagers);
        do
        { 
            room = tempList[UnityEngine.Random.Range(0, tempList.Count)];
            if (room.IsServiceAvailable())
            {
                break;
            }
            tempList.Remove(room);
            if (tempList.Count <= 0)
            {
                noServiceAvailable = true;
                break;
            }
            
        } while (true);

        if (noServiceAvailable)
        {
            currentRoom = AvailabilityManager.instance.FindSmallesWaitingQueue(roomManagers);
            //currentRoom.waiting.AddInQueue(this);
            return currentRoom;
        }
        else
        { 
            currentRoom = room;
            //service = room.CheckForService();
            serviceDestination = room; 

        roomManagers.Remove(room);
        return serviceDestination;
        } 

    }

    public void CheckForSlots()
    {
        Debug.Log("CheckForSlots");
        if (currentRoom == null)
        {
            return;
        }
        Transform serviceDestination;
        if (currentRoom.IsServiceAvailable()) 
        {
            service = currentRoom.CheckForService();
            serviceDestination = service.destinationPoint;
            roomManagers.Remove(currentRoom);
            currentRoom.waiting.RemoveFromQueue(this);
            destination = serviceDestination;
            PlayAnimation(parent.anim[0]);
            babyController.PlayAnimation("walking with parent");
            navMeshAgent.avoidancePriority = 50; 
            MoveToTarget(serviceDestination);
        }
        else
        {
            PlayAnimation(parent.anim[1]);
            babyController.PlayAnimation("standing idle");
        }
    }

    //public Transform GetRandomService()
    //{
    //    WorkerNPC destinationtemp = AvailabilityManager.instance.GetAvailableService();

    //    if (destinationtemp != null)
    //    {
    //        destination = destinationtemp.destinationPoint;
    //        service = destinationtemp.GetComponentInParent<WorkerNPC>();
    //    }
    //    //else
    //    //{
    //    //    return null;
    //    //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
    //    //}
    //    return destination;
    //}
    //public Transform GetMassageService()
    //{
    //    WorkerNPC destinationtemp = AvailabilityManager.instance.GetAvailableMassageService();

    //    if (destinationtemp != null)
    //    {
    //        destination = destinationtemp.destinationPoint;
    //        service = destinationtemp.GetComponentInParent<WorkerNPC>();
    //    }
    //    //else
    //    //{
    //    //    return null;
    //    //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
    //    //}
    //    return destination;
    //}
    //public Transform GetHaircutService()
    //{
    //    WorkerNPC destinationtemp = AvailabilityManager.instance.GetAvailableHaircutService();

    //    if (destinationtemp != null)
    //    {
    //        destination = destinationtemp.destinationPoint;
    //        service = destinationtemp.GetComponentInParent<WorkerNPC>(); 
    //    }

    //    //if (AvailabilityManager.instance.GetAvailableHaircutService() != null)
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailableHaircutService().destinationPoint;
    //    //    //serviceComplete[1] = true;
    //    //}
    //    //else
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
    //    //}
    //    return destination;
    //}
    //public Transform GetSwimService()
    //{
    //    WorkerNPC destinationtemp = AvailabilityManager.instance.GetAvailableSwimService();

    //    if (destinationtemp != null)
    //    {
    //        destination = destinationtemp.destinationPoint;
    //        service = destinationtemp.GetComponentInParent<WorkerNPC>(); 
    //    }
    //    //if (AvailabilityManager.instance.GetAvailableSwimService() != null)
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailableSwimService().destinationPoint;
    //    //    //serviceComplete[2] = true;
    //    //}
    //    //else
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
    //    //}
    //    return destination;
    //}
    //public Transform GetPhotoshootService()
    //{
    //    WorkerNPC destinationtemp = AvailabilityManager.instance.GetAvailablePhotoService();

    //    if (destinationtemp != null)
    //    {
    //        destination = destinationtemp.destinationPoint;
    //        service = destinationtemp.GetComponentInParent<WorkerNPC>(); 
    //    }
    //    //if (AvailabilityManager.instance.GetAvailablePhotoService() != null)
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailablePhotoService().destinationPoint;
    //    //    //serviceComplete[3] = true;
    //    //}
    //    //else
    //    //{
    //    //    destination = AvailabilityManager.instance.GetAvailableQueueSlot().destinationPoint;
    //    //}
    //    return destination;
    //}
}
