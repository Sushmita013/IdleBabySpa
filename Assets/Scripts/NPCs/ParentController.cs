using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class ParentController : MonoBehaviour
{
    public ParentNPC parent;
    public Transform spawnParent;
    private NavMeshAgent navMeshAgent;
    private List<GameObject> instantiatedParents = new List<GameObject>();
    private GameObject baby;
    public Transform spawnPoint;
    private Animator animator;
    private Baby babyController;
    public float time;

    void Start()
    { 
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "ParkingWalkway")
        { 
            MoveToMassage(parent, navMeshAgent);
        }
        if(other.tag=="MassageTable")
        { 
            StartCoroutine(GetMassage(parent, navMeshAgent));
        }
        if(other.tag=="HaircutChair")
        {
            StartCoroutine(GetHaircut(parent, navMeshAgent)); 
        }
        if(other.tag=="Cashier")
        {
            StartCoroutine(GetHaircut(parent, navMeshAgent)); 
        }
    }

    public IEnumerator InstantiateParent(Transform spawn)
    {
        GameObject parentPrefab = parent.parentNpc[Random.Range(0, parent.parentNpc.Count)];

        GameObject parentGO = Instantiate(parentPrefab, spawn.position, Quaternion.identity, spawnParent);
            parentGO.SetActive(true);
            baby = parentGO.transform.Find("Baby").gameObject;
            babyController = baby.GetComponent<Baby>();
            animator = parentGO.GetComponent<Animator>(); 
            navMeshAgent = parentGO.GetComponent<NavMeshAgent>();
            instantiatedParents.Add(parentGO);
            PlayAnimation(parent.anim[0]); 
            navMeshAgent.SetDestination(parent.movepoints[0].position);
            yield return new WaitForSeconds(7f);
            //StartCoroutine(Move(parentGO, parent, navMeshAgent));
        
    }

    public IEnumerator MoveToMassage(ParentNPC parentData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(parentData.movepoints[1].position);
    }
    
    public IEnumerator GetMassage(ParentNPC parentData, NavMeshAgent agent)
    {
        PlayAnimation(parentData.anim[1]);
        StartCoroutine(babyController.Service());
        yield return new WaitForSeconds(3);
        PlayAnimation(parentData.anim[2]); 
        yield return new WaitForSeconds(15);
        PlayAnimation(parentData.anim[3]);
        StartCoroutine(babyController.Pickup());
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(MoveToHaircut(parent, navMeshAgent));
        }
        else
        { 
            StartCoroutine(MoveToCashier(instantiatedParents[0],parent, navMeshAgent));
        }
    }
    public IEnumerator GetHaircut(ParentNPC parentData, NavMeshAgent agent)
    {
        PlayAnimation(parentData.anim[1]);
        StartCoroutine(babyController.Service());
        yield return new WaitForSeconds(3);
        PlayAnimation(parentData.anim[2]); 
        yield return new WaitForSeconds(15);
        PlayAnimation(parentData.anim[3]);
        StartCoroutine(babyController.Pickup());
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(MoveToHaircut(parent, navMeshAgent));
        }
        else
        {

        }
    }

    public IEnumerator MoveToCashier(GameObject parent,ParentNPC parentData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(parentData.movepoints[3].position);
        yield return new WaitForSeconds(10.5f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(parentData.anim[7]);
        babyController.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);
        yield return new WaitForSeconds(18);

    }
    public IEnumerator MoveToHaircut(ParentNPC parentData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1); 
    }

    public IEnumerator Move(GameObject parent, ParentNPC parentData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(parentData.movepoints[1].position);
        yield return new WaitForSeconds(23f);
        //if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        //{
        //    Debug.Log("agent at position");
        //    canDropBaby = true;
        //}
        PlayAnimation(parentData.anim[1]);
        StartCoroutine(babyController.Service());
        RemoveChild(instantiatedParents[0]);
        yield return new WaitForSeconds(4);
        StartCoroutine(Masseuse.instance.Action());
        agent.SetDestination(parentData.movepoints[2].position);
        PlayAnimation(parentData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(parentData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(parentData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(parentData.movepoints[1].position);
        PlayAnimation(parentData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(parentData.anim[6]);
        StartCoroutine(babyController.Pickup());
        yield return new WaitForSeconds(3);
        AddChild(instantiatedParents[0]);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(HaircutMovement(parent, parentData, agent));
        }
        else
        {
            agent.SetDestination(parentData.movepoints[3].position);
            yield return new WaitForSeconds(10.5f);
            parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
            PlayAnimation(parentData.anim[7]);
            babyController.PlayAnimation("baby standing idle with father");
            StartCoroutine(Masseuse.instance.Action1());
            yield return new WaitForSeconds(9);
            PlayAnimation(parentData.anim[0]);
            babyController.PlayAnimation("Father holding baby idle");
            agent.SetDestination(spawnPoint.position);
            yield return new WaitForSeconds(18);
            //Destroy(parent); 
        }
    }
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }

    public IEnumerator HaircutMovement(GameObject parent, ParentNPC parentData, NavMeshAgent agent)
    {
        agent.SetDestination(parentData.movepoints[4].position);
        yield return new WaitForSeconds(11.5f);
        PlayAnimation(parentData.anim[8]);
        StartCoroutine(babyController.Haircut());
        RemoveChild(parent);
        yield return new WaitForSeconds(3f);
        PlayAnimation(parentData.anim[2]);
        agent.SetDestination(parentData.movepoints[5].position);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(parentData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(parentData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(parentData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(parentData.movepoints[4].position);
        PlayAnimation(parentData.anim[2]);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(parentData.anim[9]);
        AddChild(parent);
        StartCoroutine(babyController.HairDone());
        yield return new WaitForSeconds(3);
        PlayAnimation(parentData.anim[0]);
        agent.SetDestination(parentData.movepoints[3].position);
        yield return new WaitForSeconds(9.5f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(parentData.anim[7]);
        babyController.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        PlayAnimation(parentData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);
        yield return new WaitForSeconds(18);
        //Destroy(parent);
    } 
    public void RemoveChild(GameObject prefab)
    {
        if (baby != null)
        {
            baby.transform.parent = null;
        }
    }

    public void AddChild(GameObject prefab)
    {
        if (baby != null)
        {
            baby.transform.parent = prefab.transform;
        }
    }

}
