using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> hands;
    public List<GameObject> colliders;
    public static Tutorial instance;

    public GameObject interiorPanel;

    public Button task2; 
    void Start()
    {
        //ResetHands();
        hands[0].SetActive(true);
        instance = this;
        //hand.transform.position= new Vector3(15,800,0);
        Camera.main.GetComponent<PanZoom>().enabled = false;
        Colliders(false);
        task2.interactable = false;
    }

    private void Update()
    {
        if (CanvasManager.instance.taskNumber == 11)
        {
            if (interiorPanel.activeSelf)
            {
                InteriorBuy();
            }
            else
            {
                InteriorClick();
            }
        }
    }

    public void BuildClick()
    {
        hands[0].SetActive(false);
        Destroy(hands[0]);
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
        Destroy(hands[1]); 
        hands.Remove(hands[1]);
        hands[1].SetActive(true);
    }
    public void CollectedReward()
    { 
        hands[1].SetActive(false);
        Destroy(hands[1]);
        hands.Remove(hands[1]);
        hands[1].SetActive(true);
        task2.interactable = true;
    }

    public void ReceptionBuild()
    {
        //BuildClick();
        hands[1].SetActive(false);
        Destroy(hands[1]); 
        hands.Remove(hands[1]);
        hands[0].SetActive(true); 
        Camera.main.transform.DOLocalMove(new Vector3(-140,60,-45), 0.75f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(20, 0.75f);
    }
     

    public void ParkingBuild()
    {
        hands[1].SetActive(false);
        Destroy(hands[1]); 
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
        Colliders(true); 
        hands[0].SetActive(false);
        Destroy(hands[0]); 
        hands.Remove(hands[0]); 
        hands[0].SetActive(true);
        hands[1].SetActive(false);
    }
    public void MassageClick()
    {
        hands[1].SetActive(true);
        hands[0].SetActive(false);
    }
    public void MassageUpgradeDone()
    {
        hands[1].SetActive(false);
        Destroy(hands[1]);
        hands.Remove(hands[1]); 
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

    public void UpgradeInterior()
    {
        hands[0].SetActive(true);
    }
    public void InteriorClick()
    {
        Debug.Log("InteriorClick");
        hands[0].SetActive(false);
        hands[1].SetActive(true);
    }
    public void InteriorBuy()
    {
        Debug.Log("InteriorBuy"); 
        hands[1].SetActive(false);
        hands[2].SetActive(true);
    }

    public void Colliders(bool enable)
    {
        foreach (GameObject item in colliders)
        {
            item.GetComponent<Collider>().enabled = enable;
        }
    }
}
