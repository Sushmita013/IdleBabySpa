using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Reception : MonoBehaviour
{
    public static Reception instance;
    public int totalCashiers;   

    public List<GameObject> UpgradeUIpanels;
    public List<Cashier> cashierList;

    public List<TaskButton1> taskList;

    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    public bool hasUI;

    //public List<bool> hasUI;

    public Button closeButton;

    public TMP_Text totalHires_text;

    //public GameObject chair;
    //public GameObject tv;


    void Start()
    {
        instance = this;
        //for(int i = 0; i < hasUI.Count; i++)
        //{ 
        //hasUI[i] = false;
        //}  
        closeButton.interactable = false;
        closeButton.onClick.AddListener(CloseButtonClick); 
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
    }

    public IEnumerator CameraZoomIn()
    { 
        Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 1f);
        yield return 1f;
        closeButton.interactable = true;
        Room1.instance.UpgradeUIpanels[0].transform.DOMoveY(0, 1f); 
        hasUI = true;  
    }
    //public void UpdateValues(Departments room)
    //{
    //    CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
    //    totalHires_text.text = totalCashiers.ToString();
    //    PlayerPrefs.SetInt("Receptionist", totalCashiers);
    //}
    public void CamZoom()
    {
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 1f);
        }
    } 

    //public void OnNewHire()
    //{
    //    if (totalCashiers == 0)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalCashiers].PlayEffects());
    //            totalCashiers++; 
    //        }
    //    }
    //    else if (totalCashiers == 1)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalCashiers].PlayEffects());
    //            totalCashiers++; 
    //        }
    //    }
    //    else
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalCashiers].PlayEffects());
    //            totalCashiers++; 
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
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        {
            Room1.instance.UpgradeUIpanels[0].transform.DOLocalMoveY(-1422, 1f);
        }
    }

    //public void Chair()
    //{
    //    chair.SetActive(true);
    //    //GameManager.instance.totalBalance_hard -= 25;
    //    CanvasManager.instance.totalBalanceHard_text.text = 25.ToString();
    //    //UpdateHard();
    //}
    //public void TV()
    //{
    //    tv.SetActive(true);
    //    //GameManager.instance.totalBalance_hard -= 25;
    //    CanvasManager.instance.totalBalanceHard_text.text = 0.ToString(); 
    //    //UpdateHard();
    //}
}
