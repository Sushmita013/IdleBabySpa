using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro; 

public class TaskButton2 : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;
    public string descriptionText;

    public int rewardValue;

    public GameObject objectToEnable;

    public GameObject addUI;
    public ParticleSystem effectUI;
    public ParticleSystem explosionFx;

    public Parking room;
    public Button parkingButton;
    public GameObject incompleteTask;
    public GameObject completeTask;

    public Slider progressionSlider;
    public TMP_Text progressText;
    public ParticleSystem reward;


    void Start()
    {
        incompleteTask.SetActive(true);
        completeTask.SetActive(false);
        effectUI.Play();
        explosionFx.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
        parkingButton.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        {
            HidePopup();
            progressionSlider.value = 1;
            progressText.text = progressionSlider.value.ToString();
            yield return new WaitForSeconds(0.5f);
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
            CanvasManager.instance.taskNumber += 1; 
            taskComplete = true;
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f); 
            gameObject.transform.DOLocalMoveY(-120, 0.5f);
            explosionFx.Play();
            yield return new WaitForSeconds(0.5f);
            Tutorial.instance.BillboardBuild();
            incompleteTask.SetActive(false);
            completeTask.SetActive(true);
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber-1].SetActive(true);
            //CanvasManager.instance.tasksGO[0].SetActive(true); 
            Destroy(addUI.gameObject);
            Destroy(explosionFx.gameObject);
            Destroy(effectUI.gameObject);
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
        RoomManager.instance.ResetPanels();
        Tutorial.instance.ParkingBuild();
        room.CamZoom();
        if (CanvasManager.instance.popupObject == null)
        { 
        CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.EnablePanel();
        errorPopup.SetErrorMessage(errorMessage);
        errorPopup.SetDescription(descriptionText);
        errorPopup.SetButton("BUILD", () => StartCoroutine(TaskComplete())); 
        objectToEnable.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);
        }
    }

    public void ShowReward(string message)
    {
        RoomManager.instance.ResetPanels();

        if (CanvasManager.instance.popupObject1==null)
        { 
        CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup, CanvasManager.instance.prefabParent1);
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.EnablePanel();
        //errorPopup.SetErrorMessage(message);
        errorPopup.SetRewardMessage(rewardValue.ToString());
        errorPopup.SetButton("Collect Reward", () => StartCoroutine(OnCollectReward()));
        }
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
