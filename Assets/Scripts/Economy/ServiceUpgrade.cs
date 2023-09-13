using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceUpgrade : MonoBehaviour
{
    public int startLevel;
    public float startCost;
    public float startIncome;
    public int endLevel;

    public float cost_percentageIncrease;
    public float income_percentageIncrease;

    public float costPerLevel;
    public float incomePerLevel;

    void Start()
    {
        startLevel = 1;
        endLevel = 25;

        startCost = 2;
        startIncome = 2;

        cost_percentageIncrease = 6;
        income_percentageIncrease = 10;

        // Initialize cost and income for the first level
        costPerLevel = startCost;
        incomePerLevel = startIncome;

        // Loop through levels and calculate cost and income per level
        for (int level = startLevel + 1; level <= endLevel; level++)
        {
            costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
            incomePerLevel += incomePerLevel * (income_percentageIncrease / 100);
            costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
            incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
            Debug.Log("Cost " + level + ": " + costPerLevel);
            Debug.Log("Income " + level + ": " + incomePerLevel);
        }
    }

    public void UpgradeClick()
    {
        // Add upgrade logic here
    }
}
