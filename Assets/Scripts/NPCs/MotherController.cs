using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class MotherController : MonoBehaviour
{
    public MotherNPC mother;
    public Transform spawnParent;
    private NavMeshAgent navMeshAgent;
    private List<GameObject> instantiatedMothers = new List<GameObject>();
    private GameObject baby;
    public Transform spawnPoint;
    private Animator animator;
    private Baby babyController;
    public float time;


    void Start()
    {
        //InstantiateParent();
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public IEnumerator InstantiateParent(Transform spawn)
    {
        GameObject parent = Instantiate(mother.motherNpc, spawn.position, Quaternion.identity, spawnParent);
        parent.SetActive(true);
        baby = parent.transform.Find("Baby_with_Mother_Anim").gameObject;
        babyController = baby.GetComponent<Baby>(); 
        animator = parent.GetComponent<Animator>(); 
        //mother.animator = parent.GetComponent<Animator>();
        navMeshAgent = parent.GetComponent<NavMeshAgent>();
        instantiatedMothers.Add(parent);
        PlayAnimation(mother.anim[0]);
        //Baby.instance.PlayAnimation("Father holding baby idle");
        navMeshAgent.SetDestination(mother.movepoints[6].position);
        yield return new WaitForSeconds(7f);
        StartCoroutine(Move(parent, mother, navMeshAgent));
    }

    public IEnumerator Move(GameObject parent, MotherNPC motherData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        PlayAnimation(motherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(motherData.movepoints[1].position);
        yield return new WaitForSeconds(22.5f);
        //StartCoroutine(babyController.Service1());
        RemoveChild(instantiatedMothers[0]);
        yield return new WaitForSeconds(1); 
        PlayAnimation(motherData.anim[1]);
        yield return new WaitForSeconds(4);
        StartCoroutine(Masseuse.instance.Action());
        agent.SetDestination(motherData.movepoints[2].position);
        PlayAnimation(motherData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(motherData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(motherData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(motherData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(motherData.movepoints[1].position);
        PlayAnimation(motherData.anim[2]);
        yield return new WaitForSeconds(1.75f);
        parent.transform.DOLocalRotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(motherData.anim[6]);
        //StartCoroutine(babyController.Pickup1());
        yield return new WaitForSeconds(3);               
        AddChild(instantiatedMothers[0]);
        PlayAnimation(motherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        if (GameManager.instance.haircutUnlocked)
        {
            StartCoroutine(HaircutMovement(parent, motherData, agent));
        }
        else
        {
            agent.SetDestination(motherData.movepoints[3].position);
            yield return new WaitForSeconds(10.5f);
            parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
            PlayAnimation(motherData.anim[7]);
            babyController.PlayAnimation("baby standing idle with father");
            StartCoroutine(Masseuse.instance.Action1());
            yield return new WaitForSeconds(9);
            PlayAnimation(motherData.anim[0]);
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

    public IEnumerator HaircutMovement(GameObject parent, MotherNPC motherData, NavMeshAgent agent)
    {
        agent.SetDestination(motherData.movepoints[4].position);
        yield return new WaitForSeconds(11.5f);
        PlayAnimation(motherData.anim[8]);
        //StartCoroutine(babyController.Haircut1()); 
        RemoveChild(parent);
        yield return new WaitForSeconds(3f);
        PlayAnimation(motherData.anim[2]);
        agent.SetDestination(motherData.movepoints[5].position);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(motherData.anim[3]);
        yield return new WaitForSeconds(3);
        PlayAnimation(motherData.anim[4]);
        yield return new WaitForSeconds(2);
        PlayAnimation(motherData.anim[5]);
        yield return new WaitForSeconds(2.75f);
        agent.SetDestination(motherData.movepoints[4].position);
        PlayAnimation(motherData.anim[2]);
        yield return new WaitForSeconds(3f);
        parent.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation(motherData.anim[9]);
        AddChild(parent);
        //StartCoroutine(babyController.HairDone1());
        yield return new WaitForSeconds(3);
        PlayAnimation(motherData.anim[0]);
        agent.SetDestination(motherData.movepoints[3].position);
        yield return new WaitForSeconds(9.5f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(motherData.anim[7]);
        babyController.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        PlayAnimation(motherData.anim[0]);
        babyController.PlayAnimation("Father holding baby idle");
        agent.SetDestination(spawnPoint.position);
        yield return new WaitForSeconds(18);
        //Destroy(parent);
    }

    //public void RemoveChild(GameObject prefab)
    //{
    //    Transform childTransform = prefab.transform.Find("Baby_with_Mother_Anim"); // Replace "ChildObjectName" with the actual name of your child object

    //    if (childTransform != null)
    //    {
    //        childTransform.parent = null;
    //    }
    //    else
    //    {
    //        Debug.LogError("Child object not found!");
    //    }
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
