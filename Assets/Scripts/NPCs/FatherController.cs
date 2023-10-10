using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class FatherController : MonoBehaviour
{
    public FatherNPC father;
    public Transform spawnParent;
    private NavMeshAgent navMeshAgent;
    private List<GameObject> instantiatedFathers = new List<GameObject>();
    private GameObject baby;
    public Transform spawnPoint;
    private Animator animator;
    private Baby babyController;
    public float time;
     
    void Start()
    {
        //InstantiateParent();  
        //father.babyNPC = father.fatherNpc.transform.Find("Baby_with_father_Anim").gameObject;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public IEnumerator InstantiateParent(Transform spawn)
    {  
        GameObject parent = Instantiate(father.fatherNpc, spawn.position, Quaternion.identity, spawnParent); 
        parent.SetActive(true);
        baby= parent.transform.Find("Baby_with_father_Anim").gameObject;
        babyController = baby.GetComponent<Baby>();
        animator = parent.GetComponent<Animator>();
        //father.animator = parent.GetComponent<Animator>();
        navMeshAgent = parent.GetComponent<NavMeshAgent>();
        instantiatedFathers.Add(parent);
        PlayAnimation(father.anim[0]);
        //Baby.instance.PlayAnimation("Father holding baby idle");
        navMeshAgent.SetDestination(father.movepoints[6].position);
        yield return new WaitForSeconds(7f); 
        StartCoroutine(Move(parent,father,navMeshAgent)); 
    }

    public IEnumerator Move(GameObject parent, FatherNPC fatherData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        PlayAnimation(fatherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(fatherData.movepoints[1].position); 
        yield return new WaitForSeconds(23f); 
        //if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        //{
        //    Debug.Log("agent at position");
        //    canDropBaby = true;
        //}
        PlayAnimation(fatherData.anim[1]);
        StartCoroutine(babyController.Massage()); 
        RemoveChild(instantiatedFathers[0]); 
        yield return new WaitForSeconds(4);
        StartCoroutine(Masseuse.instance.Action());
        agent.SetDestination(fatherData.movepoints[2].position);
        PlayAnimation(fatherData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(fatherData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(fatherData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(fatherData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(fatherData.movepoints[1].position);
        PlayAnimation(fatherData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(fatherData.anim[6]);
        StartCoroutine(babyController.MassageComplete());
        yield return new WaitForSeconds(3);
        AddChild(instantiatedFathers[0]);
        PlayAnimation(fatherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(HaircutMovement(parent, fatherData, agent));
        }
        else
        {
            agent.SetDestination(fatherData.movepoints[3].position);
            yield return new WaitForSeconds(10.5f);
            parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
            PlayAnimation(fatherData.anim[7]);
            babyController.PlayAnimation("baby standing idle with father");
            StartCoroutine(Masseuse.instance.Action1());
            yield return new WaitForSeconds(9);
            PlayAnimation(fatherData.anim[0]);
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

    public IEnumerator HaircutMovement(GameObject parent, FatherNPC fatherData, NavMeshAgent agent)
    {
        agent.SetDestination(fatherData.movepoints[4].position);
        yield return new WaitForSeconds(11.5f);
        PlayAnimation(fatherData.anim[8]);
        StartCoroutine(babyController.Haircut());
        RemoveChild(parent);
        yield return new WaitForSeconds(3f);
        PlayAnimation(fatherData.anim[2]);
        agent.SetDestination(fatherData.movepoints[5].position);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(fatherData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(fatherData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(fatherData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(fatherData.movepoints[4].position);
        PlayAnimation(fatherData.anim[2]);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(fatherData.anim[9]);
        AddChild(parent);
        //StartCoroutine(babyController.HairDone());
        yield return new WaitForSeconds(3);
        PlayAnimation(fatherData.anim[0]);
        agent.SetDestination(fatherData.movepoints[3].position);
        yield return new WaitForSeconds(9.5f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(fatherData.anim[7]);
        babyController.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        PlayAnimation(fatherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);
        yield return new WaitForSeconds(18);
        //Destroy(parent);
    }
    //public IEnumerator HaircutMovement(GameObject parent, FatherNPC fatherData, NavMeshAgent agent)
    //{ 
    //    agent.SetDestination(fatherData.movepoints[4].position);
    //    yield return new WaitForSeconds(5.75f);
    //    PlayAnimation(fatherData.anim[8]);
    //    StartCoroutine(Baby.instance.Haircut());
    //    RemoveChild(parent);
    //    yield return new WaitForSeconds(3f);
    //    PlayAnimation(fatherData.anim[2]);
    //    agent.SetDestination(fatherData.movepoints[5].position);
    //    yield return new WaitForSeconds(1.5f);
    //    parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
    //    yield return new WaitForSeconds(0.1f);
    //    PlayAnimation(fatherData.anim[3]);
    //    yield return new WaitForSeconds(3);
    //    PlayAnimation(fatherData.anim[4]);
    //    yield return new WaitForSeconds(2);
    //    PlayAnimation(fatherData.anim[5]);
    //    yield return new WaitForSeconds(2.75f);
    //    agent.SetDestination(fatherData.movepoints[4].position);
    //    PlayAnimation(fatherData.anim[2]);
    //    yield return new WaitForSeconds(1.5f);
    //    parent.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
    //    yield return new WaitForSeconds(0.1f);
    //    PlayAnimation(fatherData.anim[9]);
    //    AddChild(parent);
    //    StartCoroutine(Baby.instance.HairDone());
    //    yield return new WaitForSeconds(3);
    //    PlayAnimation(fatherData.anim[0]); 
    //    agent.SetDestination(fatherData.movepoints[3].position);
    //    yield return new WaitForSeconds(4.75f);
    //    parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
    //    PlayAnimation(fatherData.anim[7]);
    //    Baby.instance.PlayAnimation("baby standing idle with father");
    //    StartCoroutine(Masseuse.instance.Action1());
    //    yield return new WaitForSeconds(9);
    //    PlayAnimation(fatherData.anim[0]);
    //    Baby.instance.PlayAnimation("Father holding baby idle");
    //    agent.SetDestination(fatherData.movepoints[0].position);
    //    yield return new WaitForSeconds(7);
    //    Destroy(parent);
    //}

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
