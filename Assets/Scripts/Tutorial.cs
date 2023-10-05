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
        ResetHands();
        hands[0].SetActive(true);
        instance = this;
        //hand.transform.position= new Vector3(15,800,0);
        Camera.main.GetComponent<PanZoom>().enabled = false;
    }  

    public void MassageBuilt()
    { 
        ResetHands();
        hands[1].SetActive(true);
    }

    public void MassageComplete()
    {
        ResetHands();
        hands[2].SetActive(true);
    }

    public void GetReward()
    {
        ResetHands();
        hands[3].SetActive(true);
    }
    public void CollectedReward()
    {
        ResetHands();
        hands[0].SetActive(true);
    }

    public void ReceptionBuild()
    {
        ResetHands();
           hands[1].SetActive(true);
        Camera.main.transform.DOLocalMove(new Vector3(-140,60,-55), 0.75f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(20, 0.75f);
    }

    public void ParkingBuild()
    {
        ResetHands(); 
        hands[1].SetActive(true);
    }

    public void BillboardBuild()
    {
        ResetHands();
        hands[0].SetActive(true);
    } 

    public void ReceptionDone()
    {
        hands[1].SetActive(false);
        hands[0].SetActive(true);
    }

    public void ResetHands()
    {
        foreach (GameObject item in hands)
        {
            item.SetActive(false);
        }
    }
}
