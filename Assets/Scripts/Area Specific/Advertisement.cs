using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Advertisement : MonoBehaviour
{
    public float costPerLevel;
    public float incomePerLevel; 

    public TMP_Text service_cost;
    public TMP_Text level;
    public TMP_Text upgrade_cost;

    public Departments roomName;

    public RoomManager room;

    public int multiplier;

    public List<Slider> levelSlider;

    public List<TaskButton3> taskList;

    public List<TMP_Text> levelText;

    public Button upgradeButton;

    public List<GameObject> panels;

    public ParticleSystem upgradeEffect;


    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeClick);
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
            if (room.serviceLevel == 3)
            {

            }
            room.serviceLevel++;
            UpdateCost();
        }
    }

    public void UpdateCost()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            GameManager.instance.totalSoftCurrency -= costPerLevel;
            CanvasManager.instance.UpdateSoftCurrency();
            costPerLevel *= 2;
            incomePerLevel += 1;
            room.serviceCost = costPerLevel;
            service_cost.text = costPerLevel.ToString();
            upgrade_cost.text = incomePerLevel.ToString();
            level.text = room.serviceLevel.ToString();
        }
    }

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }
}
