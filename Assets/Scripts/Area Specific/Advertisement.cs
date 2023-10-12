using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Advertisement  : MonoBehaviour
{
    public float costPerLevel;
    public float incomePerLevel; 
    public int serviceLevel;
     
    public TMP_Text service_cost;
    public TMP_Text level;
    public TMP_Text upgrade_cost;

    public Departments roomName;
     

    public List<Slider> levelSlider;

    public Button upgradeButton;

    public List<GameObject> panels; 


    void Start()
    { 
        upgradeButton.onClick.AddListener(UpgradeClick); 
    }

    private void OnMouseDown()
    {
        Reception.instance.CamZoom();
        RoomManager.instance.ResetPanels();
        uiPanel.transform.DOMoveY(0, 1f);
    }

    public void UpgradeClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            serviceLevel++;
            UpdateCost();
        }
    }

    public void UpdateCost()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            GameManager.instance.totalSoftCurrency -= costPerLevel;
            //CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
            CanvasManager.instance.UpdateSoftCurrency();
            costPerLevel *= 2;
            incomePerLevel += 1;
            //costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
            //incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
            RoomManager.instance.serviceCost = costPerLevel;
            service_cost.text = costPerLevel.ToString();
            upgrade_cost.text = incomePerLevel.ToString();
            level.text = serviceLevel.ToString();
                }
    } 

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    } 
}
