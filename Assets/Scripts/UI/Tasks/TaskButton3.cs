using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TaskButton3 : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;

    public int rewardValue; 

    public RoomManager room;

    public GameObject incompleteTask;
    public GameObject completeTask;

    public Slider progressionSlider;
    public TMP_Text progressText;

    public ParticleSystem reward;
    void Start()
    { 
        incompleteTask.SetActive(true);
        completeTask.SetActive(false);
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup()); 
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        { 
            //HidePopup();
            //yield return new WaitForSeconds(0.5f);
            CanvasManager.instance.taskNumber += 1;
            taskComplete = true;
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f); 
            gameObject.transform.DOLocalMoveY(-120, 0.5f); 
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
            yield return new WaitForSeconds(0.5f);
            incompleteTask.SetActive(false);
            completeTask.SetActive(true);
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber-1].SetActive(true); 
            //CanvasManager.instance.tasksGO[0].SetActive(true); 
        }
        else
        {
            ShowReward(messageText);
        }
    }

    public IEnumerator OnCollectReward()
    {
        yield return new WaitForSeconds(0.05f);
        reward.Play();
        HideReward();
        if(CanvasManager.instance.taskNumber == 11)
        {
            GameManager.instance.totalHardCurrency += rewardValue;
            CanvasManager.instance.UpdateHardCurrency();
            Tutorial.instance.UpgradeInterior();
            Camera.main.GetComponent<PanZoom>().enabled = false;
            Camera.main.transform.DOLocalMove(new Vector3(-125f, 60, -72.5f), 1f).SetEase(Ease.Linear);
            Camera.main.DOOrthoSize(20, 1f);  
            //CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        }
        else
        { 
        GameManager.instance.totalSoftCurrency += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        }
        Destroy(gameObject);
        //CanvasManager.instance.tasksGO.Remove(CanvasManager.instance.tasksGO[0]);
    }

    public void ShowPopup()
    {
        RoomManager.instance.ResetPanels();
        Debug.Log("clicked task0");
        StartCoroutine(room.CameraZoomIn());  
    }

    public void ShowReward(string message)
    {
        RoomManager.instance.ResetPanels();
        if (CanvasManager.instance.popupObject1 == null)
        {
            if (CanvasManager.instance.taskNumber == 11)
            {
                CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup1, CanvasManager.instance.prefabParent1);
                RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
                errorPopup.EnablePanel();
                //errorPopup.SetErrorMessage(message);
                errorPopup.SetRewardMessage(rewardValue.ToString());
                errorPopup.SetRewardText(message);
                errorPopup.SetButton("Collect Reward", () => StartCoroutine(OnCollectReward()));
            }
            else
            { 
        CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup, CanvasManager.instance.prefabParent1);
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.EnablePanel();
        //errorPopup.SetErrorMessage(message);
        errorPopup.SetRewardMessage(rewardValue.ToString());
            errorPopup.SetRewardText(message); 
            errorPopup.SetButton("Collect Reward", () => StartCoroutine(OnCollectReward()));
            }
        }
    } 
    public void HideReward()
    {
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject1);
    }

}
