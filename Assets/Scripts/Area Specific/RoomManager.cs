using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;


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
    public Departments roomName;

    public int serviceLevel;
    //public int totalWorkers;
    public float serviceCost; 
    public Transform camPos; 
    public int zoomSize;
    public bool hasUI;
    public Button closeButton; 
    public List<GameObject> UpgradeUIpanels;
    public GameObject switchServicePanel; 

    public bool isUnlocked;

    public int customersServed; 

    public CollectTip tip;

    public Specialist worker; 

    public IService service;

    public List<WorkerNPC> workerList;

    public List<int> workerIndex;

    public WaitingQueue waiting;

    public Interior interior;

    public float holdTimer;

    void Start()
    {  
        LoadData();
        if (roomName == Departments.Advertisement)
        {
             StartCoroutine(CarManager.instance.InstantiateRandomCars()); 
        }
    } 

    private void OnMouseDown()
    {
        holdTimer = 0;
    }
    public void OnMouseUpAsButton()
    {
        if (IsPointerOverUIObject() || holdTimer>0.1f)
        {
            return;
        }
        Debug.Log("mouse button up");
        StartCoroutine(CameraZoomIn()); 
    }

    private void OnEnable()
    { 
        closeButton.onClick.RemoveAllListeners(); 
        closeButton.onClick.AddListener(CloseButtonClick); 
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveAllListeners(); 
    }
    private void Update()
    {
        holdTimer += Time.deltaTime;

        if (customersServed == 2)
        { 
            tip.gameObject.SetActive(true);
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
                availableService.isAvailable = false; 
                break;
            }
        }

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
            Camera.main.DOOrthoSize(zoomSize, 1f).SetEase(Ease.Linear);
            ResetPanels();
            //yield return new WaitForSeconds(1f); 
            switch (roomName)
            {
                case Departments.WaterTraining:  
                    UpgradeUIpanels[4].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[4].GetComponentInChildren<Tabs2>().ButtonClick(0);

                    //switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    break;
                case Departments.Massage: 
                    UpgradeUIpanels[1].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[1].GetComponentInChildren<Tabs>().ButtonClick(0);
                    //switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);
                    break;
                case Departments.Haircut: 
                    UpgradeUIpanels[3].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[3].GetComponentInChildren<Tabs1>().ButtonClick(0); 
                    //switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);
                    break;
                case Departments.Pamper:

                    break;
                case Departments.Playroom:

                    break;
                case Departments.PhotoRoom: 
                    UpgradeUIpanels[5].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[5].GetComponentInChildren<Tabs3>().ButtonClick(0);

                    //switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(230, 1);  
                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    break;
                case Departments.Cafeteria:

                    break;
                case Departments.Parking: 
                    UpgradeUIpanels[2].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[2].GetComponentInChildren<Tabs4>().ButtonClick(0); 
                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);

                    break;
                case Departments.Advertisement: 
                    UpgradeUIpanels[2].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
                    UpgradeUIpanels[2].GetComponentInChildren<Tabs4>().ButtonClick(1);

                    //GetComponent<Collider>().enabled = false;
                    yield return new WaitForSeconds(1);
                    hasUI = true;
                    //closeButton.SetActive(true);

                    break;
            }
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

    public void CloseButtonClick()
    {  
       Camera.main.DOOrthoSize(zoomSize+5, 0.5f);

        hasUI = false;
        ResetPanels(); 
        if(roomName==Departments.Massage || roomName == Departments.Haircut|| roomName == Departments.WaterTraining||roomName == Departments.PhotoRoom)
        { 
        interior.SetColorFunc(interior.currentIndex);
        }
    }

    public void ResetPanels()
    {
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        { 
            UpgradeUIpanels[i].GetComponent<RectTransform>().DOAnchorPosY(-1500, 1);
            switchServicePanel.GetComponent<RectTransform>().DOAnchorPosY(-1500, 1); 
        } 
        //GetComponent<Collider>().enabled = true; 
    }

    public void LoadData()
    {
        foreach (int item in workerIndex)
        {
            workerList[item].isUnlocked = true;
        }

        if (isUnlocked && roomName!=Departments.Advertisement && roomName!=Departments.Parking)
        {
            AvailabilityManager.instance.rooms.Add(this);
        }

    }

    public void MassageZoomIn()
    {

        if (CanvasManager.instance.popupObject == null && CanvasManager.instance.popupObject1 == null)
        { 
            Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 1f).SetEase(Ease.Linear);
            ResetPanels(); 
            UpgradeUIpanels[1].GetComponent<RectTransform>().DOAnchorPosY(230, 1);
            UpgradeUIpanels[1].GetComponentInChildren<Tabs>().ButtonClick(0); 
            hasUI = true;
            //closeButton.SetActive(true);
        }
    }

            private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
