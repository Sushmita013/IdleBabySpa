using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class ServiceTab : IService
{
    // Public variables
    public float costPerLevel;              // Cost for upgrading
    public float incomePerLevel;            // Income gained per upgrade
    public float cost_percentageIncrease;   // Percentage increase in cost
    public float income_Increase;           // Income increase per upgrade

    // Text elements displaying upgrade cost and income value
    public TMP_Text cost_upgrade;
    public TMP_Text income_value;

    public RoomManager room;                // Reference to RoomManager

    public int multiplier;                  // Income multiplier

    // Sliders for tracking service level progress
    public List<Slider> levelSlider;

    // Text displaying service level
    public List<TMP_Text> level;

    public Button upgradeButton;            // Button to trigger the upgrade

    // Lists of UI panels and various visual elements
    public List<GameObject> panels;
    public List<GameObject> visualChange1;
    public List<GameObject> visualChange2;
    public List<GameObject> visualChange3;
    public List<GameObject> equipmentLevel1;
    public List<GameObject> equipmentLevel2;
    public List<GameObject> equipmentLevel3;
    public List<GameObject> wallFloor;
    public List<GameObject> hireUI;
    public List<GameObject> hireButtons;

    // Particle effect for upgrades
    public ParticleSystem upgradeEffect;
    public ParticleSystem upgradeEffect1;
    public ParticleSystem upgradeEffect2;
    public ParticleSystem upgradeEffect3;
    public ParticleSystem upgradeEffect4;

    // Private variables
    private bool isHolding;                 // Flag for holding upgrade button
    private bool startTimer;                // Flag for starting upgrade timer
    private float holdTimer;                // Timer for upgrade button hold duration

    // Visual effects for service level upgrades
    public GameObject starEffect;
    public GameObject starEffect1;

    public Vector3 colliderSize1;
    public Vector3 colliderSize2;

    public Vector3 colliderCentre1;
    public Vector3 colliderCentre2;



    void Start()
    {
        // Add a listener for the upgrade button click event
        upgradeButton.onClick.AddListener(UpgradeClick);
        // Stop all upgrade effect particle systems initially
        upgradeEffect.Stop();
        upgradeEffect1.Stop();
        upgradeEffect2.Stop();
        upgradeEffect3.Stop();
        upgradeEffect4.Stop();
        ScaleDown();
        LoadData();
    }

    private void Update()
    {
        // If the timer is running, update the hold timer
        if (startTimer)
        {
            holdTimer += Time.deltaTime;

            // If the hold timer exceeds 0.75 seconds, trigger the upgrade hold coroutine
            if (holdTimer >= 0.75f)
            {
                isHolding = true;
                StartCoroutine(UpgradeHold());
            }
        }

        // Check if the upgrade button should be enabled or disabled based on available currency
        EnableDisableUpgrade(GameManager.instance.totalSoftCurrency);
    }

    public void UpgradeClick()
    {
        // Check if there's enough currency to perform the upgrade
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            // Play the upgrade effect particle system
            upgradeEffect.Play();
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);

            if (room.serviceLevel <= 25)
            {
                // Handle upgrades based on service level up to 25
                multiplier = 1;
                incomePerLevel *= multiplier;
                room.serviceLevel++;

                if (room.serviceLevel == 13)
                {
                    VisualUpgrade(13);
                }

                if (room.serviceLevel == 25)
                {
                    VisualUpgrade(25);
                    multiplier = 2;
                    incomePerLevel *= multiplier;
                    income_Increase *= multiplier;
                    room.GetComponent<BoxCollider>().size = colliderSize1;
                    room.GetComponent<BoxCollider>().center = colliderCentre1;
                    // Move UI panels for service level 25
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                }
                level[0].text = room.serviceLevel.ToString();
                levelSlider[0].value = room.serviceLevel;
                UpdateCost();
            }
            else if (room.serviceLevel > 25 && room.serviceLevel <= 50)
            {
                // Handle upgrades based on service level from 26 to 50
                room.serviceLevel++;

                multiplier = 1;
                incomePerLevel *= multiplier;

                if (room.serviceLevel == 38)
                {
                    VisualUpgrade(38);
                }
                if (room.serviceLevel == 50)
                {
                    VisualUpgrade(50);
                    multiplier = 3;
                    incomePerLevel *= multiplier;
                    income_Increase *= multiplier;
                    room.GetComponent<BoxCollider>().size = colliderSize2;
                    room.GetComponent<BoxCollider>().center = colliderCentre2; 

                    // Move UI panels for service level 50
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                }
                level[1].text = room.serviceLevel.ToString();
                levelSlider[1].value = room.serviceLevel;
                UpdateCost();
            }
            else if (room.serviceLevel > 50 && room.serviceLevel <= 75)
            {
                // Handle upgrades based on service level from 51 to 75
                room.serviceLevel++;
                multiplier = 1;
                incomePerLevel *= multiplier;
                if (room.serviceLevel == 63)
                {
                    VisualUpgrade(63);
                }
                if (room.serviceLevel == 75)
                {
                    FinalUpgrade();
                }
                level[2].text = room.serviceLevel.ToString();
                levelSlider[2].value = room.serviceLevel;
                UpdateCost();
            }
        }
        SaveManager.instance.SaveDataCall();
        if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.UpgradeTask)
        {
            TaskManager.UpgradeAction?.Invoke();
        }
    }
    public void UpgradeSave(int i)
    {
        // Check if there's enough currency to perform the upgrade 
        if (i <= 25)
        {
            // Handle upgrades based on service level up to 25
            multiplier = 1;
            incomePerLevel *= multiplier;
            //room.serviceLevel++;

            if (i == 13)
            {
                VisualUpgrade(13);
            }

            if (i == 25)
            {
                VisualUpgrade(25);
                multiplier = 2;
                incomePerLevel *= multiplier;
                income_Increase *= multiplier;
                room.GetComponent<BoxCollider>().size = colliderSize1;
                room.GetComponent<BoxCollider>().center = colliderCentre1;
                // Move UI panels for service level 25
                foreach (GameObject item in panels)
                {
                    item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                }
            }
            level[0].text = i.ToString();
            levelSlider[0].value = i;
            CalculateCost();
        }
        else if (i > 25 && i <= 50)
        {
            // Handle upgrades based on service level from 26 to 50
            //room.serviceLevel++; 
            multiplier = 1;
            incomePerLevel *= multiplier;

            if (i == 38)
            {
                VisualUpgrade(38);
            }
            if (i == 50)
            {
                VisualUpgrade(50);
                multiplier = 3;
                incomePerLevel *= multiplier;
                income_Increase *= multiplier;
                room.GetComponent<BoxCollider>().size = colliderSize2;
                room.GetComponent<BoxCollider>().center = colliderCentre2;
                // Move UI panels for service level 50
                foreach (GameObject item in panels)
                {
                    item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                }
            }
            level[1].text = i.ToString();
            levelSlider[1].value = i;
            CalculateCost();
        }
        else if (i > 50 && i <= 75)
        {
            // Handle upgrades based on service level from 51 to 75
            //room.serviceLevel++;
            multiplier = 1;
            incomePerLevel *= multiplier;
            if (i == 63)
            {
                VisualUpgrade(63);
            }
            if (i == 75)
            {
                FinalUpgrade();
            }
            level[2].text = i.ToString();
            levelSlider[2].value = i;
            CalculateCost();
        }
    }

    public void EnableDisableUpgrade(float bal)
    {
        // Enable or disable the upgrade button based on available currency and service level
        if (bal >= costPerLevel && room.serviceLevel <= 74)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }

    public IEnumerator UpgradeHold()
    {
        // Handle upgrade button hold behavior
        startTimer = false;
        while (isHolding)
        {
            UpgradeClick();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void OnUpgradeDown()
    {
        // Triggered when the upgrade button is pressed
        startTimer = true;
    }

    public void OnUpgradeUp()
    {
        // Triggered when the upgrade button is released
        startTimer = false;
        isHolding = false;
        holdTimer = 0;
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

    public void CalculateCost()
    {
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
        // Update the hard currency UI element
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }

    public void VisualUpgrade(int level)
    {
        // Visual upgrades for specific service levels
        switch (level)
        {
            case 13:
                upgradeEffect1.Play();
                visualChange1[0].SetActive(true);
                visualChange1[0].transform.DOScale(new Vector3(1, 1, 1), 1f);
                break;
            case 25:
                SizeExpansion();
                break;
            case 38:
                LampPlantUpgrade();
                break;
            case 50:
                SizeExpansion2();
                break;
            case 63:
                StartCoroutine(LampPlantUpgrade1());
                break;
        }
    }

    public void SizeExpansion()
    {
        // Visual upgrade for service level 25
        starEffect.SetActive(true);
        upgradeEffect2.Play();
        wallFloor[1].SetActive(true);
        wallFloor[1].transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        hireUI[0].SetActive(true);
        hireButtons[0].SetActive(true);
        wallFloor[0].gameObject.SetActive(false);
        visualChange1[1].SetActive(true);
        visualChange1[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        Destroy(equipmentLevel1[0].gameObject);
        foreach (GameObject item in equipmentLevel2)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
    }

    public void SizeExpansion2()
    {
        // Visual upgrade for service level 50
        starEffect1.SetActive(true);
        upgradeEffect2.Play();
        wallFloor[2].SetActive(true);
        wallFloor[2].transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        hireUI[1].SetActive(true);
        hireButtons[1].SetActive(true);
        //Destroy(wallFloor[1].gameObject);
        wallFloor[1].gameObject.SetActive(false);
        visualChange2[2].SetActive(true);
        visualChange2[2].transform.DOScale(new Vector3(1, 1, 1), 1f);
        foreach (GameObject item in equipmentLevel2)
        {
            Destroy(item);
        }
        foreach (GameObject item in equipmentLevel3)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
    }

    public void LampPlantUpgrade()
    {
        // Visual upgrade for service level 38
        upgradeEffect1.Play();
        upgradeEffect3.Play();

        foreach (GameObject item in visualChange1)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in visualChange2)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
    }

    public IEnumerator LampPlantUpgrade1()
    {
        // Visual upgrade for service level 63
        upgradeEffect1.Play();
        upgradeEffect3.Play();
        upgradeEffect4.Play();
        foreach (GameObject item in visualChange2)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in visualChange3)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
        yield return new WaitForSeconds(2);
        Destroy(upgradeEffect1.gameObject);
        //Destroy(upgradeEffect2.gameObject);
        Destroy(upgradeEffect3.gameObject);
        Destroy(upgradeEffect4.gameObject);
    }

    public void FinalUpgrade()
    {
        Destroy(upgradeEffect.gameObject);
    }

    public void ScaleDown()
    {
        foreach (GameObject item in visualChange1)
        {
            item.SetActive(false);
            item.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f);
        }
        foreach (GameObject item in visualChange2)
        {
            item.SetActive(false);
            item.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f);
        }
        foreach (GameObject item in visualChange3)
        {
            item.SetActive(false);
            item.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f);
        }
        foreach (GameObject item in equipmentLevel2)
        {
            item.SetActive(false);
            item.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f);
        }
        foreach (GameObject item in equipmentLevel3)
        {
            item.SetActive(false);
            item.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f);
        }
    }

    public void LoadData()
    {
        for (int i = 2; i <= room.serviceLevel; i++)
        {
            UpgradeSave(i);
        } 
    } 
}
