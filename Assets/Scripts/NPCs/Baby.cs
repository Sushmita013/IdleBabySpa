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
    public IEnumerator Massage()
    {
        //PlayAnimation("father putting baby on table");
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.localPosition = new Vector3(-0.64f, -0.1513195f, 0.58f); 
        this.gameObject.transform.localRotation = Quaternion.Euler(0, 97, 0); 
        PlayAnimation("Take 001"); 
    }  
    
    public IEnumerator Haircut()
    {  
        //PlayAnimation("Keeping baby on chair");
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localPosition = new Vector3(-0.777f, 0.484f, 1.285f);
        //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
        gameObject.transform.localRotation = Quaternion.Euler(-82, -30, -20);

    } 
    
    public IEnumerator MassageComplete()
    { 
        yield return new WaitForSeconds(0.5f);

        //PlayAnimation("father collecting baby from table");
        gameObject.transform.localPosition = new Vector3(0.115f, -0.236f, 0.348f);
        gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);

    } 
     
    public void PlayAnimation(string animation)
    { 
        this.animator.Play(animation); 
    }
}
