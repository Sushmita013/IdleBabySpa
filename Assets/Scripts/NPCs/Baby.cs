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

    //public IEnumerator Service()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.15f);
    //    //gameObject.transform.position = new Vector3(-33.3f, -6.2f, 12.5f);
    //    gameObject.transform.DOMove(new Vector3(-33.3f, -6.2f, 12.5f), 0.05f).SetEase(Ease.Linear).OnComplete(() =>
    //    {
    //        //gameObject.transform.DORotate(new Vector3(0, 90, -90), 0.05f);
    //        gameObject.transform.rotation = Quaternion.Euler(0, 90, -90);
    //        PlayAnimation("baby on table");
    //    });
    //}
    public IEnumerator Service()
    {
        PlayAnimation("father putting baby on table");
        yield return new WaitForSeconds(2.5f);
        gameObject.transform.position = new Vector3(-31.591f, -8.248f, 9.341f);
        //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); 
        PlayAnimation("Take 001");
        yield return new WaitForSeconds(2.5f);


        //gameObject.transform.DOMove(new Vector3(-30.594f, -8.353f, 11.01548f), 0.05f).SetEase(Ease.Linear).OnComplete(() =>
        //    { 
        //    });

    }  
    
    public IEnumerator Haircut()
    {  
        PlayAnimation("Keeping baby on chair");
        yield return new WaitForSeconds(2);
        gameObject.transform.position = new Vector3(-25.774f, -7.796f, 40.797f);
        //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
        gameObject.transform.rotation = Quaternion.Euler(0, -82, 0);

    }
    public IEnumerator Haircut1()
    {
        gameObject.transform.position = new Vector3(-26.687f, -8.095f, 41.311f); 
        PlayAnimation("Keeping baby on chair");
        yield return new WaitForSeconds(2);
        gameObject.transform.position = new Vector3(-25.774f, -7.796f, 40.797f);
        //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
        gameObject.transform.rotation = Quaternion.Euler(0, -82, 0);

    }
    public IEnumerator HairDone()
    {
        yield return new WaitForSeconds(0);
        PlayAnimation("Lifting baby from chair");
        yield return new WaitForSeconds(3);
        gameObject.transform.localPosition = new Vector3(0.115f, -0.458f, -0.076f);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0); 
    }
    public IEnumerator HairDone1()
    {
        yield return new WaitForSeconds(0);
        PlayAnimation("Lifting baby from chair");
        yield return new WaitForSeconds(3);
        gameObject.transform.localPosition = new Vector3(0.578f, -0.458f, -0.076f);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0); 
    }



    public IEnumerator Service1()
    { 
        gameObject.transform.DOMove(new Vector3(-30.758f, -8.279f, 11.39f), 0.25f).SetEase(Ease.Linear); 
        gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        yield return new WaitForSeconds(0.75f); 
        PlayAnimation("father putting baby on table");
        //gameObject.transform.DOMove(new Vector3(-30.594f, -8.35348f, 11.01548f), 0.25f).SetEase(Ease.Linear); 
        //gameObject.transform.position = new Vector3(-30.594f, -8.35348f, 11.01548f);

        //gameObject.transform.DORotate(new Vector3(0, 0, 0), 1f);
        //gameObject.transform.rotation = Quaternion.Euler(0, -90, 0); 
        yield return new WaitForSeconds(3f);
        gameObject.transform.position = new Vector3(-31.591f, -8.248f, 9.341f);
        //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); 
        PlayAnimation("Take 001");  
        //gameObject.transform.DOMove(new Vector3(-30.594f, -8.353f, 11.01548f), 0.05f).SetEase(Ease.Linear).OnComplete(() =>
        //    { 
        //    });

    } 
    
    public IEnumerator Pickup()
    { 
        yield return new WaitForSeconds(1.5f);

        gameObject.transform.position = new Vector3(-30.546f, -8.248f, 11.069f);
        gameObject.transform.rotation = Quaternion.Euler(0, -82, 0);
        PlayAnimation("father collecting baby from table");

    } 
    public IEnumerator Pickup1()
    {
        yield return null;

        gameObject.transform.position = new Vector3(-32.98f, -8.248f, 10.27f);
        gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0); 
        PlayAnimation("mom collecting baby from table");
        yield return new WaitForSeconds(3f); 
        gameObject.transform.localPosition = new Vector3(0.162f, -0.458f, 0.73f);
        gameObject.transform.localRotation = Quaternion.Euler(0, -82, 0);

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
