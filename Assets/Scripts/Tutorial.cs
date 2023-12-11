using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> hands;

    public GameObject upgradeHand;

    public RoomManager massageRoom;
    public RoomManager parking;
    public RoomManager advertisement;

    public Reception reception;

    public GameObject carManager;

    public List<Button> unlockButtons;

    public Button massageButton;
    public Button parkingButton;
    public Button advertisementButton; 

    //public List<GameObject> colliders;
    //public static Tutorial instance;

    //public GameObject massagePanel;
    //public GameObject interiorPanel;

    //public GameObject interiorHand;
    //public GameObject interiorHand1;

    private void Update()
    {
        if (TaskManager.Instance.CurrentTaskNo == 0 && !reception.isUnlocked)
        {
            foreach (Button item in unlockButtons)
            {
                item.interactable = false;
            }
            Camera.main.GetComponent<PanZoom>().enabled = false;
            Camera.main.transform.position = new Vector3(-140f, 60, -47f);
            Camera.main.orthographicSize = 25;
            ActivateHand(0);
            massageButton.interactable = false;
            parkingButton.interactable = false;
            advertisementButton.interactable = false;
        }
        if (TaskManager.Instance.CurrentTaskNo == 1 && !massageRoom.isUnlocked)
        {
            Camera.main.transform.DOMove(new Vector3(-130, 60, -80),2f);
            Camera.main.orthographicSize = 25;
            ActivateHand(1);
            upgradeHand.SetActive(false);
            massageButton.interactable = true; 
        }
        if (TaskManager.Instance.CurrentTaskNo == 2 && !parking.isUnlocked)
        {
            Camera.main.transform.DOMove(new Vector3(-140, 60, -15),2f);
            Camera.main.orthographicSize = 25;
            ActivateHand(2);
            upgradeHand.SetActive(false); 
            parkingButton.interactable = true; 
        }
        if (TaskManager.Instance.CurrentTaskNo == 3 && !advertisement.isUnlocked)
        {
            Camera.main.transform.DOMove(new Vector3(-140, 60, -48),2f);
            Camera.main.orthographicSize = 20;
            ActivateHand(3);
            upgradeHand.SetActive(false); 
            advertisementButton.interactable = true;
        }
        if (TaskManager.Instance.CurrentTaskNo == 4)
        {
            Camera.main.GetComponent<PanZoom>().enabled = true; 
            carManager.SetActive(true);
            ActivateHand(1);
            upgradeHand.SetActive(true);
            foreach (Button item in unlockButtons)
            {
                item.interactable = true;
            }
        }
        if (TaskManager.Instance.CurrentTaskNo == 4 && massageRoom.hasUI)
        {
            ResetHands();
            upgradeHand.SetActive(true); 
        }
        if (massageRoom.serviceLevel > 2)
        {
            ResetHands(); 
            upgradeHand.SetActive(false); 
        }
        if (CanvasManager.instance.popupObject != null)
        {
            ResetHands(); 
        }
        if (TaskManager.Instance.CurrentTaskNo > 4)
        {
            ResetHands();
            upgradeHand.SetActive(false); 
        }
    } 

    void ActivateHand(int i)
    { 
        for (int j = 0; j < hands.Count; j++)
        {
            if (j == i)
            {
                hands[j].SetActive(true);
            }
            else
            {
                hands[j].SetActive(false);
            }
        }
    }

    void ResetHands()
    {
        foreach (GameObject item in hands)
        {
            item.SetActive(false);
        }
    } 
    //public Button task2; 
    //void Start()
    //{
    //    //ResetHands();
    //    hands[0].SetActive(true);
    //    instance = this;
    //    //hand.transform.position= new Vector3(15,800,0);
    //    //Camera.main.GetComponent<PanZoom>().enabled = false;
    //    Colliders(false);
    //    task2.interactable = false;
    //}

    ////private void Update()
    ////{
    ////    if (CanvasManager.instance.taskNumber == 11 && GameManager.instance.totalHardCurrency==20)
    ////    {
    ////        interiorHand.SetActive(true);
    ////        //interiorHand1.SetActive(true);
    ////        if (massagePanel.transform.position.y > -677.7774f)
    ////        { 
    ////            if (interiorPanel.activeSelf)
    ////            { 
    ////                InteriorGet();
    ////            }
    ////            else
    ////            { 
    ////                InteriorBuy();
    ////            }
    ////        }
    ////        else
    ////        { 
    ////            InteriorClick();
    ////        }
    ////    }
    ////    else
    ////    {
    ////        interiorHand.SetActive(false);
    ////        interiorHand1.SetActive(false);
    ////    }
    ////}

    //private void Update()
    //{
    //    if (CanvasManager.instance.taskNumber == 11 && GameManager.instance.totalHardCurrency == 20)
    //    { 
    //            if (interiorPanel.activeSelf)
    //            {
    //                InteriorGet();
    //            }
    //            else
    //            {
    //                InteriorBuy();
    //            } 
    //    }
    //    else
    //    {
    //        interiorHand.SetActive(false);
    //        interiorHand1.SetActive(false);
    //    }
    //}

    //public void BuildClick()
    //{
    //    hands[0].SetActive(false);
    //    Destroy(hands[0]);
    //    hands.Remove(hands[0]);
    //    ResetHands();
    //    //hands[0].SetActive(true);
    //}

    //public void MassageComplete()
    //{
    //    //hands[1].SetActive(false);
    //    //hands.Remove(hands[1]); 
    //    hands[0].SetActive(false);
    //    //ResetHands();
    //    hands[1].SetActive(true);
    //}

    //public void GetReward()
    //{
    //    //ResetHands();
    //    hands[1].SetActive(false);
    //    Destroy(hands[1]); 
    //    hands.Remove(hands[1]);
    //    hands[1].SetActive(true);
    //}
    //public void CollectedReward()
    //{ 
    //    hands[1].SetActive(false);
    //    Destroy(hands[1]);
    //    hands.Remove(hands[1]);
    //    hands[1].SetActive(true);
    //    task2.interactable = true;
    //}

    //public void ReceptionBuild()
    //{
    //    //BuildClick();
    //    hands[1].SetActive(false);
    //    Destroy(hands[1]); 
    //    hands.Remove(hands[1]);
    //    //hands[0].SetActive(true); 
    //    Camera.main.transform.DOLocalMove(new Vector3(-140,60,-45), 0.75f).SetEase(Ease.Linear);
    //    Camera.main.DOOrthoSize(20, 0.75f);
    //}


    //public void ParkingBuild()
    //{
    //    hands[1].SetActive(false);
    //    Destroy(hands[1]); 
    //    hands.Remove(hands[1]); 
    //    //hands[0].SetActive(true);
    //}

    //public void BillboardBuild()
    //{
    //    hands[1].SetActive(true);
    //    hands[0].SetActive(false);
    //} 

    //public void ReceptionDone()
    //{
    //    hands[0].SetActive(false);
    //    hands[1].SetActive(true); 
    //}

    //public void UpgradeMassage()
    //{
    //    Colliders(true); 
    //    hands[0].SetActive(false);
    //    Destroy(hands[0]); 
    //    hands.Remove(hands[0]); 
    //    hands[0].SetActive(true);
    //    hands[1].SetActive(false);
    //}
    //public void MassageClick()
    //{
    //    hands[1].SetActive(true);
    //    hands[0].SetActive(false);
    //}
    //public void MassageUpgradeDone()
    //{
    //    hands[1].SetActive(false);
    //    Destroy(hands[1]);
    //    hands.Remove(hands[1]); 
    //}

    //public void ResetHands()
    //{
    //    foreach (GameObject item in hands)
    //    {
    //        item.SetActive(false);
    //    }
    //}

    //public void DestroyHands()
    //{
    //    foreach (GameObject item in hands)
    //    {
    //        Destroy(item.gameObject);
    //    }
    //}

    //public void UpgradeInterior()
    //{
    //    hands[0].SetActive(true);
    //}
    //public void InteriorClick()
    //{
    //    Debug.Log("InteriorClick");
    //    hands[0].SetActive(true);
    //    hands[1].SetActive(false); 
    //}
    //public void InteriorBuy()
    //{
    //    Debug.Log("InteriorBuy"); 
    //    hands[0].SetActive(false); 
    //    hands[1].SetActive(true);
    //}
    //public void InteriorGet()
    //{
    //    Debug.Log("InteriorGet"); 
    //    hands[0].SetActive(false); 
    //    hands[1].SetActive(false);
    //    hands[2].SetActive(true);
    //}

    //public void LevelClick()
    //{
    //    ResetHands();
    //    Destroy(hands[0]);
    //    Destroy(hands[1]);
    //    Destroy(hands[2]);
    //    hands.Remove(hands[0]);
    //    hands.Remove(hands[1]);
    //    hands.Remove(hands[2]); 
    //    hands[0].SetActive(true); 
    //}
    //public void LevelUpgrade()
    //{
    //    ResetHands();
    //    Destroy(hands[0]);
    //    hands.Remove(hands[0]);
    //    hands[0].SetActive(true); 
    //}

    //public void Colliders(bool enable)
    //{
    //    foreach (GameObject item in colliders)
    //    {
    //        item.GetComponent<Collider>().enabled = enable;
    //    }
    //}
}
