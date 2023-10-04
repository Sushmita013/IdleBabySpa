using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

    public enum Departments
    {
        WaterTaining,
        Massage,
        Haircut,
        Pamper,
        Playroom,
        PhotoRoom,
        Cafeteria,
        Cleaning,
        Bathroom
    }
public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public Departments roomName;

    public int serviceLevel;
    public float serviceCost =2;
    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;
    public bool hasUI;
    public Button closeButton;

    public List<TMP_Text> level;

    public List<GameObject> UpgradeUIpanels;

    public List<TaskButton3> taskList;

    public TaskButton task;

    public GameObject room;

    void Start()
    {
        serviceLevel = 1;
        instance = this;
        closeButton.onClick.AddListener(CloseButtonClick);
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
    }

    public IEnumerator CameraZoomIn()
    {
        Debug.Log(roomName);
        Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 1f);
        yield return 1f;
        closeButton.interactable = true;
        switch (roomName)
        {
            case Departments.WaterTaining:
                break;
            case Departments.Massage:
                UpgradeUIpanels[1].transform.DOMoveY(0, 1f);
                hasUI = true;
                break;
            case Departments.Haircut:
                UpgradeUIpanels[2].transform.DOMoveY(0, 1f); 
                break;
            case Departments.Pamper:

                break;
            case Departments.Playroom:

                break;
            case Departments.PhotoRoom:

                break;
            case Departments.Cafeteria:

                break; 
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

    public void RoomUnlock()
    {
       
    }

    public void CloseButtonClick()
    {
        Debug.Log("Close click");
        //if (Room1.instance.hasUI == true)
        //{
        Debug.Log("move down");
        closeButton.interactable = false;

         hasUI = false;
        ResetPanels();  
    }

    public void ResetPanels()
    {
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        {
             UpgradeUIpanels[i].transform.DOLocalMoveY(-1500, 1f);
        }
    }
}
