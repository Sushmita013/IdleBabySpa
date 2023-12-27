using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Baby : MonoBehaviour
{
    public static Baby instance;

    //public bool isEngaged;

    //public float serviceDuration;
    private Animator animator;

    public bool hasClothes;
    public GameObject babyClothes;
    public GameObject bodyDiaper;
    public GameObject longHair;
    public GameObject shortHair;

    public List<GameObject> hairVar;

    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void RemoveBabyClothes()
    { 
            babyClothes.SetActive(false);
            bodyDiaper.SetActive(true);   
    }

    public void HadClothes()
    { 
        if (hasClothes)
        {
            babyClothes.SetActive(true);
            bodyDiaper.SetActive(false);
        }
        else
        {
            babyClothes.SetActive(false);
            babyClothes.SetActive(true);
        }
    }

    public IEnumerator ChangeHair(float duration)
    {
        for (int i = 0; i < hairVar.Count; i++)
        {
            longHair.SetActive(false);
            // Activate the current hair object
            hairVar[i].SetActive(true);

            // Deactivate the previous hair object (if applicable)
            if (i > 0)
            {
                hairVar[i - 1].SetActive(false);
            }

            // Wait for the specified duration
            yield return new WaitForSeconds(duration / 3);
        }

        // Deactivate the last hair object after the loop
        if (hairVar.Count > 0)
        {
            hairVar[hairVar.Count - 1].SetActive(false);
        }
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
    //public IEnumerator Massage()
    //{
    //    //PlayAnimation("father putting baby on table");
    //    yield return new WaitForSeconds(0.5f);
    //    this.gameObject.transform.localPosition = new Vector3(-0.785f, -0.1513195f, 0.473f); 
    //    this.gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0); 
    //    PlayAnimation("Take 001"); 
    //}  

    //public IEnumerator Haircut()
    //{  
    //    //PlayAnimation("Keeping baby on chair");
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.transform.localPosition = new Vector3(0.114f, -0.102f, 0.581f);
    //    //gameObject.transform.localPosition = new Vector3(-0.777f, 0.484f, 1.285f);
    //    //gameObject.transform.position = new Vector3(-30.594f, -8.353f, 11.01548f);
    //    gameObject.transform.localRotation = Quaternion.Euler(0, 20, 0);

    //} 

    //public IEnumerator MassageComplete()
    //{
    //    PlayAnimation("Father holding baby idle");
    //    gameObject.transform.localPosition = new Vector3(-1.935508f, 1.535099f, 0.925171f);
    //    gameObject.transform.localRotation = Quaternion.Euler(0, 180, 90);
    //    yield return new WaitForSeconds(0.5f); 
    //    //yield return null;
    //    gameObject.transform.localPosition = new Vector3(0.115f, -0.236f, 0.348f);
    //    gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);

    //} 

    //public IEnumerator HaircutComplete()
    //{
    //    PlayAnimation("Father holding baby idle");
    //    //gameObject.transform.localPosition = new Vector3(-1.935508f, 1.535099f, 0.925171f);
    //    //gameObject.transform.localRotation = Quaternion.Euler(0, 180, 90);
    //    yield return new WaitForSeconds(0.5f); 
    //    //yield return null;
    //    gameObject.transform.localPosition = new Vector3(0.115f, -0.236f, 0.348f);
    //    gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);

    //} 

    public void PlayAnimation(string animation)
    { 
        this.animator.Play(animation); 
    }
}
