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

    public GameObject costActive;
    public GameObject costInactive;

    private string button_Text;
    private System.Action buttonAction; 
    

    public void SetErrorMessage(string message)
    {
        messageText.text = message;
    }
    public void SetCost(string message)
    {
        cost.text = message;
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
    }

    private void ButtonClicked()
    {
        buttonAction?.Invoke();
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

    public void SetCostActive()
    {
        costActive.SetActive(true);
        costInactive.SetActive(false);
    }
}
