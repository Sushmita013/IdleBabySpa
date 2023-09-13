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
    //public List<GameObject> decor;
    public List<ServiceHire> hires_worker;

    public float hireCost;

    public Departments roomName;

    //public int decorUpgrades;

    //public Furniture furnitureType;

    //public float sofaCost;
    //public float tvCost;
    //public float plantsCost;

    //public int sofaLevel;
    //public int tvLevel;
    //public int plantsLevel;
     
    void Start()
    {
        instance = this;
        hireButton.onClick.AddListener(OnNewHire);
    }

    public void UpdateValues(Departments room)
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalBalance.ToString();
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
     
}
