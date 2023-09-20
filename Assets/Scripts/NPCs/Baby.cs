using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
  

public class Baby : MonoBehaviour
{
    public static Baby instance; 

    public bool isEngaged;

    public float serviceDuration;
    public Animator animator;


    void Start()
    {
        instance = this;
    animator = GetComponent<Animator>(); 
    }

    public IEnumerator Service()
    {
        yield return new WaitForSeconds(2.5f);
        //gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.15f);
        //gameObject.transform.position = new Vector3(-33.3f, -6.2f, 12.5f);
        gameObject.transform.DOMove(new Vector3(-33.3f, -6.2f, 12.5f), 0.05f).SetEase(Ease.Linear).OnComplete(() =>
        {
            //gameObject.transform.DORotate(new Vector3(0, 90, -90), 0.05f);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, -90);
            PlayAnimation("baby on table");
        });
    }

    public void PlayAnimation(string animation)
    {
        //if (isEngaged)
        //{
        //    anim.Play(animation);
        //    serviceDuration -= Time.deltaTime;

        //    // If the duration is less than or equal to 0, stop the animation
        //    if (serviceDuration <= 0)
        //    {
        //        animator.speed = 0; // Pause the animation
        //                            // You can also add any other logic you want to perform when stopping the animation here
        //    }
        //}
        //else
        //{
        //    anim.Stop(animation);
        //}
        animator.Play(animation);

    }
}
