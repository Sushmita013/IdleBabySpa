using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Departments
{
    Reception,
    WaterTaining,
    Massage,
    Haircut,
    Pamper,
    Playroom,
    PhotoRoom,
    Cafeteria,
    Cleaning,
    Bathroom
}
public class Room : MonoBehaviour
{
    public static Room instance;
    public int totalUpgrades;
    public int totalHires; 

    public Button hireButton; 
    public List<ServiceHire> hires_worker;

    public float hireCost;

    public GameObject UpgradePanel;

    public Departments roomName;

    void Start()
    {
        instance = this; 
         
        hireButton.onClick.AddListener(OnNewHire);
    }

    public void UpdateValues(Departments room)
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        CanvasManager.instance.totalHires.text = totalHires.ToString();
        switch (room)
        {
            case Departments.Reception:
                PlayerPrefs.SetInt("Receptionist", totalHires); 
                break;
            case Departments.WaterTaining:
                PlayerPrefs.SetInt("Trainer", totalHires); 
                break;
            case Departments.Massage:
                PlayerPrefs.SetInt("Masseuse", totalHires);

                break;
            case Departments.Haircut:
                PlayerPrefs.SetInt("Dresser", totalHires);

                break;
            case Departments.Pamper:
                PlayerPrefs.SetInt("Nurse", totalHires);

                break;
            case Departments.Playroom:
                PlayerPrefs.SetInt("Nanny", totalHires);

                break;
            case Departments.PhotoRoom:
                PlayerPrefs.SetInt("Photographer", totalHires);

                break;
            case Departments.Cafeteria:
                PlayerPrefs.SetInt("Waiters", totalHires);

                break;
        }
    }
     

        public void OnNewHire()
    {
        if(totalHires == 0)
        {  
            if(GameManager.instance.totalBalance >= hireCost)
            {
                GameManager.instance.totalBalance -= hireCost;
            StartCoroutine(hires_worker[totalHires].PlayEffects());
            totalHires++;
            UpdateValues(roomName);
            }
        } else if (totalHires == 1)
        {
            if (GameManager.instance.totalBalance >= hireCost)
            {
                GameManager.instance.totalBalance -= hireCost; 
                StartCoroutine(hires_worker[totalHires].PlayEffects());
                totalHires++;
                UpdateValues(roomName);
            }
        }
        else
        {
            if (GameManager.instance.totalBalance >= hireCost)
            {
                GameManager.instance.totalBalance -= hireCost; 
                StartCoroutine(hires_worker[totalHires].PlayEffects());
                totalHires++;
                UpdateValues(roomName);
                hireButton.interactable = false;
            }
        } 
    }

    //public void UpgradeClick()
    //{
    //    startLevel++;
    //    costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
    //    incomePerLevel += income_Increase;
    //    //incomePerLevel += incomePerLevel * (income_Increase / 100);
    //    costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
    //    incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
    //    Debug.Log("Cost " + startLevel + ": " + costPerLevel);
    //    Debug.Log("Income " + startLevel + ": " + incomePerLevel);
    //}

}
