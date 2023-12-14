using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> hands;

    public GameObject upgradeHand;

    public RoomManager massageRoom;
    public RoomManager parking;
    public RoomManager advertisement;

    public Reception reception;

    public GameObject carManager; 

    public BoxCollider massageButton;
    public BoxCollider parkingButton;
    public BoxCollider advertisementButton; 

    private void Update()
    {
        if (TaskManager.Instance.CurrentTaskNo == 0 && !reception.isUnlocked)
        {
            Camera.main.GetComponent<PanZoom>().enabled = false;
            //Camera.main.transform.position = new Vector3(-140f, 60, -47f);
            Camera.main.orthographicSize = 25;
            ActivateHand(0);

            massageButton.enabled = false;
            parkingButton.enabled = false;
            advertisementButton.enabled = false;
        }
        if (TaskManager.Instance.CurrentTaskNo == 1 && !massageRoom.isUnlocked)
        {
            StartCoroutine(MassageBuild());
        }
        if (TaskManager.Instance.CurrentTaskNo == 2 && !parking.isUnlocked)
        {
            StartCoroutine(ParkingBuild()); 
        }
        if (TaskManager.Instance.CurrentTaskNo == 3 && !advertisement.isUnlocked)
        { 
            StartCoroutine(AdvertisementBuild()); 
        }
        if (TaskManager.Instance.CurrentTaskNo == 4)
        {
            Camera.main.GetComponent<PanZoom>().enabled = true; 
            carManager.SetActive(true);
            ActivateHand(4);
            upgradeHand.SetActive(true); 
        }
        if (TaskManager.Instance.CurrentTaskNo == 4 && massageRoom.hasUI)
        {
            ResetHands();
            upgradeHand.SetActive(true); 
        } 
        if (massageRoom.serviceLevel > 2)
        {
            ResetHands(); 
            upgradeHand.SetActive(false); 
        }
        if (CanvasManager.instance.popupObject != null)
        {
            ResetHands(); 
        }
        if (TaskManager.Instance.CurrentTaskNo > 4)
        {
            ResetHands();
            upgradeHand.SetActive(false); 
        }
    } 

    void ActivateHand(int i)
    { 
        for (int j = 0; j < hands.Count; j++)
        {
            if (j == i)
            {
                hands[j].SetActive(true);
            }
            else
            {
                hands[j].SetActive(false);
            }
        }
    }

    public IEnumerator MassageBuild()
    {
        ActivateHand(1);
        yield return new WaitForSeconds(1f);
        Camera.main.transform.DOMove(new Vector3(-130, 60, -80), 1.5f);
        Camera.main.orthographicSize = 25;
        upgradeHand.SetActive(false);
        massageButton.enabled = true;
    }
    public IEnumerator ParkingBuild()
    {
        ActivateHand(2);
        yield return new WaitForSeconds(1f);
        Camera.main.transform.DOMove(new Vector3(-140, 60, -15), 1.5f);
        Camera.main.orthographicSize = 25;
        upgradeHand.SetActive(false);
        parkingButton.enabled = true;
    }
    public IEnumerator AdvertisementBuild()
    {
        ActivateHand(3);
        yield return new WaitForSeconds(1f);
        Camera.main.transform.DOMove(new Vector3(-140, 60, -48), 1.5f);
        Camera.main.orthographicSize = 20;
        upgradeHand.SetActive(false);
        advertisementButton.enabled = true;
    }

    void ResetHands()
    {
        foreach (GameObject item in hands)
        {
            item.SetActive(false);
        }
    } 
     
}
