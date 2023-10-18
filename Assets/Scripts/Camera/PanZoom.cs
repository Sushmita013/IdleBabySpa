using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin;
    public float zoomOutMax;
     

    // Add a flag to indicate if UI should handle the input
    private bool uiShouldHandleInput = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
        }
        if (Input.touchCount == 2 && !IsPointerOverUIObject())
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
        else if (Input.GetMouseButton(0) && !uiShouldHandleInput && !IsPointerOverUIObject())
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = Camera.main.transform.position + direction;

                Camera.main.transform.position = newPosition;
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -140, -40),
                    60,
                    Mathf.Clamp(transform.position.z, -80, 15)); 
        }
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

    //void zoom(float increment)
    //{
    //    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    //}


    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    }
    //    if (Input.touchCount == 2)
    //    {
    //        Touch touchZero = Input.GetTouch(0);
    //        Touch touchOne = Input.GetTouch(1);

    //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

    //        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

    //        float difference = currentMagnitude - prevMagnitude;

    //        zoom(difference * 0.05f);
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector3 newPosition = Camera.main.transform.position + direction;

    //        // Clamp the new position to the panBounds
    //        //newPosition.x = Mathf.Clamp(newPosition.x, panBounds.x, panBounds.x + panBounds.width);
    //        //newPosition.y = Mathf.Clamp(newPosition.y, panBounds.y, panBounds.y + panBounds.height);

    //        Camera.main.transform.position = newPosition;
    //        transform.position = new Vector3(
    //            Mathf.Clamp(transform.position.x, -140,100),
    //            60,
    //            Mathf.Clamp(transform.position.z, -80, 140)) ; 

    //    }
    //    zoom(Input.GetAxis("Mouse ScrollWheel")*20);
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    }
    //    if (Input.touchCount == 2)
    //    {
    //        Touch touchZero = Input.GetTouch(0);
    //        Touch touchOne = Input.GetTouch(1);

    //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

    //        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

    //        float difference = currentMagnitude - prevMagnitude;

    //        zoom(difference * 0.05f);
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Vector3 newPosition = Camera.main.transform.position + direction;

    //        // Check if the swipe is outside the UI area
    //        if (!uiSwipeArea.Contains(Input.mousePosition))
    //        {
    //            // Perform camera panning only if the swipe is outside the UI area
    //            Camera.main.transform.position = newPosition;
    //            transform.position = new Vector3(
    //                Mathf.Clamp(transform.position.x, -140, 100),
    //                60,
    //                Mathf.Clamp(transform.position.z, -80, 140));
    //        }
    //    }
    //    zoom(Input.GetAxis("Mouse ScrollWheel") * 20);
    //}


    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
