using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using DG.Tweening;

public class Masseuse : MonoBehaviour
{
    public static Masseuse instance;
     
    public Button keepBabyButton;
    public Button massageButton;
    public Button takingBabyButton;

    public Animator parent;
    public Animator baby;
    public Animator massage;

    public GameObject babyGO;
    public GameObject diaperGO;
    public GameObject girlGO;

    public Transform chairPoint;
    public Transform chairPoint1;

    public NavMeshAgent boy;
    public ParticleSystem hairSplash;

    void Start()
    {
        //parent = GetComponent<Animator>();
        instance = this;
        keepBabyButton.onClick.AddListener(() => StartCoroutine(Swimming()));
        massageButton.onClick.AddListener(() => StartCoroutine(Haircut()));
        //takingBabyButton.onClick.AddListener(() => StartCoroutine(Sit()));

    } 
    public IEnumerator Action4()
    {
        yield return new WaitForSeconds(3); 
        babyGO.SetActive(true); 
        PlayAnimationParent("Keeping baby on table");
        PlayAnimationBaby("keep baby on table");
        yield return new WaitForSeconds(4f);
        //diaperGO.SetActive(false);
        babyGO.transform.DOScale(new Vector3(3f, 3f, 3f), 0.1f);
        babyGO.transform.localPosition = new Vector3(32.5f, -0.586f, 20.2f);
        //girlGO.SetActive(false);
        //yield return new WaitForSeconds(2f);
        //PlayAnimationParent("standing idle");
        //StartCoroutine(Action5());
        PlayAnimationParent("walking");
        PlayAnimationBaby("baby on table idle");
        PlayAnimationMassage("Taking oil");
        boy.SetDestination(chairPoint.position);
        yield return new WaitForSeconds(1.25f);
        girlGO.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.1f);
        PlayAnimationParent("Stand to sit");
        yield return new WaitForSeconds(2.5f);
        PlayAnimationParent("Sitting idle without baby");
        PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(15);
        PlayAnimationParent("Sit to stand");
        yield return new WaitForSeconds(1.5f);
        PlayAnimationParent("walking"); 
        boy.SetDestination(chairPoint1.position);
        yield return new WaitForSeconds(1.5f); 
        PlayAnimationMassage("standing idle");
        girlGO.transform.DORotate(new Vector3(0, 90, 0), 0.1f); 
        ////girlGO.SetActive(true);
        diaperGO.SetActive(true);
        babyGO.transform.DOScale(new Vector3(2f, 2f, 2f), 0.1f);
        babyGO.transform.localPosition = new Vector3(32.757f, 0.203f, 20.75f);
        PlayAnimationParent("taking baby from table");
        PlayAnimationBaby("take baby from table");
        yield return new WaitForSeconds(4);
        //gameObject.transform.DORotate(new Vector3(0, -90, 0), 0.1f);
        //gameObject.transform.position = new Vector3(-69.3f, -8.08f, 17.3f);
        babyGO.transform.localPosition = new Vector3(32.532f, 0.203f, 21); 
        PlayAnimationParent("standing idle with baby");
        PlayAnimationBaby("standing idle");

    }

    public IEnumerator Haircut()
    {
        yield return new WaitForSeconds(3);
        PlayAnimationParent("keeping baby on chair");
        PlayAnimationBaby("Keeping baby on chair");
        yield return new WaitForSeconds(4f);
        PlayAnimationBaby("baby on chair idle");
        PlayAnimationParent("walking");
        PlayAnimationMassage("Haircut"); 
        boy.SetDestination(chairPoint.position);
        hairSplash.Play();
        hairSplash.playbackSpeed = 0.25f;
        yield return new WaitForSeconds(3f);
        girlGO.transform.DOLocalRotate(new Vector3(0, -180, 0), 0.1f);
        PlayAnimationParent("Stand to sit");
        //hairSplash.Play(); 
        yield return new WaitForSeconds(1.5f); 
        PlayAnimationParent("Sitting idle without baby");
        //hairSplash.Play(); 
        yield return new WaitForSeconds(15);
        PlayAnimationParent("Sit to stand");
        //hairSplash.Play(); 
        yield return new WaitForSeconds(1.5f);
        PlayAnimationParent("walking");
        boy.SetDestination(chairPoint1.position);
        yield return new WaitForSeconds(3);
        hairSplash.Stop(); 
        PlayAnimationMassage("standing idle"); 
        girlGO.transform.DORotate(new Vector3(0, 0, 0), 0.1f); 
        PlayAnimationParent("taking baby from chair");
        PlayAnimationBaby("baby going with parent from chair");
        yield return new WaitForSeconds(4);
        PlayAnimationParent("standing idle with baby");
        PlayAnimationBaby("standing idle");
    }
    public IEnumerator Swimming()
    {
        yield return new WaitForSeconds(3);
        PlayAnimationParent("Keeping baby in watertank");
        PlayAnimationBaby("keeping baby in watertank");
        yield return new WaitForSeconds(4f);
        babyGO.transform.DOScale(new Vector3(3f, 3f, 3f), 0.1f);
        babyGO.transform.localPosition = new Vector3(34.5f, -0.45f, 25.2f);
        babyGO.transform.DOLocalRotate(new Vector3(0, -130, 0), 0.1f); 
        PlayAnimationBaby("baby in watertank idle"); 
        PlayAnimationParent("standing idle");
        hairSplash.Play();
        //yield return new WaitForSeconds(10);
        //babyGO.transform.DOScale(new Vector3(2f, 2f, 2f), 0.1f); 
        //PlayAnimationParent("taking baby from watertank");
        //PlayAnimationBaby("baby going back with parent");

    }
    public IEnumerator Action5()
    { 
        girlGO.transform.DOLocalRotate(new Vector3(0, -40, 0), 0.1f);
        yield return new WaitForSeconds(0.1f);
        PlayAnimationParent("walking");
        girlGO.transform.DOMove(chairPoint.position, 1f);
        yield return new WaitForSeconds(1);
        girlGO.transform.DOLocalRotate(new Vector3(0, -230, 0), 0.1f);
        yield return new WaitForSeconds(0.1f);
        PlayAnimationParent("Stand to sit");
        yield return new WaitForSeconds(2); 

    }



    public void PlayAnimationParent(string animation)
    {
        parent.Play(animation); 
    }
    public void PlayAnimationBaby(string animation)
    {
        baby.Play(animation); 
    }
    public void PlayAnimationMassage(string animation)
    {
        massage.Play(animation); 
    } 
}
