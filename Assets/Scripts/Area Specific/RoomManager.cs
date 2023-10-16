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
        Bathroom,
        Parking,
        Advertisement
    }
public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public Departments roomName;

    public int serviceLevel;
    public float serviceCost =2;
    public Transform camPos;
    private float moveSpeed = 2.0f;
    public int zoomSize;
    private bool hasUI;
    public Button closeButton; 
    public List<GameObject> UpgradeUIpanels; 

    public TaskButton task; 

    void Start()
    {
        serviceLevel = 0;
        instance = this;
        closeButton.onClick.AddListener(CloseButtonClick);
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
        Tutorial.instance.MassageClick(); 
    }

    public IEnumerator CameraZoomIn()
    {
        Debug.Log(roomName);
        Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 1f);
        //yield return new WaitForSeconds(1f); 
        switch (roomName)
        {
            case Departments.WaterTaining:
                break;
            case Departments.Massage:
                UpgradeUIpanels[1].transform.DOMoveY(0, 1f);
                yield return new WaitForSeconds(1);
                hasUI = true;
                closeButton.interactable = true;
                break;
            case Departments.Haircut:
                UpgradeUIpanels[2].transform.DOMoveY(0, 1f); 
                yield return new WaitForSeconds(1);
                hasUI = true; 
                closeButton.interactable = true;
                break;
            case Departments.Pamper:

                break;
            case Departments.Playroom:

                break;
            case Departments.PhotoRoom:

                break;
            case Departments.Cafeteria:

                break; 
            case Departments.Parking:
                UpgradeUIpanels[3].transform.DOMoveY(0, 1f);
                yield return new WaitForSeconds(1);
                hasUI = true;
                closeButton.interactable = true;
                break; 
            case Departments.Advertisement:
                UpgradeUIpanels[3].transform.DOMoveY(0, 1f);
                yield return new WaitForSeconds(1);
                hasUI = true;
                closeButton.interactable = true;
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
