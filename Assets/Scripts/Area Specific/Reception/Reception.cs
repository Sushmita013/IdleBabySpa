using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;


public class Reception : MonoBehaviour
{
    public static Reception instance;
    public int totalCashiers;   

    public List<GameObject> UpgradeUIpanels;
    public List<ReceptionTab> receptionistList; 

    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    public bool hasUI;
    public bool isUnlocked;

    public GameObject closeButton; 

    public TMP_Text totalHires_text;

    public float holdTimer;

    void Start()
    {
        instance = this;
        closeButton.SetActive(false); 
        closeButton.GetComponent<Button>().onClick.AddListener(CloseButtonClick); 
    }

    private void Update()
    {
        holdTimer += Time.deltaTime; 
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
        StartCoroutine(CameraZoomIn());
    } 
    public IEnumerator CameraZoomIn()
    {  
        if (CanvasManager.instance.popupObject == null && CanvasManager.instance.popupObject1 == null)
        {
            ResetPanels();
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.3f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.3f); 
            //UpgradeUIpanels[0].transform.DOMoveY(0, 0.3f);
            UpgradeUIpanels[0].GetComponent<RectTransform>().DOAnchorPosY(225, 0.3f);
            //GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(0.3f);
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
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.3f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.3f);
        }
    }  

    public void CloseButtonClick()
    {
        closeButton.SetActive(false);
        //GetComponent<Collider>().enabled = true;
        Camera.main.DOOrthoSize(zoomSize+5, 0.3f); 
        hasUI = false;
        ResetPanels();  
    }

    public void ResetPanels()
    {
        for (int i = 0; i < UpgradeUIpanels.Count; i++)
        {
            UpgradeUIpanels[i].GetComponent<RectTransform>().DOAnchorPosY(-1500, 0.1f);
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
