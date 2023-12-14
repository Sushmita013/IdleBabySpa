using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using AssetKits.ParticleImage;



public class Advertisement : IService
{
    public float costPerLevel;
    public float personPerMin;

    public TMP_Text personInfo;
    public TMP_Text upgrade_cost;

    public Departments roomName;

    public RoomManager room;

    public int multiplier;

    public List<Slider> levelSlider;

    public List<TMP_Text> levelText;

    public Button upgradeButton;

    public List<GameObject> panels;

    public ParticleSystem upgradeEffect;

    public ParticleImage particleImage;
    public ParticleImage sliderEffect;

    public bool isHolding;
    public bool startTimer;

    public float holdTimer;


    void Start()
    {
        upgradeEffect.Stop();
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

    private void OnMouseDown()
    {
        Reception.instance.CamZoom();
        room.ResetPanels();
        //uiPanel.transform.DOMoveY(0, 1f);
    }

    public void UpgradeClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            if (room.serviceLevel < 9)
            {
                MMVibrationManager.Haptic(HapticTypes.MediumImpact);
                upgradeEffect.Play();
                particleImage.Play();
                sliderEffect.Play();
                room.serviceLevel++;
                levelText[0].text = room.serviceLevel.ToString();
                levelSlider[0].value = room.serviceLevel;
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
        levelText[0].text = i.ToString();
        levelSlider[0].value = i;
        CalculateCost();
    }

    public void KeyboardName()
    {
        KeyboardManager.Instance.printBox.text = "";
        //KeyboardManager.Instance.printbo.text = "";
    }
    public void EnableDisableUpgrade(float bal)
    {
        if (bal >= costPerLevel && room.serviceLevel < 9)
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

    public void UpdateCost()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            GameManager.instance.totalSoftCurrency -= costPerLevel;
            CanvasManager.instance.UpdateSoftCurrency();
            costPerLevel *= 2;
            personPerMin += 1;
            room.serviceCost = costPerLevel;
            personInfo.text = costPerLevel.ToString();
            upgrade_cost.text = personPerMin.ToString();
            SaveManager.instance.SaveDataCall(); 
        }
    }
    public void CalculateCost()
    {

        costPerLevel *= 2;
        personPerMin += 1;
        room.serviceCost = costPerLevel;

        personInfo.text = costPerLevel.ToString();
        upgrade_cost.text = personPerMin.ToString();
    }

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }

    public void LoadData()
    {
        for (int i = 2; i <= room.serviceLevel; i++)
        {
            UpgradeSave(i);
        }
    }
     
}
