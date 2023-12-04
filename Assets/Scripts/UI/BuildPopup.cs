using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class BuildPopup : MonoBehaviour
{
    public GameObject popupWindow;
    public TMP_Text messageText;
    public TMP_Text cost;
    public TMP_Text descriptionText;
    public Button button; 
    public Button closeButton; 

    private string button_Text;
    private System.Action buttonAction; 
    private System.Action buttonAction1; 

    public void SetErrorMessage(string message)
    {
        messageText.text = message;
    }
    public void SetCost(float message)
    {
        cost.text = message.ToString();
    }
    public void SetDescription(string message)
    {
        descriptionText.text = message;
    }

    public void SetButton(string buttonText, System.Action action)
    {
        button_Text = buttonText;
        buttonAction = action;
    }

    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
        closeButton.onClick.AddListener(ButtonClicked1);
    }

    private void ButtonClicked()
    {
        buttonAction?.Invoke();
    }
    private void ButtonClicked1()
    {
        buttonAction1?.Invoke();
    }

    public void EnablePanel()
    {
        popupWindow.GetComponent<RectTransform>().DOAnchorPosY(-0, 0.5f);
    }

    public void DisablePanel(Action disableAction)
    {
        popupWindow.GetComponent<RectTransform>().DOAnchorPosY(-700, 0.5f).OnComplete(() =>
        {
            disableAction?.Invoke();
        });  
    } 

    public void CloseButtonClick(Action closeAction)
    {
        buttonAction1 = closeAction; 
    }

}
