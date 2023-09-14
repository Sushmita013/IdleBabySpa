using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamSwitch : MonoBehaviour
{
    public Departments department;
    //public Vector3 camPos;
    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        StartCoroutine(CameraZoomIn()); 
    }

    private IEnumerator CameraZoomIn()
    {
        Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 1f);
            yield return null; 
        Room.instance.UpgradePanel.transform.DOLocalMoveY(Room.instance.UpgradePanel.transform.localPosition.y + 315, 1f);
    }  
}
