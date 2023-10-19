using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Worker : MonoBehaviour
{
    public RoomManager room;
    public bool isUnlocked; 

    public int workerSpeedLevel; 

    public float workerSpeed; 
    public float costPerLevel; 

    private int childrenDestroyed;
    public float hireCost;
    public float cost_percentageIncrease;
    public float speed_percentageIncrease; 
     
    public Button upgradeSpeedButton;
    public Button hireButton;

    public TMP_Text speedText; 
    public TMP_Text upgradeCostText;

    //public GameObject unlocked;
    //public GameObject locked;
    //public GameObject service;
    //public GameObject service1;

    //public List<ParticleSystem> effects;
    public ParticleSystem effect;
    public bool isHolding;
    public bool startTimer;

    public float holdTimer;



    void Start()
    {
        //foreach (ParticleSystem item in effects)
        //{
        //    item.Stop();
        //}
        effect.Stop();
        hireButton.onClick.AddListener(() => StartCoroutine(HireWorker()));
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

    public IEnumerator HireWorker()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !isUnlocked)
        {
            isUnlocked = true;
            //locked.SetActive(false);
            //unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost; 
            UpdateValues();
            if (Reception.instance.totalCashiers == 1)
            {
                StartCoroutine(Reception.instance.taskList[0].TaskComplete());
            }
            //service.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.05f);
            //service1.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);

            //effects[0].Play();
            //effects[1].Play();
            yield return new WaitForSeconds(0.10f);
            //service.SetActive(true);
            //service.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            //service1.SetActive(true);
            //service1.transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.75f);

            yield return new WaitForSeconds(0.5f);
            //Destroy(effects[0].gameObject);
            //Destroy(effects[1].gameObject);
        }
    }

    public void UpdateClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
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
        if (bal >= costPerLevel && workerSpeedLevel<=10)
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

    public void UpdateValues()
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Reception.instance.totalHires_text.text = Reception.instance.totalCashiers.ToString();
        PlayerPrefs.SetInt("Receptionist", Reception.instance.totalCashiers);
    }

     

}
