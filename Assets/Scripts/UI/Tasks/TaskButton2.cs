using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskButton2 : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;

    public int rewardValue;

    public GameObject objectToEnable;

    public GameObject addUI;
    public ParticleSystem effectUI;
    public ParticleSystem explosionFx;

    public Parking room;
    public Button parkingButton;
    public GameObject carManager;

    void Start()
    {
        effectUI.Play();
        explosionFx.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
        parkingButton.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        {
            carManager.SetActive(true); 
            HidePopup();
            yield return new WaitForSeconds(0.5f);
            CanvasManager.instance.taskNumber += 1; 
            taskComplete = true;
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOLocalMoveY(-90, 0.5f);
            explosionFx.Play();
            yield return new WaitForSeconds(0.5f);
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber-1].SetActive(true);
            //CanvasManager.instance.tasksGO[0].SetActive(true); 
            Destroy(addUI.gameObject);
            Destroy(explosionFx.gameObject);
            Destroy(effectUI.gameObject);
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
        //CanvasManager.instance.tasksGO.Remove(CanvasManager.instance.tasksGO[0]); 
    }

    public void ShowPopup(string errorMessage)
    {
            room.CamZoom();
        CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.EnablePanel();
        errorPopup.SetErrorMessage(errorMessage);
        errorPopup.SetButton("BUILD", () => StartCoroutine(TaskComplete())); 
        objectToEnable.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);
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
