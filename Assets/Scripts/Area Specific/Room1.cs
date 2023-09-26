using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
 

public class Room1 : MonoBehaviour
{
    public static Room1 instance; 
    public int totalHires;

    public Button hireButton;
    public Button buyChair;
    public Button buyTv; 

    public float hireCost;
    public TMP_Text hireText; 


    public List<GameObject> UpgradeUIpanels; 

    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    public bool hasUI; 

    public Button closeButton;

    public TMP_Text totalHires_text;

    public GameObject chair;
    public GameObject tv;


    void Start()
    {
        instance = this; 
        hireText.text = hireCost.ToString();
        //hireButton.onClick.AddListener(OnNewHire);
        closeButton.interactable = false;
        closeButton.onClick.AddListener(CloseButtonClick);
        buyChair.onClick.AddListener(Chair);
        buyTv.onClick.AddListener(TV);
    }

    public void OnMouseDown()
    {
        //StartCoroutine(CameraZoomIn());
    }

    //public IEnumerator CameraZoomIn()
    //{
    //    Debug.Log(roomName);
    //        Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
    //        Camera.main.DOOrthoSize(zoomSize, 1f);
    //        yield return 1f;
    //        closeButton.interactable = true;
    //        switch (roomName)
    //        { 
    //            case Departments.WaterTaining:
    //                break;
    //            case Departments.Massage:
    //                Room1.instance.UpgradeUIpanels[1].transform.DOLocalMoveY(UpgradeUIpanels[1].transform.localPosition.y + 600, 1f);
    //                hasUI = true;
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
    //    //if (Camera.main.transform.position != camPos.localPosition)
    //    //{
    //    //    //hasUI = true;
    //    //    }
    //    }


    //}
    public void UpdateValues(Departments room)
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        totalHires_text.text = totalHires.ToString();
        switch (room)
        { 
            case Departments.WaterTaining:
                PlayerPrefs.SetInt("Trainer", totalHires);
                break;
            case Departments.Massage:
                PlayerPrefs.SetInt("Masseuse", totalHires);

                break;
            case Departments.Haircut:
                PlayerPrefs.SetInt("Dresser", totalHires);

                break;
            case Departments.Pamper:
                PlayerPrefs.SetInt("Nurse", totalHires);

                break;
            case Departments.Playroom:
                PlayerPrefs.SetInt("Nanny", totalHires);

                break;
            case Departments.PhotoRoom:
                PlayerPrefs.SetInt("Photographer", totalHires);

                break;
            case Departments.Cafeteria:
                PlayerPrefs.SetInt("Waiters", totalHires);

                break;
        }
    }
    public void CamZoom()
    {
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.75f);
        }
    }

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalBalance_hard.ToString(); 
    }

    //public void OnNewHire()
    //{
    //    if (totalHires == 0)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName); 
    //        }
    //    }
    //    else if (totalHires == 1)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName);
    //        }
    //    }
    //    else
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName);
    //            hireButton.interactable = false;
    //        }
    //    }
    //}

    //public void UpgradeClick()
    //{
    //    startLevel++;
    //    costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
    //    incomePerLevel += income_Increase;
    //    //incomePerLevel += incomePerLevel * (income_Increase / 100);
    //    costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
    //    incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
    //    Debug.Log("Cost " + startLevel + ": " + costPerLevel);
    //    Debug.Log("Income " + startLevel + ": " + incomePerLevel);
    //}

    public void CloseButtonClick()
    {
        Debug.Log("Close click");
        //if (Room1.instance.hasUI == true)
        //{
                    Debug.Log("move down");
            Room1.instance.closeButton.interactable = false;

            Room1.instance.hasUI = false;
        ResetPanels();
            //Room.instance.UpgradePanel.transform.DOLocalMoveY(Room.instance.UpgradePanel.transform.localPosition.y - 600, 1f);
            //switch (Room1.instance.roomName)
            //{
            //    case Departments.Reception:
            //        Room1.instance.UpgradeUIpanels[0].transform.DOLocalMoveY(-600, 1f);
            //        break;
            //    case Departments.WaterTaining:
            //        break;
            //    case Departments.Massage:
            //        Room1.instance.UpgradeUIpanels[1].transform.DOLocalMoveY(-600, 1f);
            //        break;
            //    case Departments.Haircut:

            //        break;
            //    case Departments.Pamper:

            //        break;
            //    case Departments.Playroom:

            //        break;
            //    case Departments.PhotoRoom:

            //        break;
            //    case Departments.Cafeteria:

            //        break;
            //}
        //}

    }

    public void ResetPanels()
    {
        for(int i =0; i < UpgradeUIpanels.Count; i++)
        {
            Room1.instance.UpgradeUIpanels[0].transform.DOLocalMoveY(-1422, 1f); 
        }
    }

    public void Chair()
    {
        chair.SetActive(true);
        //GameManager.instance.totalBalance_hard -= 25;
        CanvasManager.instance.totalBalanceHard_text.text = 25.ToString();
        //UpdateHard();
    }
    public void TV()
    {
        tv.SetActive(true);
        //GameManager.instance.totalBalance_hard -= 25;
        CanvasManager.instance.totalBalanceHard_text.text = 0.ToString();

        //UpdateHard();
    }
}
