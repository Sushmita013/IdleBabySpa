using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;


public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public TMP_Text totalBalance_text;
    public TMP_Text totalBalanceHard_text; 

    public Transform prefabParent1; 

    public GameObject buildPopup;
    public GameObject buildPopup1;
    public GameObject rewardPopup;
    public GameObject rewardPopup1;
    public GameObject popupObject;
    public GameObject popupObject1;

    public int collectedTipCount; 

    public List<GameObject> tasksGO;

    public int taskNumber;

    public Sprite completedTask;

    //public Button levelButton;
    //public Button levelCloseButton;

    public GameObject rewardEffect;
    //public GameObject levelPanel;
     
    //public int tipsCollected;

    void Start()
    {
        LoadData();
        rewardEffect.SetActive(false);
        Camera.main.transform.position = new Vector3(-140f, 60, -47f);
        Camera.main.orthographicSize = 25;
        instance = this; 
        GameManager.instance.totalSoftCurrency = Mathf.Round(GameManager.instance.totalSoftCurrency * 10) / 10; // Round to 1 decimal place 
        totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString(); 
        //levelButton.onClick.AddListener(() => OnLevelClick(true));
        //levelCloseButton.onClick.AddListener(() => OnLevelClick(false)); 
    }

    public void UpdateSoftCurrency()
    {
        GameManager.instance.totalSoftCurrency = Mathf.Round(GameManager.instance.totalSoftCurrency * 10) / 10; // Round to 1 decimal place 
        totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
    }
    public void UpdateHardCurrency()
    {
        totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }

    public void OnLevelClick(bool enable)
    {
        //levelPanel.SetActive(enable);
    }

    public void OnCollectReward()
    {
        //HideReward();
         
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Destroy(gameObject);

    }

    public void ShowPopup(string errorMessage,string description,Action buildAction)
    {
        //room.ResetPanels();
        if (CanvasManager.instance.popupObject == null)
        {
            CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
            BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
            errorPopup.EnablePanel();
            errorPopup.SetErrorMessage(errorMessage);
            errorPopup.SetDescription(description);
            errorPopup.SetButton("BUILD", buildAction);
            errorPopup.CloseButtonClick(HidePopup);
        }
    }
    public void ShowPopup1(string errorMessage,string description, float cost,Action buildAction)
    {
        //room.ResetPanels();
        if (CanvasManager.instance.popupObject == null)
        {
            CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup1, CanvasManager.instance.prefabParent1);
            BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
            errorPopup.EnablePanel();
            errorPopup.SetErrorMessage(errorMessage);
            errorPopup.SetDescription(description);
            errorPopup.SetCost(cost); 
            errorPopup.SetButton("BUILD", buildAction);
            errorPopup.CloseButtonClick(HidePopup); 
        }
    }

    public void ShowReward(string message,float rewardValue)
    { 
        if (CanvasManager.instance.popupObject1 == null)
        {
            CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup, CanvasManager.instance.prefabParent1);
            RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
            errorPopup.EnablePanel();
            errorPopup.SetRewardMessage(rewardValue.ToString());
            errorPopup.SetRewardText(message);
            errorPopup.SetButton("Collect Reward", ()=>StartCoroutine(HideReward(rewardValue)));
        }
    }

    public void HidePopup()
    {
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.DisablePanel(()=> Destroy(CanvasManager.instance.popupObject)); 
    }
    public IEnumerator HideReward(float rewardValue)
    {
        rewardEffect.SetActive(true);
        MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
        GameManager.instance.totalSoftCurrency += rewardValue;
        UpdateSoftCurrency(); 
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel(()=> Destroy(CanvasManager.instance.popupObject1));
        yield return new WaitForSeconds(1f);
        rewardEffect.SetActive(false); 
        SaveManager.instance.SaveDataCall();
    }

    public void LoadData()
    {
        totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
    }

}

