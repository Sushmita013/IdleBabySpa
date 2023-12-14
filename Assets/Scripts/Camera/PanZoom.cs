using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin;
    public float zoomOutMax;

    public float speed;
    // Add a flag to indicate if UI should handle the input
    private bool uiShouldHandleInput = false;

    //public float magnitude=0;
    public Vector3 direction;

    //public float decayTime;

    void Update()
    {
        if (IsPointerOverUIObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)   )
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.05f);
        }
        else if (Input.GetMouseButton(0) && !uiShouldHandleInput)
        {
            direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //magnitude = direction.magnitude;
            //magnitude = Mathf.Clamp(magnitude, 0, 20);
            //if (magnitude < 1)
            //{
            //    return;
            //}
            //direction = direction.normalized;
            Vector3 newPosition = Camera.main.transform.position + direction*Time.deltaTime*speed;

            newPosition = new Vector3(
                    Mathf.Clamp(newPosition. x, -150, -40),
                    60,
                    Mathf.Clamp(newPosition. z, -80, 15));
            DOTween.Kill(Camera.main.transform);
            Camera.main.transform.DOMove(newPosition, 0.01f);
        }

        //else
        //{
        //    if (magnitude > 1)
        //    {
        //        magnitude -= Time.deltaTime * decayTime;
        //        Vector3 newPosition = Camera.main.transform.position + direction * Time.deltaTime * speed;

        //        newPosition = new Vector3(
        //                Mathf.Clamp(newPosition.x, -150, -40),
        //                60,
        //                Mathf.Clamp(newPosition.z, -80, 15));
        //        DOTween.Kill(Camera.main.transform); 
        //        Camera.main.transform.DOMove(newPosition, 0.01f);
        //    }
        //}
        zoom(Input.GetAxis("Mouse ScrollWheel") * 20);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    } 
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
