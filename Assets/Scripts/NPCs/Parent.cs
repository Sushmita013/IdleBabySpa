using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Parent : MonoBehaviour
{  
    public bool isEngaged;

    public bool isWaiting;

    public bool isWalking; 

    public float serviceDuration;

    public Animator animator;

    public List<Transform> movepoints;

    void Start()
    {
        StartCoroutine(Movement());
    } 

    public IEnumerator Movement()
    {
        yield return new WaitForSeconds(1); 
        PlayAnimation("Father holding baby walk");
        Baby.instance.PlayAnimation("Father holding baby idle");
        gameObject.transform.DOMove(movepoints[1].position, 8f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(8.05f); 
        gameObject.transform.DOMove(movepoints[2].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(1.05f); 
        gameObject.transform.DOMove(movepoints[3].position, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            RemoveChild();
            PlayAnimation("Keeping baby on table");
            StartCoroutine(Baby.instance.Service());
        });
        yield return new WaitForSeconds(6); 
            gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation("father walk");
        gameObject.transform.DOMove(movepoints[4].position, 3f).SetEase(Ease.Linear).OnComplete(() =>
        { 
            gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(3.05f); 
        PlayAnimation("Father stand to sit");
        yield return new WaitForSeconds(3); 
        PlayAnimation("Father sitting idle"); 
    }

    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    } 

    public void RemoveChild()
    {
        Transform childTransform = transform.Find("Baby"); // Replace "ChildObjectName" with the actual name of your child object

        if (childTransform != null)
        {
            childTransform.parent = null;
        }
        else
        {
            Debug.LogError("Child object not found!");
        }
    }

    public void MakeChild()
    {
        Transform childTransform = transform.Find("Baby"); // Replace "ChildObjectName" with the actual name of your child object
         
        if (childTransform != null && gameObject.transform != null)
        { 
            childTransform.parent = gameObject.transform;
        }
        else
        {
            Debug.LogError("Child object or new parent not found!");
        }
    }
}
