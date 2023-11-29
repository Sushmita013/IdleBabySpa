using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

 

public class ButtonTabSwitch : MonoBehaviour
{
    public ButtonStates currentState = ButtonStates.selected;
    private Image buttonSprite;
    public Sprite deselectedSprite;
    public Sprite selectedSprite;

    private void Start()
    {
        buttonSprite = GetComponent<Image>();
    }
    public void UpdateButtonState(ButtonStates buttonStates)
    {
        switch (buttonStates)
        {
            case ButtonStates.deselected: 
                buttonSprite.sprite = deselectedSprite;
                break;
            case ButtonStates.selected: 
                buttonSprite.sprite = selectedSprite;
                break;
            default:
                break;
        }
    }
    public void ChangeState(ButtonStates newState)
    {
        currentState = newState;

        Tabs1 panelManager = FindObjectOfType<Tabs1>();
        Debug.Log(panelManager.name);
        if (panelManager != null)
        {
            panelManager.HandleButtonStateChange(this);
            UpdateButtonState(newState);
        }

        foreach (var button in panelManager.tabs)
        {
            if (button != this)
            { 
                button.UpdateButtonState(ButtonStates.deselected);
            }
        }
    }

    public void ResetButtons()
    {
        Tabs1 panelManager = FindObjectOfType<Tabs1>();
        foreach (var button in panelManager.tabs)
        {
            button.UpdateButtonState(ButtonStates.deselected);
        }

    }


}
