using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ServiceUpgrade : MonoBehaviour
{
    public Departments roomName; 
    public int startLevel;
    public float startCost;
    public float startIncome;
    public int endLevel;
     
    public Button upgradeLevel; 

    
    
    public float cost_percentageIncrease;
    public float income_Increase;

    public float costPerLevel;
    public float incomePerLevel;

    public TMP_Text cost_per_Level;
    public TMP_Text income_per_Level;
    public TMP_Text current_Level;

    

    void Start()
    {
        //startLevel = 1;
        //endLevel = 25;

        //startCost = 2;
        //startIncome = 2;

        //cost_percentageIncrease = 6;
        //income_Increase = 0.2f;
         
        //costPerLevel = startCost;
        //incomePerLevel = startIncome; 


    }

    

    

     


}
