using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
    public static CameraMovementManager instance;
    public GameObject referncer;
    [SerializeField] Transform cameraTra,pivot;

    Vector2 previousTouchPos = Vector2.zero;
    [SerializeField] float speed;
    [SerializeField] float zoomSpeed;

    [SerializeField] float delta = 0;
    Vector2 touch1Pos = Vector2.zero, touch2Pos = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            var touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Began)
            {
                previousTouchPos = touch1.position;
            }

            if (touch1.phase == TouchPhase.Moved)
            {
                var direction = previousTouchPos - touch1.position;
                direction = direction.normalized;

                if (direction.magnitude < 0.1f)
                    return;

                referncer.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
                transform.position += ((referncer.transform.forward * direction.y) + (referncer.transform.right * direction.x)) * Time.deltaTime * speed;

                previousTouchPos = touch1.position;

            }
        }

        if (Input.touchCount == 2)
        {
            var touch1 = Input.GetTouch(0);
            var touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Began)
            {
                delta = 0;
                touch1Pos = touch1.position;
            }

            if (touch2.phase == TouchPhase.Began)
            {
                touch2Pos = touch2.position;
                delta = Vector2.Distance(touch1Pos, touch2Pos);
            }

            touch1Pos = touch1.position;
            touch2Pos = touch2.position;
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                var currentDis = Vector3.Distance(touch1Pos, touch2Pos);
                
                if (currentDis > delta)
                    ZoomIn();
                else if (currentDis < delta)
                    ZoomOut();

                delta = currentDis;
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void MoveCameraToPos(Transform pos,Action callback=null)
    {
        var position= new Vector3(pos.position.x,0,pos.position.z);
        transform.DOMove(position, 1f).SetEase(Ease.Linear).OnComplete(()=>callback?.Invoke());
    }

    public void RotateCamera90Deg()
    {
        float value=0f;
        float finalRot=cameraTra.localEulerAngles.y+90;
        DOTween.To(() => value, x => value = x, 90f, 1f).SetEase(Ease.Linear).OnUpdate(() =>
        {
            print(value);
            cameraTra.RotateAround(pivot.transform.position, Vector3.up, 90f * Time.deltaTime);
        }).OnComplete(() =>
        {
            cameraTra.localEulerAngles = new Vector3(cameraTra.localEulerAngles.x,finalRot, cameraTra.localEulerAngles.z);
        });
    }

    private void ZoomOut()
    {
        cameraTra.transform.localPosition -= cameraTra.transform.forward * Time.deltaTime * zoomSpeed;
    }

    private void ZoomIn()
    {
        cameraTra.transform.localPosition += cameraTra.transform.forward * Time.deltaTime * zoomSpeed;
    }
}
