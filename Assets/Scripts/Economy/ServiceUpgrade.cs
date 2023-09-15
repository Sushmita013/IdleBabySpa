using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ServiceUpgrade : MonoBehaviour
{
    public Departments roomName; 
    public int startLevel;
    public float startCost;
    public float startIncome;
    public int endLevel;
     
    public Button upgradeLevel; 

    public List<ButtonTabsChange> tabs;
    public List<GameObject> panels;
    public List<Button> buttons;
    
    public float cost_percentageIncrease;
    public float income_Increase;

    public float costPerLevel;
    public float incomePerLevel;

    public TMP_Text cost_per_Level;
    public TMP_Text income_per_Level;
    public TMP_Text current_Level;

    

    void Start()
    {
        startLevel = 1;
        endLevel = 25;

        startCost = 2;
        startIncome = 2;

        cost_percentageIncrease = 6;
        income_Increase = 0.2f;
         
        costPerLevel = startCost;
        incomePerLevel = startIncome;

        upgradeLevel.onClick.AddListener(UpgradeClick);

        for (int i = 0; i < 3; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => ButtonClick(buttonIndex));
        } 


    }

    public void UpgradeClick()
    {
        startLevel++;
            costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
            incomePerLevel += income_Increase;
            //incomePerLevel += incomePerLevel * (income_Increase / 100);
            costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
            incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place

            cost_per_Level.text = costPerLevel.ToString();
            income_per_Level.text = incomePerLevel.ToString();
        current_Level.text = startLevel.ToString();

            Debug.Log("Cost " + startLevel + ": " + costPerLevel);
            Debug.Log("Income " + startLevel + ": " + incomePerLevel); 
    }

    public void HandleButtonStateChange(ButtonTabsChange button)
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
