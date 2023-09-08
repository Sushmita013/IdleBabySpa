using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamSwitch : MonoBehaviour
{      
    public Vector3 camPos;
    public float moveSpeed = 2.0f;
    public int zoomSize;

    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        //Camera.main.transform.DOMove(camPos, 1f).SetEase(Ease.Linear).OnComplete(() =>
        //{ 
        //Camera.main.DOOrthoSize(zoomSize,1f);
        //});
        Camera.main.transform.DOMove(camPos, 1f).SetEase(Ease.Linear);
        Camera.main.DOOrthoSize(zoomSize, 1f);
    }

    private IEnumerator IncreasePlayerRigWeight(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the normalized weight based on the elapsed time.
            float normalizedWeight = Mathf.Clamp01(elapsedTime / duration);

            // Set the player rig's weight.
            Camera.main.orthographicSize = normalizedWeight;

            // Increment the elapsed time by the time passed since the last frame.
            elapsedTime += Time.deltaTime; 

            // Yield to the next frame.
            yield return null;
        }

        // Ensure the player rig's weight is exactly 1 when the Coroutine finishes.
        Camera.main.orthographicSize = zoomSize;
    }
    //IEnumerator Collider()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.GetComponent<Collider>().enabled = false;
    //    yield return new WaitForSeconds(2);
    //    gameObject.GetComponent<Collider>().enabled = true; 
    //} 
}
