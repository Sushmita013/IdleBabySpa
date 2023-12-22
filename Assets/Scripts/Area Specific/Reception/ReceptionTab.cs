using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using MoreMountains.NiceVibrations;


public class ReceptionTab : MonoBehaviour
{
    public bool isUnlocked;

    public int receptionistLevel;

    public float receptionistSpeed;
    public float costPerLevel;
      
    public float hireCost;
    public float cost_percentageIncrease;
    public float speed_percentageIncrease; 

    public Button upgradeButton;
    public Button hireButton; 

    public TMP_Text speedText;
    public TMP_Text levelText;
    public TMP_Text upgradeCostText;

    public GameObject unlocked;
    public GameObject locked;
    public GameObject service; 

    public List<ParticleSystem> effects;
    public bool isHolding;
    public bool startTimer;

    public float holdTimer;

    void Start()
    { 
        foreach (ParticleSystem item in effects)
        {
            item.Stop();
        }
        hireButton.onClick.AddListener(() => StartCoroutine(HireCashier()));
        upgradeButton.onClick.AddListener(UpgradeClick);
        LoadData();
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

    public IEnumerator HireCashier()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !isUnlocked)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            isUnlocked = true;
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost;
            Reception.instance.totalCashiers++; 
            CanvasManager.instance.UpdateSoftCurrency(); 
             
            service.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.05f);
            //service1.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);

            effects[0].Play();
            effects[1].Play();
            yield return new WaitForSeconds(0.10f);
            service.SetActive(true);
            service.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            //service1.SetActive(true);
            //service1.transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.75f);

            yield return new WaitForSeconds(0.5f);
            effects[0].Stop();
            effects[1].Stop();
            //Destroy(effects[0].gameObject);
            //Destroy(effects[1].gameObject); 
        }
        SaveManager.instance.SaveDataCall();


    }

    public void EnableDisableUpgrade(float bal)
    {
        if (bal >= costPerLevel && receptionistLevel < 15)
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
        startTimer = false;
        while (isHolding)
        {
            UpgradeClick();
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

    public void UpgradeClick()
    {
        if(GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            effects[0].Play(); 
            GameManager.instance.totalSoftCurrency -= costPerLevel;
            CanvasManager.instance.UpdateSoftCurrency();
            receptionistLevel++;
            UpdateValues();
        }
        SaveManager.instance.SaveDataCall();
        if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.UpgradeCashier)
        {
            TaskManager.UpgradeCashierAction?.Invoke();
        }
    }
     

    public void UpdateValues()
    {
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        receptionistSpeed += receptionistSpeed * (speed_percentageIncrease / 100);
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        receptionistSpeed = Mathf.Round(receptionistSpeed * 100) / 100; // Round to 2 decimal place

        levelText.text = receptionistLevel.ToString();
        upgradeCostText.text = costPerLevel.ToString();
        speedText.text = receptionistSpeed.ToString();
    }

    public void LoadData()
    {
        for(int i = 1; i <= receptionistLevel; i++)
        {
            UpdateValues();
        }
    }

}