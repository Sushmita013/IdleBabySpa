using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin;
    public float zoomOutMax;

    public float speed;
    // Add a flag to indicate if UI should handle the input
    private bool uiShouldHandleInput = false;

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
        else if (Input.GetMouseButton(0) && !uiShouldHandleInput )
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = Camera.main.transform.position + direction*Time.deltaTime*speed;

            newPosition = new Vector3(
                    Mathf.Clamp(newPosition. x, -150, -40),
                    60,
                    Mathf.Clamp(newPosition. z, -80, 15)); 
                Camera.main.transform.position = newPosition;
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
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
