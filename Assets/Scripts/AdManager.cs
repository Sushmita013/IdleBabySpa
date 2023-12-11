using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float costPerLevel;              // Cost for upgrading
    public float incomePerLevel;            // Income gained per upgrade
    public float cost_percentageIncrease;   // Percentage increase in cost
    public float income_Increase;           // Income increase per upgrade

    public TMP_Text cost_upgrade;           // Text displaying upgrade cost
    public TMP_Text income_value;           // Text displaying income value

    public RoomManager room;                // Reference to RoomManager
     
    public List<GameObject> panels;          // List of UI panels
    // Income multiplier

    public List<Slider> levelSlider;        // Sliders for tracking service level progress

    //public List<TaskButton3> taskList;      // List of tasks related to service level

    public List<TMP_Text> level;            // Text displaying service level

    public Button upgradeButton;

    public ParticleSystem upgradeEffect;    // Particle effect for upgrades


    void Start()
    { 

    }

    public void UpgradeClick()
    {
        // Check if there's enough currency to perform the upgrade
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            // Play the upgrade effect particle system
            upgradeEffect.Play();

            if (room.serviceLevel <= 9)
            {
                // Handle upgrades based on service level up to 25 
                income_Increase = 0.2f;
                room.serviceLevel++;
                 

                // Additional logic for specific service levels
                if (room.serviceLevel == 2)
                {
                    Camera.main.GetComponent<PanZoom>().enabled = true;
                }
                if (room.serviceLevel == 13)
                {
                    //VisualUpgrade(13);
                }
                if (room.serviceLevel == 25)
                {
                    //VisualUpgrade(25); 
                    income_Increase = 0.4f;
                    //StartCoroutine(taskList[0].TaskComplete());

                    // Move UI panels for service level 25
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    //UpdateCost();
                }
                else
                {
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            else if (room.serviceLevel > 25 && room.serviceLevel <= 50)
            {
                // Handle upgrades based on service level from 26 to 50
                room.serviceLevel++;
                 
                 
                income_Increase = 0.4f;
                if (room.serviceLevel == 38)
                {
                    //VisualUpgrade(38);
                }
                if (room.serviceLevel == 50)
                {
                    //VisualUpgrade(50); 
                    income_Increase = 1.2f;
                    //StartCoroutine(taskList[1].TaskComplete());

                    // Move UI panels for service level 50
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
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
            else if (room.serviceLevel > 50 && room.serviceLevel <= 75)
            {
                // Handle upgrades based on service level from 51 to 75
                room.serviceLevel++;
                  
                income_Increase = 1.2f;
                if (room.serviceLevel == 63)
                {
                    //VisualUpgrade(63);
                }
                if (room.serviceLevel == 75)
                {
                    //FinalUpgrade();
                    //StartCoroutine(taskList[2].TaskComplete()); 
                    income_Increase = 4.5f;
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
        if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.UpgradeTask)
        {
            TaskManager.UpgradeAction?.Invoke();
        }
    }
    public void UpdateCost()
    {
        // Update the cost and income values after an upgrade
        GameManager.instance.totalSoftCurrency -= costPerLevel;
        CanvasManager.instance.UpdateSoftCurrency();
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        incomePerLevel += income_Increase;
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
        room.serviceCost = incomePerLevel;
        cost_upgrade.text = costPerLevel.ToString();
        income_value.text = incomePerLevel.ToString();
        SaveManager.instance.SaveDataCall(); 
    }

    //public void OnMouseDown()
    //{
    //    CamZoom();
    //}
    //public void CamZoom()
    //{
    //    keyboard.SetActive(true);
    //    if (Camera.main.transform.position != camPos.localPosition)
    //    {
    //        Camera.main.transform.DOLocalMove(camPos.localPosition, 0.75f).SetEase(Ease.Linear);
    //        Camera.main.DOOrthoSize(zoomSize, 0.75f);
    //    }
    //}

    //public void OnCloseClick()
    //{
    //    KeyboardManager.Instance.textBox.text += "'S";
    //    keyboard.SetActive(false); 
    //}


}
