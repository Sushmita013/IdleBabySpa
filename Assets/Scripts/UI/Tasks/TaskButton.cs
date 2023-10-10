using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class TaskButton : MonoBehaviour
{
    public bool taskComplete;

    public string messageText;
    public string descriptionText;

    public int rewardValue;

    public GameObject objectToEnable;

    public GameObject incompleteTask;
    public GameObject completeTask;

    public Slider progressionSlider;
    public TMP_Text progressText;

    public GameObject addUI; 
    public ParticleSystem effectUI; 
    public ParticleSystem explosionFx;

    public RoomManager room;

    public Transform effectObjects;
    public int childrenDestroyed;

    public Button roomButton;

    public GameObject carManager;
    public ParticleSystem reward;


    void Start()
    {
        incompleteTask.SetActive(true);
        completeTask.SetActive(false);
        effectUI.Play();
        explosionFx.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(() => ShowPopup(messageText));
        roomButton.onClick.AddListener(() => ShowPopup(messageText)); 
    }

    public IEnumerator TaskComplete()
    {
        if (!taskComplete)
        {
            GameManager.instance.massageUnlocked = true;
            Destroy(addUI.gameObject); 
            Destroy(effectUI.gameObject);
            HidePopup(); 
            progressionSlider.value = 1;
            progressText.text = progressionSlider.value.ToString();
            yield return new WaitForSeconds(0.25f);
            Button button = gameObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => StartCoroutine(TaskComplete()));
            CanvasManager.instance.taskNumber += 1;
            if (CanvasManager.instance.taskNumber == 2)
            { 
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
                Tutorial.instance.MassageComplete();
            }
            if (CanvasManager.instance.taskNumber == 3)
            {
                Tutorial.instance.ReceptionDone();
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            }
            if (CanvasManager.instance.taskNumber == 5)
            { 
                objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(100, 100, 100), 0.75f);
                carManager.SetActive(true);
                Tutorial.instance.DestroyHands();
                Camera.main.GetComponent<PanZoom>().enabled = true; 
            }
            if (CanvasManager.instance.taskNumber == 8)
            {
                Debug.Log("haircut");
                GameManager.instance.haircutUnlocked = true;
                objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            } 
            taskComplete = true;  
            gameObject.GetComponent<Image>().sprite = CanvasManager.instance.completedTask;
            gameObject.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f);
            gameObject.transform.DOLocalMoveY(-120, 0.5f).OnComplete(() =>
            { 
                incompleteTask.SetActive(false);
                completeTask.SetActive(true);
            });
            explosionFx.Play();
            yield return new WaitForSeconds(0.75f); 
            Destroy(explosionFx.gameObject);
            CanvasManager.instance.tasksGO[CanvasManager.instance.taskNumber-1].SetActive(true);  
        }
        else
        { 
            ShowReward(messageText); 
        } 
    }

    public IEnumerator OnCollectReward()
    {
        if (CanvasManager.instance.taskNumber == 2)
        {
            Tutorial.instance.CollectedReward();
        }
        yield return new WaitForSeconds(0.05f);
            HideReward();
        reward.Play();

        GameManager.instance.totalSoftCurrency += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Destroy(gameObject); 
    }

    public void ShowPopup(string errorMessage)
    {
        room.ResetPanels();
        if (CanvasManager.instance.popupObject == null)
        { 
        CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.EnablePanel(); 
        errorPopup.SetErrorMessage(errorMessage);
        errorPopup.SetDescription(descriptionText);
        errorPopup.SetButton("BUILD", () => StartCoroutine(TaskComplete()));
        if (CanvasManager.instance.taskNumber == 4)
        {
                Tutorial.instance.ParkingBuild(); 
            Reception.instance.CamZoom(); 
            objectToEnable.transform.DOScale(new Vector3(50, 50, 50), 0.05f);
            }
            if (CanvasManager.instance.taskNumber == 1)
        { 
                Tutorial.instance.BuildClick();
            room.CamZoom();
            objectToEnable.transform.DOScale(new Vector3(.75f, .75f, .75f), 0.05f);
        }
        if (CanvasManager.instance.taskNumber == 2)
        {
                Tutorial.instance.ReceptionBuild();
                //Reception.instance.CamZoom(); 
                objectToEnable.transform.DOScale(new Vector3(.75f, .75f, .75f), 0.05f);
        }
        if (CanvasManager.instance.taskNumber == 7)
        { 
            room.CamZoom();  
            objectToEnable.transform.DOScale(new Vector3(.75f, .75f, .75f), 0.05f);
        }
        }
    }

    public void ShowReward(string message)
    {
        if (CanvasManager.instance.taskNumber == 2)
        {
            Tutorial.instance.GetReward();
        }
        RoomManager.instance.ResetPanels();
        if (CanvasManager.instance.popupObject1 == null)
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
