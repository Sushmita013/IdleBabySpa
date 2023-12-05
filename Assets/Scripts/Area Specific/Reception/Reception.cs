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

    //public List<TaskButton1> taskList;
    //public TaskButton buildTask;
    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    public bool hasUI;
    public bool isUnlocked;

    public GameObject closeButton; 

    public TMP_Text totalHires_text; 

    void Start()
    {
        instance = this;
        closeButton.SetActive(false); 
        closeButton.GetComponent<Button>().onClick.AddListener(CloseButtonClick); 
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn());
    } 
    public IEnumerator CameraZoomIn()
    {
        if (CanvasManager.instance.popupObject == null && CanvasManager.instance.popupObject1 == null)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.75f);
            //yield return new WaitForSeconds(1f); 
            UpgradeUIpanels[0].transform.DOMoveY(0, 1f);
            UpgradeUIpanels[0].GetComponent<RectTransform>().DOAnchorPosY(225, 1);
            //GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(0.75f);
            hasUI = true;
            closeButton.SetActive(true);
        }
        else
        {
            CamZoom();
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
        closeButton.SetActive(false);
        //GetComponent<Collider>().enabled = true; 
        hasUI = false;
        ResetPanels();  
    }

    public void ResetPanels()
    {
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        {
            UpgradeUIpanels[i].GetComponent<RectTransform>().DOAnchorPosY(-1500, 1);
        }
    } 
}
