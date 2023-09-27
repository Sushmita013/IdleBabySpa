using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskButton : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;

    public int rewardValue;

    public GameObject objectToEnable;

    public GameObject addUI; 
    public ParticleSystem effectUI; 
    public ParticleSystem explosionFx;

    public RoomManager room;

    public Transform effectObjects;
    public int childrenDestroyed;

    public Button roomButton;


    void Start()
    {
        explosionFx.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
        roomButton.onClick.AddListener(() => ShowPopup(messageText)); 
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        {
            Destroy(addUI.gameObject); 
            Destroy(effectUI.gameObject);
            HidePopup();
            yield return new WaitForSeconds(0.25f);
            CanvasManager.instance.taskNumber += 1;
            if (CanvasManager.instance.taskNumber == 2)
            {
                Debug.Log("task2");
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            }
            if (CanvasManager.instance.taskNumber == 4)
            {
                Debug.Log("task5"); 
                objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(100, 100, 100), 0.75f);
            } 
            taskComplete = true;  
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOLocalMoveY(-90, 0.5f);
            explosionFx.Play();
            yield return new WaitForSeconds(0.75f); 
            Destroy(explosionFx.gameObject); 
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber-1].SetActive(true);
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
        }
        else
        { 
            ShowReward(messageText); 
        } 
    }

    public IEnumerator OnCollectReward()
    {  
            yield return new WaitForSeconds(0.05f);
            HideReward();
        GameManager.instance.totalBalance += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        Destroy(gameObject);
    }

    public void ShowPopup(string errorMessage)
    { 
        CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.EnablePanel(); 
        errorPopup.SetErrorMessage(errorMessage);
        errorPopup.SetButton("BUILD", () => StartCoroutine(TaskComplete()));
        if (CanvasManager.instance.taskNumber == 2)
        {
            Reception.instance.CamZoom(); 
            objectToEnable.transform.DOScale(new Vector3(50, 50, 50), 0.05f);
        }
        if (CanvasManager.instance.taskNumber == 1)
        { 
            room.CamZoom();
            objectToEnable.transform.DOScale(new Vector3(.75f, .75f, .75f), 0.05f);
        } 
    }

    public void ShowReward(string message)
    {
        CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup, CanvasManager.instance.prefabParent1);
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.EnablePanel();
        //errorPopup.SetErrorMessage(message);
        errorPopup.SetRewardMessage(rewardValue.ToString());
        errorPopup.SetButton("Collect Reward", () => StartCoroutine(OnCollectReward()));
    }

    public void HidePopup()
    {
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject);
    }
    public void HideReward()
    {
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject1); 
    }

}
