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

    public int workerLevel;
    public int startLevel;

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
        hireButton.onClick.AddListener(() => StartCoroutine(HireWorker()));
        upgradeSpeedButton.onClick.AddListener(UpgradeSpeed);
    }

    public IEnumerator HireWorker()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !isUnlocked)
        {
            isUnlocked = true;
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost; 
            UpdateValues();
            if (Reception.instance.totalCashiers == 1)
            {
                StartCoroutine(Reception.instance.taskList[0].TaskComplete());
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
    public void UpgradeSpeed()
    {  
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        workerSpeed += workerSpeed * (speed_percentageIncrease / 100); 
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        workerSpeed = Mathf.Round(workerSpeed * 10) / 10; // Round to 1 decimal place 
        upgradeCostText.text = costPerLevel.ToString();
        speedText.text = workerSpeed.ToString();

    }

    public void UpdateValues()
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Reception.instance.totalHires_text.text = Reception.instance.totalCashiers.ToString();
        PlayerPrefs.SetInt("Receptionist", Reception.instance.totalCashiers);
    }

     

}
