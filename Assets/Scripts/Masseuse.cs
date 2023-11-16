using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    void Start()
    {
        //parent = GetComponent<Animator>();
        instance = this;
        keepBabyButton.onClick.AddListener(() => StartCoroutine(Action4()));
        massageButton.onClick.AddListener(() => StartCoroutine(Massage()));
        //takingBabyButton.onClick.AddListener(() => StartCoroutine(Sit()));

    } 
    public IEnumerator Action4()
    {
        yield return new WaitForSeconds(3); 
        babyGO.SetActive(true); 
        PlayAnimationParent("Keeping baby on table");
        PlayAnimationBaby("keep baby on table");
        yield return new WaitForSeconds(7);
        diaperGO.SetActive(false);
        babyGO.transform.DOScale(new Vector3(3f, 3f, 3f), 0.1f);
        babyGO.transform.localPosition = new Vector3(32.5f, -0.396f, 21.5f);
        //girlGO.SetActive(false);
        yield return new WaitForSeconds(2f);
        PlayAnimationParent("standing idle");
        //StartCoroutine(Action5());
        PlayAnimationBaby("baby on table idle");
        PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(20);
        PlayAnimationMassage("standing idle"); 
        ////girlGO.SetActive(true);
        diaperGO.SetActive(true);
        babyGO.transform.DOScale(new Vector3(2f, 2f, 2f), 0.1f);
        babyGO.transform.localPosition = new Vector3(32.757f, 0.203f, 20.75f);
        PlayAnimationParent("taking baby from table");
        PlayAnimationBaby("take baby from table"); 
        yield return new WaitForSeconds(10);
        gameObject.transform.DORotate(new Vector3(0, 40, 0), 0.1f);
        gameObject.transform.position = new Vector3(-69.3f, -8.08f, 17.3f); 
        PlayAnimationParent("standing idle with baby");
        PlayAnimationBaby("standing idle"); 

    }

    public IEnumerator Massage()
    {
        yield return new WaitForSeconds(3); 
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
