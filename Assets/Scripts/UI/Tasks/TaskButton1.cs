using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskButton1 : MonoBehaviour
{
    public bool taskCompleted; 
      
    public string messageText;

    public int rewardValue;
     

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup()); 
    }

    public IEnumerator TaskComplete()
    {
        if (!taskCompleted)
        { 
            yield return new WaitForSeconds(0.5f);
            CanvasManager.instance.taskNumber += 1;
            taskCompleted = true;
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOLocalMoveY(-90, 0.5f); 
            yield return new WaitForSeconds(0.75f);
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber - 1].SetActive(true); 
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
        }
        else
        {
            ShowReward(messageText);
        }
    }

    public void ShowPopup()
    {
        Debug.Log("popup");
        StartCoroutine(Reception.instance.CameraZoomIn());
        //Reception.instance.hireButton.onClick.AddListener(() => StartCoroutine(TaskComplete()));
    }

    public IEnumerator OnCollectReward()
    {
        yield return new WaitForSeconds(0.05f);
        HideReward();
        GameManager.instance.totalBalance += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        Destroy(gameObject);
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

    public void HideReward()
    {
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject1);
    }
}
