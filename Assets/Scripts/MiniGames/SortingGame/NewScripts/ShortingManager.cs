using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ShortingManager : MonoBehaviour
{
    public static ShortingManager instance;
    [SerializeField] List<GameObject> spwanObjects;
    [SerializeField] List<Transform> spwanPos;
    [SerializeField] Transform mainParent;
    [SerializeField] LayerMask ToyLayer,GroundLayer;
    [SerializeField] GameObject selectedObg;
    [SerializeField] TMP_Text TimerTxt;

    public List<GameObject> spawnedToys;
     public float targetTime = 60f;
    Camera maincamera;
    bool isGameplay = true;
    void Start()
    {
        instance = this;
        isGameplay = true;
        maincamera = Camera.main;
        StartTimer();
        SpwanObjectsFunc();
    }

    void Update()
    {
        if(isGameplay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DetectObjectThroughRaycast();
            }

            if (Input.GetMouseButton(0))
            {
                MoveObject();
            }

            if (Input.GetMouseButtonUp(0))
            {
                selectedObg = null;
            }
        }
        
    }

    void SpwanObjectsFunc()
    {
        for (int i = 0; i < spwanObjects.Count; i++)
        {
            int randomIndex = Random.Range(0, spwanPos.Count);
            GameObject Objects = Instantiate(spwanObjects[i], spwanPos[randomIndex].position, Quaternion.identity, mainParent);
            spawnedToys.Add(Objects);
        }
    }

    void DetectObjectThroughRaycast()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ToyLayer))
        {
            selectedObg = hit.transform.gameObject;
        }
    }

    void MoveObject()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
        {
            if(selectedObg != null)
            {
                selectedObg.transform.position = hit.point + new Vector3(0, 2f, 0);
                selectedObg.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }


    //Timer 

    void StartTimer()
    {
        // Use DOTween.To to create a countdown timer from the target time to 0
        DOTween.To(() => targetTime, x => UpdateTimer(x), 0f, targetTime)
            .SetEase(Ease.Linear)// Set the ease type (Linear in this case)
            .OnComplete(OnTimerComplete);
    }
    void UpdateTimer(float timeRemaining)
    {
        // This method will be called during the timer countdown
        // You can use the 'timeRemaining' parameter to update a UI Text component or perform actions based on the timer progress
        DisplayTime(timeRemaining);
    }
    void DisplayTime(float seconds)
    {
        // Convert seconds to minutes and seconds
        int minutes = Mathf.FloorToInt(seconds / 60);
        int remainingSeconds = Mathf.FloorToInt(seconds % 60);

        // Display the time in the desired format
        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
    void OnTimerComplete()
    {
        isGameplay = false;
        // ui for close
        Debug.Log("Timer Complete!"); 
    }

    public void StopTimer()
    {
        DOTween.Kill(targetTime);
    }

}
