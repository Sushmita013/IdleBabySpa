using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Department : MonoBehaviour
{
    public float costPerLevel;
    public float incomePerLevel;
    public float cost_percentageIncrease; 
    public float income_Increase; 
     
    //public float hireCost;
    //public TMP_Text hireText;
    //public TMP_Text totalHires_text;
    public TMP_Text service_cost;
    public TMP_Text upgrade_cost;

    public Departments roomName;  

    public int multiplier;

    public List<Slider> levelSlider;

    public Button upgradeButton;

    void Start()
    {
        //hireText.text = hireCost.ToString(); 
        upgradeButton.onClick.AddListener(UpgradeClick);
    } 

    public void UpgradeClick()
    {
        if (GameManager.instance.totalBalance >= costPerLevel)
        {
            if(RoomManager.instance.serviceLevel <= 25)
            {
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.2f;
                RoomManager.instance.serviceLevel++;
                if (RoomManager.instance.serviceLevel == 25)
                {
                    StartCoroutine(RoomManager.instance.taskList[0].TaskComplete());
                }
                RoomManager.instance.level[0].text = RoomManager.instance.serviceLevel.ToString();
                levelSlider[0].value = RoomManager.instance.serviceLevel;
                UpdateCost(); 
            }
            if (RoomManager.instance.serviceLevel>25)
            {
                multiplier = 2;
                    incomePerLevel *= multiplier;
                income_Increase = 0.4f;
            RoomManager.instance.serviceLevel++;
                UpdateCost();
            }
        }
    }

    public void UpdateCost()
    {
        GameManager.instance.totalBalance -= costPerLevel;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        incomePerLevel += income_Increase; 
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
        service_cost.text = costPerLevel.ToString();
        upgrade_cost.text = incomePerLevel.ToString();
    }
    //public void UpdateValues(Departments room)
    //{
    //    CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
    //    totalHires_text.text = totalHires.ToString();
    //    switch (room)
    //    {
    //        case Departments.WaterTaining:
    //            PlayerPrefs.SetInt("Trainer", totalHires);
    //            break;
    //        case Departments.Massage:
    //            PlayerPrefs.SetInt("Masseuse", totalHires);

    //            break;
    //        case Departments.Haircut:
    //            PlayerPrefs.SetInt("Dresser", totalHires);

    //            break;
    //        case Departments.Pamper:
    //            PlayerPrefs.SetInt("Nurse", totalHires);

    //            break;
    //        case Departments.Playroom:
    //            PlayerPrefs.SetInt("Nanny", totalHires);

    //            break;
    //        case Departments.PhotoRoom:
    //            PlayerPrefs.SetInt("Photographer", totalHires);

    //            break;
    //        case Departments.Cafeteria:
    //            PlayerPrefs.SetInt("Waiters", totalHires);

    //            break;
    //    }
    //} 

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalBalance_hard.ToString();
    }

    //public void OnNewHire()
    //{
    //    if (totalHires == 0)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName); 
    //        }
    //    }
    //    else if (totalHires == 1)
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName);
    //        }
    //    }
    //    else
    //    {
    //        if (GameManager.instance.totalBalance >= hireCost)
    //        {
    //            GameManager.instance.totalBalance -= hireCost;
    //            StartCoroutine(hires_worker[totalHires].PlayEffects());
    //            totalHires++;
    //            UpdateValues(roomName);
    //            hireButton.interactable = false;
    //        }
    //    }
    //}


    //public void Chair()
    //{
    //    chair.SetActive(true);
    //    //GameManager.instance.totalBalance_hard -= 25;
    //    CanvasManager.instance.totalBalanceHard_text.text = 25.ToString();
    //    //UpdateHard();
    //}
    //public void TV()
    //{
    //    tv.SetActive(true);
    //    //GameManager.instance.totalBalance_hard -= 25;
    //    CanvasManager.instance.totalBalanceHard_text.text = 0.ToString();

    //    //UpdateHard();
    //} 
    //public void UpgradeService()
    //{
    //    startLevel++;
    //    costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
    //    incomePerLevel += income_Increase;
    //    //incomePerLevel += incomePerLevel * (income_Increase / 100);
    //    costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
    //    incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place

    //    cost_per_Level.text = costPerLevel.ToString();
    //    income_per_Level.text = incomePerLevel.ToString();
    //    current_Level.text = startLevel.ToString();

    //    Debug.Log("Cost " + startLevel + ": " + costPerLevel);
    //    Debug.Log("Income " + startLevel + ": " + incomePerLevel);
    //}
}
