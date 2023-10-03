using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class MotherController : MonoBehaviour
{
    public MotherNPC mother;
    public Transform spawnParent;
    public NavMeshAgent navMeshAgent;
    private List<GameObject> instantiatedFathers = new List<GameObject>();


    void Start()
    {
        InstantiateParent();
    }

    private void InstantiateParent()
    {
        GameObject parent = Instantiate(mother.motherNpc, mother.movepoints[0].localPosition, Quaternion.identity, spawnParent);
        parent.SetActive(true);
        mother.animator = parent.GetComponent<Animator>();
        navMeshAgent = parent.GetComponent<NavMeshAgent>();
        instantiatedFathers.Add(parent);
        StartCoroutine(Move(parent, mother, navMeshAgent));
    }

    public IEnumerator Move(GameObject parent, MotherNPC motherData, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        PlayAnimation(motherData.anim[0]);
        Baby.instance.PlayAnimation("Father holding baby idle");
        agent.SetDestination(motherData.movepoints[1].position);
        yield return new WaitForSeconds(24f);
        StartCoroutine(Baby.instance.Service1());
        RemoveChild(parent);
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
        StartCoroutine(Baby.instance.Pickup1());
        yield return new WaitForSeconds(3);               
        AddChild(parent);
        PlayAnimation(motherData.anim[0]);
        Baby.instance.PlayAnimation("Father holding baby idle");
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
            Baby.instance.PlayAnimation("baby standing idle with father");
            StartCoroutine(Masseuse.instance.Action1());
            yield return new WaitForSeconds(9);
            PlayAnimation(motherData.anim[0]);
            Baby.instance.PlayAnimation("Father holding baby idle");
            agent.SetDestination(motherData.movepoints[0].position);
            yield return new WaitForSeconds(14);
            Destroy(parent);
        }
    }
    public void PlayAnimation(string anim)
    {
        mother.animator.Play(anim);
    }

    public IEnumerator HaircutMovement(GameObject parent, MotherNPC motherData, NavMeshAgent agent)
    {
        agent.SetDestination(motherData.movepoints[4].position);
        yield return new WaitForSeconds(11.5f);
        PlayAnimation(motherData.anim[8]);
        StartCoroutine(Baby.instance.Haircut1()); 
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
        StartCoroutine(Baby.instance.HairDone1());
        yield return new WaitForSeconds(3);
        PlayAnimation(motherData.anim[0]);
        agent.SetDestination(motherData.movepoints[3].position);
        yield return new WaitForSeconds(9.5f);
        parent.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        PlayAnimation(motherData.anim[7]);
        Baby.instance.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        PlayAnimation(motherData.anim[0]);
        Baby.instance.PlayAnimation("Father holding baby idle");
        agent.SetDestination(motherData.movepoints[0].position);
        yield return new WaitForSeconds(14);
        Destroy(parent);
    }

    public void RemoveChild(GameObject prefab)
    {
        Transform childTransform = prefab.transform.Find("Baby_with_Mother_Anim"); // Replace "ChildObjectName" with the actual name of your child object

        if (childTransform != null)
        {
            childTransform.parent = null;
        }
        else
        {
            Debug.LogError("Child object not found!");
        }
    }

    public void AddChild(GameObject prefab)
    {
        Transform childTransform = GameObject.Find("Baby_with_Mother_Anim").transform; // Replace "ChildObjectName" with the actual name of your child object
                                                                                       // Replace "ChildObjectName" with the actual name of your child object

        if (childTransform != null)
        {
            childTransform.parent = prefab.transform;
        }
        else
        {
            Debug.LogError("Child object or new parent object not found!");
        }
    }
}
