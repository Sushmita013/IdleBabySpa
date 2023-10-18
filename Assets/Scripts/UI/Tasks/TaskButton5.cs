using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TaskButton5 : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;

    public int rewardValue; 

    public GameObject incompleteTask;
    public GameObject completeTask;

    public Slider progressionSlider;
    public TMP_Text progressText; 

    public RoomManager room;  
     
    public ParticleSystem reward;


    void Start()
    {
        incompleteTask.SetActive(true);
        completeTask.SetActive(false); 
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText)); 
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        {  
            //progressionSlider.value = 1;
            //progressText.text = progressionSlider.value.ToString();
            yield return new WaitForSeconds(0.25f);
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
            CanvasManager.instance.taskNumber += 1; 
            taskComplete = true;
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f); 
            gameObject.transform.DOLocalMoveY(-120, 0.5f).OnComplete(() =>
            {
                incompleteTask.SetActive(false);
                completeTask.SetActive(true);
            }); 
            yield return new WaitForSeconds(0.75f); 
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber - 1].SetActive(true); 
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
        reward.Play();

        GameManager.instance.totalSoftCurrency += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Destroy(gameObject);
        //CanvasManager.instance.tasksGO.Remove(CanvasManager.instance.tasksGO[0]); 
    }

    public void ShowPopup(string errorMessage)
    {
        room.ResetPanels();
        room.CamZoom(); 
    }

    public void ShowReward(string message)
    {
        RoomManager.instance.ResetPanels();
        if (CanvasManager.instance.popupObject1 == null)
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
    public void HideReward()
    {
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject1);
    }

}
