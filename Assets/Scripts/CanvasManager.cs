using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public TMP_Text totalBalance_text;
    public TMP_Text totalBalanceHard_text;

    //public Button closeButton;

    private Vector3 panelPos;
     
    void Start()
    {
        instance = this;
        //closeButton.interactable = false;
        panelPos = new Vector3(0, 6.103516e-05f, 0);
        totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        totalBalanceHard_text.text = GameManager.instance.totalBalance_hard.ToString();
        //closeButton.onClick.AddListener(CloseButtonClick);
    }
     
    //public void CloseButtonClick()
    //{
    //    Debug.Log("Close click");
    //    if(Room1.instance.hasUI == true )
    //    {
    //        Debug.Log("move down");
    //        Room1.instance.hasUI = false;
    //        closeButton.interactable = false; 
    //        //Room.instance.UpgradePanel.transform.DOLocalMoveY(Room.instance.UpgradePanel.transform.localPosition.y - 600, 1f);
    //        switch (Room1.instance.roomName)
    //        {
    //            case Departments.Reception:
    //                Room1.instance.UpgradeUIpanels[0].transform.DOLocalMoveY(Room1.instance.UpgradeUIpanels[0].transform.localPosition.y - 600, 1f);

    //                break;
    //            case Departments.WaterTaining:
    //                break;
    //            case Departments.Massage:
    //                Room1.instance.UpgradeUIpanels[1].transform.DOLocalMoveY(Room1.instance.UpgradeUIpanels[1].transform.localPosition.y - 600, 1f);

    //                break;
    //            case Departments.Haircut:

    //                break;
    //            case Departments.Pamper:

    //                break;
    //            case Departments.Playroom:

    //                break;
    //            case Departments.PhotoRoom:

    //                break;
    //            case Departments.Cafeteria:

    //                break;
    //        }
    //    }
    //} 

    }

