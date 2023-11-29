using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

    public enum Departments
    {
        WaterTraining,
        Massage,
        Haircut,
        Pamper,
        Playroom,
        PhotoRoom,
        Cafeteria,
        Cleaning,
        Bathroom,
        Parking,
        Advertisement
    }
public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public Departments roomName;

    public int serviceLevel;
    public int totalWorkers;
    public float serviceCost =2;
    public Transform camPos; 
    public int zoomSize;
    public bool hasUI;
    public Button closeButton; 
    public List<GameObject> UpgradeUIpanels;
    public GameObject switchServicePanel;
    public string playerPrefTag;

    public bool isUnlocked;

    public int customersServed;
    public int servicesGiven;

    public CollectTip tip;

    public Specialist worker; 

    public IService service;

    public List<WorkerNPC> workerList;

    public WaitingQueue waiting;

    void Start()
    {
        //serviceLevel = 1;
        instance = this;
        closeButton.onClick.AddListener(CloseButtonClick);
        //LoadData();
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
        //Tutorial.instance.MassageClick(); 
    }
    private void Update()
    {
        if (customersServed == 5)
        {
            tip.OnEnable();
        }
    } 

    public WorkerNPC CheckForService()
    {
        WorkerNPC availableService = null;
        for (int i = 0; i < workerList.Count; i++)
        {
            if (workerList[i].isAvailable && workerList[i].isUnlocked)
            {
                availableService = workerList[i];
            }
        }
        availableService.isAvailable = false;

        return availableService;
    }

    public bool IsServiceAvailable()
    {
        for (int i = 0; i < workerList.Count; i++)
        {
            if (workerList[i].isAvailable && workerList[i].isUnlocked)
            {
                return true;
            }
        }
        return false;
    }
    public IEnumerator CameraZoomIn()
    {
        if (CanvasManager.instance.popupObject == null && CanvasManager.instance.popupObject1 == null)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 1f);
            //yield return new WaitForSeconds(1f); 
            switch (roomName)
            {
                case Departments.WaterTraining: 
                    UpgradeUIpanels[4].GetComponent<RectTransform>().DOAnchorPosY(360, 1);
                    switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    break;
                case Departments.Massage: 
                    UpgradeUIpanels[1].GetComponent<RectTransform>().DOAnchorPosY(360, 1);
                    switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);
                    break;
                case Departments.Haircut: 
                    UpgradeUIpanels[3].GetComponent<RectTransform>().DOAnchorPosY(360, 1);
                    switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);
                    break;
                case Departments.Pamper:

                    break;
                case Departments.Playroom:

                    break;
                case Departments.PhotoRoom: 
                    UpgradeUIpanels[5].GetComponent<RectTransform>().DOAnchorPosY(360, 1);
                    switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);  
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    break;
                case Departments.Cafeteria:

                    break;
                case Departments.Parking: 
                    UpgradeUIpanels[2].GetComponent<RectTransform>().DOAnchorPosY(230, 1); 
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);

                    break;
                case Departments.Advertisement: 
                    UpgradeUIpanels[2].GetComponent<RectTransform>().DOAnchorPosY(230, 1); 
                    GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);

                    break;
            }
        }
        else
        {
            CamZoom();
        }
    }
    //public void UpdateValues(Departments room)
    //{
    //    CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
    //    totalHires_text.text = totalHires.ToString();
    //    switch (room)
    //    {
    //        case Departments.WaterTaining:
    //            PlayerPrefs.SetInt("Trainer", totalHires);
    //            break;
    //        case Departments.Massage:
    //            PlayerPrefs.SetInt("Masseuse", totalHires);

    //            break;
    //        case Departments.Haircut:
    //            PlayerPrefs.SetInt("Dresser", totalHires);

    //            break;
    //        case Departments.Pamper:
    //            PlayerPrefs.SetInt("Nurse", totalHires);

    //            break;
    //        case Departments.Playroom:
    //            PlayerPrefs.SetInt("Nanny", totalHires);

    //            break;
    //        case Departments.PhotoRoom:
    //            PlayerPrefs.SetInt("Photographer", totalHires);

    //            break;
    //        case Departments.Cafeteria:
    //            PlayerPrefs.SetInt("Waiters", totalHires);

    //            break;
    //    }
    //}
    public void CamZoom()
    {
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.75f);
        }
    } 

    public void CloseButtonClick()
    { 
        //closeButton.SetActive(false); 
        hasUI = false;
        ResetPanels();
        GetComponent<Collider>().enabled = true;

    }

    public void ResetPanels()
    {
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        { 
            UpgradeUIpanels[i].GetComponent<RectTransform>().DOAnchorPosY(-1500, 1);
            switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(-1500, 1); 
        }
        Camera.main.DOOrthoSize(25, 0.25f);
        GetComponent<Collider>().enabled = true;
        //tab.ButtonClick(0);
        //tab1.ButtonClick(0);
        //tab2.ButtonClick(0);
    }

    //public void LoadData()
    //{
    //    if (PlayerPrefs.GetInt(playerPrefTag + "_unlocked")==0) 
    //    {
    //        isUnlocked = false;
    //    }
    //    else
    //    {
    //        isUnlocked = true;
    //    }
    //}

    public void LoadSave()
    {
        if (isUnlocked)
        {

        }
    }
}
