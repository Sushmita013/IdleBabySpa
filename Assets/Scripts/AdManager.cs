using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camPos;
    private float moveSpeed = 2.0f;
    public int zoomSize;

    public GameObject keyboard;
    public Button closeButton;
    void Start()
    {
        closeButton.onClick.AddListener(OnCloseClick);
    }

    public void OnMouseDown()
    {
        CamZoom();
    }
    public void CamZoom()
    {
        keyboard.SetActive(true);
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 0.75f);
        }
    }

    public void OnCloseClick()
    {
        KeyboardManager.Instance.textBox.text += "'S";
        keyboard.SetActive(false); 
    }


}
