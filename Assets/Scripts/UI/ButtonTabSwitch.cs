using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

 

public class ButtonTabSwitch : MonoBehaviour
{
    public ButtonStates currentState = ButtonStates.selected;
    public Image buttonSprite;
    public Sprite deselectedSprite;
    public Sprite selectedSprite;

    public void UpdateButtonState(ButtonStates buttonStates)
    {
        switch (buttonStates)
        {
            case ButtonStates.deselected:
                //buttonSprite.color = deSelectedColor;
                //gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
                buttonSprite.sprite = deselectedSprite;
                break;
            case ButtonStates.selected:
                //buttonSprite.color = selectedColor; 
                //gameObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f); 
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
        Tabs panelManager = FindObjectOfType<Tabs>();
        foreach (var button in panelManager.tabs)
        {
            button.UpdateButtonState(ButtonStates.deselected);
        }

    }


}
