using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class RewardPanel : MonoBehaviour
{
    public GameObject popupWindow;
    public TMP_Text messageText;
    public TMP_Text rewardText;
    public Button button;
    public float rewardValue;

    private string button_Text;
    private System.Action buttonAction; 
    public void SetRewardMessage(string message)
    {
        rewardText.text = message;
    }
    public void SetRewardText(string message)
    {
        messageText.text = message;
    }

    public void SetButton(string buttonText, System.Action action)
    {
        button_Text = buttonText;
        buttonAction = action;
    }

    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        buttonAction?.Invoke();
    }

    public void EnablePanel()
    {  
        popupWindow.SetActive(true);
        popupWindow.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
     
    public void DisablePanel(Action disableAction)
    {
        popupWindow.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f).OnComplete(() =>
        {
            popupWindow.SetActive(false);
            disableAction?.Invoke();
        });
    }
}
