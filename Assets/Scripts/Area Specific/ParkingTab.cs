using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class ParkingTab : IService
{
    // Public variables
    public float costPerLevel;              // Cost for upgrading
    public float spacesPerLevel;            // Income gained per upgrade
    public float cost_percentageIncrease;   // Percentage increase in cost
    public float spacesIncrease;           // Income increase per upgrade

    // Text elements displaying upgrade cost and income value
    public TMP_Text cost_upgrade;
    public TMP_Text spacesvalue;

    public RoomManager room;                // Reference to RoomManager 

    // Sliders for tracking service level progress
    public List<Slider> levelSlider;

    // Text displaying service level
    public List<TMP_Text> level;

    public Button upgradeButton;            // Button to trigger the upgrade

    // Lists of UI panels and various visual elements
    public List<GameObject> panels;

    public List<GameObject> levels; 

    // Particle effect for upgrades
    public ParticleSystem upgradeEffect;

    public int count;

    // Private variables
    private bool isHolding;                 // Flag for holding upgrade button
    private bool startTimer;                // Flag for starting upgrade timer
    private float holdTimer;                // Timer for upgrade button hold duration
     

    void Start()
    {
        // Add a listener for the upgrade button click event
        upgradeButton.onClick.AddListener(UpgradeClick);
        // Stop all upgrade effect particle systems initially
        upgradeEffect.Stop(); 
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
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            upgradeEffect.Play();
            levels[count].SetActive(true); 
            count ++;
            room.serviceLevel++; 
            level[0].text = room.serviceLevel.ToString();
            levelSlider[0].value = room.serviceLevel;
            UpdateCost(); 
             
        }
        if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.UpgradeTask)
        {
            TaskManager.UpgradeAction?.Invoke();
        }
    }

    public void EnableDisableUpgrade(float bal)
    {
        // Enable or disable the upgrade button based on available currency and service level
        if (bal >= costPerLevel && room.serviceLevel < 5)
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
        spacesPerLevel += spacesIncrease;
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        spacesPerLevel = Mathf.Round(spacesPerLevel * 10) / 10; // Round to 1 decimal place
        room.serviceCost = spacesPerLevel;
        cost_upgrade.text = costPerLevel.ToString();
        spacesvalue.text = spacesPerLevel.ToString();
        CarManager.instance.unlockedSlotsCount = ((int)spacesPerLevel);
        CarManager.instance.UpdateSpots(); 
        CarManager.instance.EnableParkingSlot();
    }

    public void LoadData()
    {
         
    }
}
