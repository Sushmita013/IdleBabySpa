using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamSwitch : MonoBehaviour
{
    public Departments department;
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
        Debug.Log(Room1.instance.roomName);
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 1f);
            yield return 1f;
            switch (Room1.instance.roomName)
            { 
                case Departments.WaterTaining:
                    break;
                case Departments.Massage:
                    Room1.instance.UpgradeUIpanels[1].transform.DOLocalMoveY(0, 1f);
                    Room1.instance.closeButton.interactable = true; 
                    break;
                case Departments.Haircut:

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
    }

    public void CamZoom()
    {
        if (Camera.main.transform.position != camPos.localPosition)
        {
            Camera.main.transform.DOLocalMove(camPos.localPosition, 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(zoomSize, 1f);
        }
    } 
}
