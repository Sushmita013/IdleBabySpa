using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    [SerializeField] Vector3 lastPos;
    [SerializeField] LayerMask groundLayer;

    public Vector3 GetSelectedMapPosition()
    {
        RaycastHit hit;
        Vector3 mousePos = Input.mousePosition;
        Ray ray=sceneCamera.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray, out hit,100,groundLayer))
        {
            lastPos = hit.point;
        }
        return lastPos;
    }
}
