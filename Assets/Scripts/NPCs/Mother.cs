using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Mother : MonoBehaviour
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
        PlayAnimation("mom walking with baby");
        Baby.instance.PlayAnimation("with mom");
        //gameObject.transform.DOMove(movepoints[10].position, 3f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f).SetEase(Ease.Linear);
        //});
        //yield return new WaitForSeconds(2.1f);
        //gameObject.transform.DOMove(movepoints[0].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        //});
        //yield return new WaitForSeconds(1.1f);

        gameObject.transform.DOMove(movepoints[8].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(1.01f);

        gameObject.transform.DOMove(movepoints[9].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(1.01f);

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
            PlayAnimation("mom putting baby on table");
            StartCoroutine(Baby.instance.Service1());
            RemoveChild();
        });
        yield return new WaitForSeconds(6);
        //StartCoroutine(Masseuse.instance.Action());
        gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation("mom walking with baby");
        gameObject.transform.DOMove(movepoints[4].position, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(3.05f);
        PlayAnimation("stand to sit");
        yield return new WaitForSeconds(3);
        PlayAnimation("sitting idle");
        yield return new WaitForSeconds(2);
        PlayAnimation("mom walking with baby");
        yield return new WaitForSeconds(3);
        gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation("mom walking with baby");
        gameObject.transform.DOMove(movepoints[3].position, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2);
        gameObject.transform.DORotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        PlayAnimation("mom collecting baby from table");
        StartCoroutine(Baby.instance.Pickup1());
        yield return new WaitForSeconds(3);
        AddChild();
        gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.25f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.25f);
        PlayAnimation("mom walking with baby");
        Baby.instance.PlayAnimation("with mom");
        gameObject.transform.DOMove(movepoints[2].position, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(2.1f);
        gameObject.transform.DOMove(movepoints[1].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(1.1f);
        gameObject.transform.DOMove(movepoints[5].position, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(2.1f);
        gameObject.transform.DOMove(movepoints[6].position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.transform.DORotate(new Vector3(0, 90, 0), 0.1f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(1.1f);
        PlayAnimation("baby holding idle");
        Baby.instance.PlayAnimation("baby standing idle with father");
        StartCoroutine(Masseuse.instance.Action1());
        yield return new WaitForSeconds(9);
        gameObject.transform.DORotate(new Vector3(0, -90, 0), 0.1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            PlayAnimation("mom walking with baby");
            Baby.instance.PlayAnimation("with mom");
            gameObject.transform.DOMove(movepoints[7].position, 4f).SetEase(Ease.Linear);
        });
        yield return new WaitForSeconds(4.1f);
        PlayAnimation("baby holding idle");
        Baby.instance.PlayAnimation("baby standing idle with father");
    }

    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }

    public void RemoveChild()
    {
        Transform childTransform = transform.Find("Baby_with_father_Anim"); // Replace "ChildObjectName" with the actual name of your child object

        if (childTransform != null)
        {
            childTransform.parent = null;
        }
        else
        {
            Debug.LogError("Child object not found!");
        }
    }

    public void AddChild()
    {
        Transform childTransform = GameObject.Find("Baby_with_father_Anim").transform; // Replace "ChildObjectName" with the actual name of your child object

        if (childTransform != null)
        {
            childTransform.parent = transform;
        }
        else
        {
            Debug.LogError("Child object or new parent object not found!");
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
