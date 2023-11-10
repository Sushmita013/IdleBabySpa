using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Masseuse : MonoBehaviour
{
    public static Masseuse instance;

    public Button idleBabyButton; 
    public Button walkingBabyButton;
    public Button standToSitButton;
    public Button sittingIdleButton;
    public Button sitToStandButton;

    public Animator parent;
    public Animator baby;
    public Animator massage;

    public GameObject babyGO;
    public GameObject diaperGO;
    public GameObject girlGO;

    //public Transform chairPoint;
    //public Transform chairPoint1;

    void Start()
    {
        //parent = GetComponent<Animator>();
        instance = this;
        idleBabyButton.onClick.AddListener(() => StartCoroutine(Action3()));
        walkingBabyButton.onClick.AddListener(() => StartCoroutine(Action1()));
        standToSitButton.onClick.AddListener(() => StartCoroutine(Stand()));
        sittingIdleButton.onClick.AddListener(() => StartCoroutine(sittingIdle()));
        sitToStandButton.onClick.AddListener(() => StartCoroutine(Sit()));

    }

    public IEnumerator Action()
    { 
        yield return new WaitForSeconds(0);
        PlayAnimationParent("walking");
        babyGO.SetActive(false);
    }
    public IEnumerator Action1()
    { 
        yield return new WaitForSeconds(0);
        babyGO.SetActive(true); 
        PlayAnimationParent("walking with baby");
        PlayAnimationBaby("walking with parent");
    }
    public IEnumerator Action2()
    { 
        yield return new WaitForSeconds(0);
        PlayAnimationParent("standing idle");
        babyGO.SetActive(false); 
    }
    public IEnumerator Action3()
    { 
        yield return new WaitForSeconds(0);
        babyGO.SetActive(true); 
        PlayAnimationParent("standing idle with baby");
        PlayAnimationBaby("standing idle");
    }
    public IEnumerator Stand()
    { 
        yield return new WaitForSeconds(0);
        babyGO.SetActive(true); 
        PlayAnimationParent("stand to sit with baby");
        PlayAnimationBaby("Stand to sit with parent");
    }
    public IEnumerator sittingIdle()
    { 
        yield return new WaitForSeconds(0);
        babyGO.SetActive(true); 
        PlayAnimationParent("sitting idle with baby");
        PlayAnimationBaby("sitting idle");
    }
    public IEnumerator Sit()
    { 
        yield return new WaitForSeconds(0);
        babyGO.SetActive(true); 
        PlayAnimationParent("Sit to stand with baby");
        PlayAnimationBaby("sit to stand with parent");
    }
    public IEnumerator Action4()
    {
        yield return new WaitForSeconds(3); 
        babyGO.SetActive(true); 
        PlayAnimationParent("keep baby on table");
        PlayAnimationBaby("Keeping baby on table");
        yield return new WaitForSeconds(7);
        diaperGO.SetActive(false);
        babyGO.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f);
        babyGO.transform.localPosition = new Vector3(0.15f, -0.4f, -0.15f);
        //girlGO.SetActive(false);
        yield return new WaitForSeconds(2f);
        PlayAnimationParent("standing idle"); 
        PlayAnimationBaby("Idle on table");
        PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(20);
        PlayAnimationMassage("standing idle"); 
        babyGO.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f);
        babyGO.transform.localPosition = new Vector3(0.08336895f, -0.2422223f, -0.07537505f);
        //girlGO.SetActive(true);
        diaperGO.SetActive(true);
        PlayAnimationParent("Collecting baby from table");
        PlayAnimationBaby("collecting baby from table");
        yield return new WaitForSeconds(7);

    }
    public IEnumerator Action5()
    {
        babyGO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        girlGO.transform.DORotate(new Vector3(0, 90, 0), 0.1f);
        yield return new WaitForSeconds(0.1f);
        PlayAnimationParent("walking");
        //girlGO.transform.DOMove(chairPoint.position, 1f);
        yield return new WaitForSeconds(1);
        girlGO.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
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
