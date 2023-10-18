using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HaircutTab : MonoBehaviour
{
    public float costPerLevel;
    public float incomePerLevel;
    public float cost_percentageIncrease;
    public float income_Increase;

    public TMP_Text cost_upgrade;
    public TMP_Text income_value;

    public Departments roomName;

    public RoomManager room;

    public int multiplier;

    public List<Slider> levelSlider;

    public List<TaskButton3> taskList;

    public List<TMP_Text> level;

    public Button upgradeButton;

    public List<GameObject> panels;

    public ParticleSystem upgradeEffect;

    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeClick);
        upgradeEffect.Stop();
    }

    public void UpgradeClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            upgradeEffect.Play();
            if (room.serviceLevel <= 25)
            {
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.2f;
                room.serviceLevel++;
                taskList[0].progressText.text = room.serviceLevel.ToString();
                taskList[0].progressionSlider.value = room.serviceLevel; 
                if (room.serviceLevel == 25)
                {
                    multiplier = 2;
                    incomePerLevel *= multiplier;
                    income_Increase = 0.4f;
                    StartCoroutine(taskList[0].TaskComplete());
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 800, 1f);
                    }
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            if (room.serviceLevel > 25 && room.serviceLevel <= 50)
            {
                room.serviceLevel++;
                taskList[1].progressText.text = room.serviceLevel.ToString();
                taskList[1].progressionSlider.value = room.serviceLevel;
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.4f;
                if (room.serviceLevel == 50)
                {
                    StartCoroutine(taskList[1].TaskComplete());
                    multiplier = 3;
                    incomePerLevel *= multiplier;
                    income_Increase = 1.2f;
                    room.serviceLevel++;
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 800, 1f);
                    }
                    level[1].text = room.serviceLevel.ToString();
                    levelSlider[1].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[1].text = room.serviceLevel.ToString();
                    levelSlider[1].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            if (room.serviceLevel > 50 && room.serviceLevel <= 75)
            {
                room.serviceLevel++;
                taskList[2].progressText.text = room.serviceLevel.ToString();
                taskList[2].progressionSlider.value = room.serviceLevel;
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 1.2f;
                if (room.serviceLevel == 75)
                {
                    StartCoroutine(taskList[2].TaskComplete());
                    multiplier = 4;
                    incomePerLevel *= multiplier;
                    income_Increase = 4.5f;
                    room.serviceLevel++;
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 800, 1f);
                    }
                    level[2].text = room.serviceLevel.ToString();
                    levelSlider[2].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[2].text = room.serviceLevel.ToString();
                    levelSlider[2].value = room.serviceLevel;
                    UpdateCost();
                }
            }
        }
    }

    public void UpdateCost()
    {
        GameManager.instance.totalSoftCurrency -= costPerLevel;
        CanvasManager.instance.UpdateSoftCurrency();
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        incomePerLevel += income_Increase;
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
        room.serviceCost = incomePerLevel;
        cost_upgrade.text = costPerLevel.ToString();
        income_value.text = incomePerLevel.ToString();
    }

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }
}
