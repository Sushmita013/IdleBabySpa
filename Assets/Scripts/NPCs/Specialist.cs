using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using MoreMountains.NiceVibrations;


public class Specialist : MonoBehaviour
{
    public RoomManager room; 

    public int workerSpeedLevel; 

    public float workerSpeed; 
    public float costPerLevel; 

    private int childrenDestroyed;
    
    public float cost_percentageIncrease;
    public float speed_percentageIncrease; 
     
    public Button upgradeSpeedButton;

    public TMP_Text speedText; 
    public TMP_Text upgradeCostText;
     
    public ParticleSystem effect; 
    
    public bool isHolding;
    public bool startTimer;

    public float holdTimer;


    void Start()
    { 
        effect.Stop();
        upgradeSpeedButton.onClick.AddListener(UpdateClick); 
    }

    private void Update()
    {
        if (startTimer)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= 0.75f)
            {
                isHolding = true;
                StartCoroutine(UpgradeHold());
            }
        }
        EnableDisableUpgrade(GameManager.instance.totalSoftCurrency);
    }

    

    public void UpdateClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            GameManager.instance.totalSoftCurrency -= costPerLevel;
            CanvasManager.instance.UpdateSoftCurrency();
            effect.Play();
            workerSpeedLevel++;
            UpgradeSpeed();
        }

    }
    public void UpgradeSpeed()
    {  
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        workerSpeed += workerSpeed * (speed_percentageIncrease / 100); 
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        workerSpeed = Mathf.Round(workerSpeed * 10) / 10; // Round to 1 decimal place 
        upgradeCostText.text = costPerLevel.ToString();
        speedText.text = workerSpeed.ToString(); 
    }

    public void EnableDisableUpgrade(float bal)
    {
        if (bal >= costPerLevel && workerSpeedLevel<=5)
        {
            upgradeSpeedButton.interactable = true;
        }
        else
        {
            upgradeSpeedButton.interactable = false;

        }
    }

    public IEnumerator UpgradeHold()
    {
        startTimer = false;
        while (isHolding)
        {
            UpdateClick();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void OnUpgradeDown()
    {
        startTimer = true;
    }
    public void OnUpgradeUp()
    {
        startTimer = false;
        isHolding = false;
        holdTimer = 0;
    } 

     

}
