using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class CameraController : MonoBehaviour
{
    //public float moveSpeed = 5f; // Camera translation speed
    //public float rotationSpeed = 2f; // Camera rotation speed

    //private float yaw = 0f;
    //private float pitch = 0f;

    //void Update()
    //{
    //    // Translation Input
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    // Calculate the camera's translation direction
    //    Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    //    Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

    //    // Apply the translation to the camera's position
    //    transform.Translate(moveAmount);

    //    // Rotation Input (Mouse)
    //    yaw += rotationSpeed * Input.GetAxis("Mouse X");
    //    pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
    //    pitch = Mathf.Clamp(pitch, -90f, 90f);

    //    // Apply the rotation to the camera
    //    transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    //}

    [SerializeField]
    private float Propconsty, propconstX;
    public float sensitivity;
    public static bool one_touch;
    Vector3 temp_pos, startpos;
    [Header("Clamp Points Y")]
    public float Max_y;
    public float Min_y;
    [Header("Clamp Points X")]
    public float Max_x;
    public float Min_x;
    public float Const_Max_X;
    public float Const_Min_x;
    [Header("Zoom Variables")]
    public float Zoom_sens;
    public float Max_Zoom, Min_Zoom;
    public float distance;
    public float temp_dist;
    public Touch touches;
    // Start is called before the first frame update
    void Start()
    {
        Max_y = (Max_Zoom - transform.position.z) * Propconsty;
        Min_y = -((Max_Zoom - transform.position.z) * Propconsty) - 2;

        Max_x = (Const_Max_X) + (Max_Zoom - transform.position.z) * propconstX;
        Min_x = (Const_Min_x) - (Max_Zoom - transform.position.z) * propconstX;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            swiping();
            one_touch = true;
        }
        else if (Input.touchCount == 2)
        {
            CamZoom();
            one_touch = false;
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void swiping()
    {
        if (!one_touch)
            return;

        touches = Input.GetTouch(0);
        if (!IsPointerOverUIObject())
        {
            if (touches.phase == TouchPhase.Began)
            {
                startpos = transform.position;
            }
            else if (touches.phase == TouchPhase.Moved)
            {
                //// Upward-Downward movement
                //////
                if (touches.deltaPosition.y < 0)
                {
                    transform.DOKill();
                    temp_pos = transform.position;
                    temp_pos.y -= touches.deltaPosition.y * sensitivity;
                    temp_pos.y = Mathf.Clamp(temp_pos.y, Min_y, Max_y);
                    transform.position = temp_pos;
                }
                else if (touches.deltaPosition.y > 0)
                {
                    transform.DOKill();
                    temp_pos = transform.position;
                    temp_pos.y -= touches.deltaPosition.y * sensitivity;
                    temp_pos.y = Mathf.Clamp(temp_pos.y, Min_y, Max_y);
                    transform.position = temp_pos;
                }
                //// Left-Right movement
                /////
                if (touches.deltaPosition.x < 0)
                {
                    transform.DOKill();
                    temp_pos = transform.position;
                    temp_pos.x += touches.deltaPosition.x * sensitivity;
                    temp_pos.x = Mathf.Clamp(temp_pos.x, Min_x, Max_x);
                    transform.position = temp_pos;
                }
                else if (touches.deltaPosition.x > 0)
                {
                    transform.DOKill();
                    temp_pos = transform.position;
                    temp_pos.x += touches.deltaPosition.x * sensitivity;
                    temp_pos.x = Mathf.Clamp(temp_pos.x, Min_x, Max_x);
                    transform.position = temp_pos;
                }
            }
        }
        else
        {
            startpos = temp_pos;
        }
        //if (touches.phase == TouchPhase.Ended)
        //{
        //    //// Upward-Downward movement
        //    //////
        //    if (Mathf.Abs(startpos.y - temp_pos.y) - Mathf.Abs(startpos.x - temp_pos.x) > 0)
        //    {
        //        if (startpos.y > temp_pos.y)
        //        {
        //            transform.DOMoveY(Mathf.Clamp(temp_pos.y - 0.5f, Min_y, Max_y), 1);
        //            Vector3 temppos = transform.position;
        //            //temppos.y = Mathf.Clamp(temppos.y, Min_y, Max_y);
        //            transform.position = temp_pos;
        //        }
        //        else if (startpos.y < temp_pos.y)
        //        {
        //            transform.DOMoveY(Mathf.Clamp(temp_pos.y + 0.5f, Min_y, Max_y), 1);
        //            Vector3 temppos = transform.position;
        //            //temppos.y = Mathf.Clamp(temppos.y, Min_y, Max_y);
        //            transform.position = temp_pos;
        //        }
        //    }
        //    else if (Mathf.Abs(startpos.y - temp_pos.y) - Mathf.Abs(startpos.x - temp_pos.x) < 0)
        //    {
        //        //// Left-Right movement
        //        /////
        //        if (startpos.x > temp_pos.x)
        //        {
        //            transform.DOMoveX(Mathf.Clamp(temp_pos.x - 0.5f, Min_x, Max_x), 1);
        //            Vector3 temppos = transform.position;
        //            //temppos.x = Mathf.Clamp(temppos.x, Min_x, Max_x);
        //            transform.position = temp_pos;
        //        }
        //        else if (startpos.x < temp_pos.x)
        //        {
        //            transform.DOMoveX(Mathf.Clamp(temp_pos.x + 0.5f, Min_x, Max_x), 1);
        //            Vector3 temppos = transform.position;
        //            //temppos.x = Mathf.Clamp(temppos.x, Min_x, Max_x);
        //            transform.position = temp_pos;
        //        }
        //    }

        //}
    }
    public void CamZoom()
    {
        if (one_touch)
            return;

        if (!IsPointerOverUIObject())
        {
            Touch touches1 = Input.GetTouch(0);
            Touch touches2 = Input.GetTouch(1);

            if (touches1.phase == TouchPhase.Began && touches2.phase == TouchPhase.Began)
            {
                temp_dist = Vector2.Distance(touches1.position, touches2.position);
            }
            if (touches1.phase == TouchPhase.Moved && touches2.phase == TouchPhase.Moved)
            {
                distance = Vector2.Distance(touches1.position, touches2.position);
                if (distance > temp_dist)
                {
                    Vector3 Zoomer = transform.position;
                    Zoomer.z -= Zoom_sens;
                    Zoomer.z = Mathf.Clamp(Zoomer.z, Min_Zoom, Max_Zoom);
                    Max_y = (Max_Zoom - transform.position.z) * Propconsty;
                    Min_y = -((Max_Zoom - transform.position.z) * Propconsty) - 2;
                    Max_x = (Const_Max_X) + (Max_Zoom - transform.position.z) * propconstX;
                    Min_x = (Const_Min_x) - (Max_Zoom - transform.position.z) * propconstX;
                    //Max_x += Zoom_sens * propconst_pos;
                    //Max_x = Mathf.Clamp(Max_x, 5.3f, 6.6f);
                    //Min_x += Zoom_sens * propconst_neg;
                    //Min_x = Mathf.Clamp(Min_x, -6.7f, -5.6f);
                    transform.position = Zoomer;
                    temp_dist = distance;
                }
                else if (distance < temp_dist)
                {
                    Vector3 Zoomer = transform.position;
                    Zoomer.z += Zoom_sens;
                    Zoomer.z = Mathf.Clamp(Zoomer.z, Min_Zoom, Max_Zoom);
                    Max_y = (Max_Zoom - transform.position.z) * Propconsty;
                    Min_y = -((Max_Zoom - transform.position.z) * Propconsty) - 2;
                    Max_x = (Const_Max_X) + (Max_Zoom - transform.position.z) * propconstX;
                    Min_x = (Const_Min_x) - (Max_Zoom - transform.position.z) * propconstX;
                    //Max_x -= Zoom_sens * propconst_pos;
                    //Max_x = Mathf.Clamp(Max_x, 5.3f, 6.6f);
                    //Min_x -= Zoom_sens * propconst_neg;
                    //Min_x = Mathf.Clamp(Min_x, -6.7f, -5.6f);
                    transform.position = Zoomer;
                    temp_dist = distance;
                }
            }
        }


    }
}
