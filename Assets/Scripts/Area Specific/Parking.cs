using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Parking : MonoBehaviour
{
    public Transform camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;
    void Start()
    {
        
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
