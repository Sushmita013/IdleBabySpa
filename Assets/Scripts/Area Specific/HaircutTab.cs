using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HaircutTab : IService
{
    // Public variables
    public float costPerLevel;              // Cost for upgrading
    public float incomePerLevel;            // Income gained per upgrade
    public float cost_percentageIncrease;   // Percentage increase in cost
    public float income_Increase;           // Income increase per upgrade

    public TMP_Text cost_upgrade;           // Text displaying upgrade cost
    public TMP_Text income_value;           // Text displaying income value

    public RoomManager room;                // Reference to RoomManager

    public int multiplier;                  // Income multiplier

    public List<Slider> levelSlider;        // Sliders for tracking service level progress 

    public List<TMP_Text> level;            // Text displaying service level

    public Button upgradeButton;            // Button to trigger the upgrade

    public List<GameObject> panels;          // List of UI panels
    public List<GameObject> coolerPhoto; // List of plant room lamps 
    public List<GameObject> coolerPhoto2; // List of plant room lamps 
    public List<GameObject> coolerPhoto3; // List of plant room lamps 
    public GameObject hairDresser; // List of table for level 1
    public List<GameObject> hairDresser2; // List of table for level 2 
    public List<GameObject> hairDresser3; // List of table for level 3 
    public List<GameObject> wallFloor;       // List of wall and floor objects
    public List<GameObject> services;        // List of service objects

    public ParticleSystem upgradeEffect;    // Particle effect for upgrades
    public ParticleSystem upgradeEffect1;   // Particle effect for upgrades (level 13)
    public ParticleSystem upgradeEffect2;   // Particle effect for upgrades (level 25)
    public ParticleSystem upgradeEffect3;   // Particle effect for upgrades (level 38)
    public ParticleSystem upgradeEffect4;   // Particle effect for upgrades (level 63)

    // Private variables
    private bool isHolding;                 // Flag for holding upgrade button
    private bool startTimer;                // Flag for starting upgrade timer
    private float holdTimer;                // Timer for upgrade button hold duration

    public GameObject starEffect;
    public GameObject starEffect1;

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

            if (room.serviceLevel <= 25)
            {
                // Handle upgrades based on service level up to 25
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.2f;
                room.serviceLevel++;
                //taskList[0].progressText.text = room.serviceLevel.ToString();
                //taskList[0].progressionSlider.value = room.serviceLevel;

                // Additional logic for specific service levels
                if (room.serviceLevel == 2)
                {
                    Camera.main.GetComponent<PanZoom>().enabled = true;
                }
                if (room.serviceLevel == 13)
                {
                    VisualUpgrade(13);
                }
                if (room.serviceLevel == 25)
                {
                    VisualUpgrade(25);
                    multiplier = 2;
                    incomePerLevel *= multiplier;
                    income_Increase = 0.4f;
                    //StartCoroutine(taskList[0].TaskComplete());

                    // Move UI panels for service level 25
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
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
            else if (room.serviceLevel > 25 && room.serviceLevel <= 50)
            {
                // Handle upgrades based on service level from 26 to 50
                room.serviceLevel++;
                //taskList[1].progressText.text = room.serviceLevel.ToString();
                //taskList[1].progressionSlider.value = room.serviceLevel;

                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.4f;
                if (room.serviceLevel == 38)
                {
                    VisualUpgrade(38);
                }
                if (room.serviceLevel == 50)
                {
                    VisualUpgrade(50);
                    multiplier = 3;
                    incomePerLevel *= multiplier;
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
                //taskList[2].progressText.text = room.serviceLevel.ToString();
                //taskList[2].progressionSlider.value = room.serviceLevel;
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 1.2f;
                if (room.serviceLevel == 63)
                {
                    VisualUpgrade(63);
                }
                if (room.serviceLevel == 75)
                {
                    FinalUpgrade();
                    //StartCoroutine(taskList[2].TaskComplete());
                    multiplier = 4;
                    incomePerLevel *= multiplier;
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
                coolerPhoto[0].SetActive(true);
                coolerPhoto[0].transform.DOScale(new Vector3(1, 1, 1), 1f);
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
        services[1].SetActive(true);
        services[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        Destroy(wallFloor[0].gameObject);
        coolerPhoto[1].SetActive(true);
        coolerPhoto[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        Destroy(hairDresser.gameObject);
        foreach (GameObject item in hairDresser2)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f);
        } 
    }

    public void SizeExpansion2()
    {
        // Visual upgrade for service level 50
        starEffect1.SetActive(true);
        upgradeEffect2.Play();
        wallFloor[2].SetActive(true);
        wallFloor[2].transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        services[2].SetActive(true);
        services[2].transform.DOScale(new Vector3(1, 1, 1), 1f);
        Destroy(wallFloor[1].gameObject);
        coolerPhoto2[2].SetActive(true);
        coolerPhoto2[2].transform.DOScale(new Vector3(1, 1, 1), 1f);
        foreach (GameObject item in hairDresser2)
        {
            Destroy(item);
        }
        foreach (GameObject item in hairDresser3)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f);
        }
    }

    public void LampPlantUpgrade()
    {
        // Visual upgrade for service level 38
        upgradeEffect1.Play();
        upgradeEffect3.Play();
        Destroy(coolerPhoto[0].gameObject);
        foreach (GameObject item in coolerPhoto)
        {
            Destroy(item);
        }
        foreach (GameObject item in coolerPhoto2)
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
        foreach (GameObject item in coolerPhoto2)
        {
            Destroy(item);
        }
        foreach (GameObject item in coolerPhoto3)
        {
            item.SetActive(true);
            item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        }
        yield return new WaitForSeconds(2);
        Destroy(upgradeEffect1.gameObject);
        Destroy(upgradeEffect2.gameObject);
        Destroy(upgradeEffect3.gameObject);
        Destroy(upgradeEffect4.gameObject);

    }
    public void FinalUpgrade()
    {
        Destroy(upgradeEffect.gameObject);
    }
}
