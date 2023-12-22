using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tabs5 : MonoBehaviour
{
    public List<ButtonChange> tabs; // Reference to the ButtonTabsChange scripts attached to buttons
    [SerializeField] List<GameObject> panels; // Reference to the panels corresponding to the buttons
    [SerializeField] List<Button> buttons;
    private void Start()
    {
        // Initially, select the first button and show its panel 

        //ButtonClick(0);
        for (int i = 0; i < buttons.Count; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => ButtonClick(buttonIndex));
        }
    }

    public void HandleButtonStateChange(ButtonChange button)
    {
        ResetPanels();

        int buttonIndex = tabs.IndexOf(button);

        if (buttonIndex != -1 && buttonIndex < panels.Count)
        {
            panels[buttonIndex].SetActive(true);
        }
    }

    public void ButtonClick(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < tabs.Count)
        {
            tabs[buttonIndex].ChangeState(ButtonStates.selected);
        }
    }

    public void ResetPanels()
    {
        foreach (GameObject item in panels)
        {
            item.SetActive(false);
        }
    }
}