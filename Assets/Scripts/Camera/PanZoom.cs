using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin;
    public float zoomOutMax; 
    //public Rect panBounds; // Define the bounding box for panning

     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = Camera.main.transform.position + direction;

            // Clamp the new position to the panBounds
            //newPosition.x = Mathf.Clamp(newPosition.x, panBounds.x, panBounds.x + panBounds.width);
            //newPosition.y = Mathf.Clamp(newPosition.y, panBounds.y, panBounds.y + panBounds.height);

            Camera.main.transform.position = newPosition;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -80, 80),
                60,
                Mathf.Clamp(transform.position.z, -40, 120)) ; 

        }
        zoom(Input.GetAxis("Mouse ScrollWheel")*20);
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
