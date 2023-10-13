using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> hands;
    public static Tutorial instance;


    void Start()
    {
        //ResetHands();
        hands[0].SetActive(true);
        instance = this;
        //hand.transform.position= new Vector3(15,800,0);
        Camera.main.GetComponent<PanZoom>().enabled = false;
    }  

    public void BuildClick()
    {
        hands[0].SetActive(false);
        hands.Remove(hands[0]);
        ResetHands();
        hands[0].SetActive(true);
    }

    public void MassageComplete()
    {
        //hands[1].SetActive(false);
        //hands.Remove(hands[1]); 
        hands[0].SetActive(false);
        //ResetHands();
        hands[1].SetActive(true);
    }

    public void GetReward()
    {
        //ResetHands();
        hands[1].SetActive(false);
        hands.Remove(hands[1]);
        hands[1].SetActive(true);
    }
    public void CollectedReward()
    { 
        hands[1].SetActive(false);
        Destroy(hands[1]);
        hands.Remove(hands[1]);
        hands[1].SetActive(true);
    }

    public void ReceptionBuild()
    {
        //BuildClick();
        hands[1].SetActive(false);
        hands.Remove(hands[1]);
        hands[0].SetActive(true); 
        Camera.main.transform.DOLocalMove(new Vector3(-140,60,-45), 0.75f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(20, 0.75f);
    }
     

    public void ParkingBuild()
    {
        hands[1].SetActive(false);
        hands.Remove(hands[1]); 
        hands[0].SetActive(true);
    }

    public void BillboardBuild()
    {
        hands[1].SetActive(true);
        hands[0].SetActive(false);
    } 

    public void ReceptionDone()
    {
        hands[0].SetActive(false);
        hands[1].SetActive(true); 
    }

    public void UpgradeMassage()
    {
        hands[0].SetActive(false); 
        hands.Remove(hands[0]); 
        hands[0].SetActive(true);
        hands[1].SetActive(false);
    }
    public void MassageClick()
    {
        hands[1].SetActive(true);
        hands[0].SetActive(false);
    }

    public void ResetHands()
    {
        foreach (GameObject item in hands)
        {
            item.SetActive(false);
        }
    }

    public void DestroyHands()
    {
        foreach (GameObject item in hands)
        {
            Destroy(item.gameObject);
        }
    }
}
