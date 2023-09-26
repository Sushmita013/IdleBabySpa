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

    public Button closeButton;

    public TMP_Text totalHires_text;
     


    void Start()
    {
        instance = this;         
        closeButton.interactable = false;
        closeButton.onClick.AddListener(CloseButtonClick); 
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
    }

    public IEnumerator CameraZoomIn()
    { 
        Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 0.75f);
        yield return 1f;
        closeButton.interactable = true;
        UpgradeUIpanels[0].transform.DOMoveY(0, 1f); 
        hasUI = true;  
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
            UpgradeUIpanels[0].transform.DOLocalMoveY(-1422, 1f);
        }
    } 
}
