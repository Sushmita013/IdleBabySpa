using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Cashier : MonoBehaviour
{
    public bool isUnlocked;

    public int cashierLevel;

    public float cashierSpeed;
    public float costPerLevel;

    private int childrenDestroyed; 
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
    public GameObject service1;

    public List<ParticleSystem> effects; 

    void Start()
    { 
        foreach (ParticleSystem item in effects)
        {
            item.Stop();
        }
        hireButton.onClick.AddListener(() => StartCoroutine(HireCashier()));
        upgradeButton.onClick.AddListener(UpgradeClick);
    }

    public IEnumerator HireCashier()
    {
        if (GameManager.instance.totalBalance >= hireCost && !isUnlocked)
        {
            isUnlocked = true;
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalBalance -= hireCost;
            Reception.instance.totalCashiers++; 
            UpdateValues();
            if (Reception.instance.totalCashiers == 1)
            {
                StartCoroutine(Reception.instance.taskList[0].TaskComplete());
            }
            if (Reception.instance.totalCashiers == 2)
            {
                StartCoroutine(Reception.instance.taskList[2].TaskComplete());
            }
            service.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.05f);
            service1.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);

            effects[0].Play();
            effects[1].Play();
            yield return new WaitForSeconds(0.10f);
            service.SetActive(true);
            service.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            service1.SetActive(true);
            service1.transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.75f);

            yield return new WaitForSeconds(0.5f);
            Destroy(effects[0].gameObject);
            Destroy(effects[1].gameObject); 
        }
    }

    public void UpdateValues()
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        Reception.instance.totalHires_text.text = Reception.instance.totalCashiers.ToString();
        PlayerPrefs.SetInt("Receptionist", Reception.instance.totalCashiers);
    }

    public void UpgradeClick()
    {
        effects[2].Play();
        if(GameManager.instance.totalBalance >= costPerLevel)
        {
            GameManager.instance.totalBalance -= costPerLevel;
            UpdateValues();
            cashierLevel++;
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        cashierSpeed += cashierSpeed * (speed_percentageIncrease / 100);
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        cashierSpeed = Mathf.Round(cashierSpeed * 100) / 100; // Round to 2 decimal place

        levelText.text = cashierLevel.ToString();
        upgradeCostText.text = costPerLevel.ToString();
        speedText.text = cashierSpeed.ToString();
        } 
        if(cashierLevel == 5)
        {
            StartCoroutine(Reception.instance.taskList[1].TaskComplete()); 
        } 
        if(cashierLevel == 5)
        {
            StartCoroutine(Reception.instance.taskList[3].TaskComplete()); 
        }  
    }

}
