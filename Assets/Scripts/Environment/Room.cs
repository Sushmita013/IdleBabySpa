using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Furniture
{
    Sofa,
    Tv,
    Plants
}
public class Room : MonoBehaviour
{
    public static Room instance;
    public int totalUpgrades;
    public int totalHires; 

    public Button hireButton;
    //public List<GameObject> decor;
    public List<ServiceHire> hires_worker;

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

    public void Upgrade(Furniture furniture)
    {
        switch (furniture)
        {
            case Furniture.Sofa:  
                break;
            case Furniture.Tv: 
                break;
            case Furniture.Plants: 
                break;
        }
    }

    public void OnNewHire()
    {
        if(totalHires == 0)
        { 
        //hires_worker[0].gameObject.SetActive(true);
            StartCoroutine(hires_worker[0].PlayEffects());
            totalHires++;
        } else if (totalHires == 1)
        {
            StartCoroutine(hires_worker[1].PlayEffects());
            totalHires++;
        }
        else
        {
            StartCoroutine(hires_worker[2].PlayEffects());
            totalHires++;
            hireButton.interactable=false;
        }
        //if(totalHires == 1)
        //{ 
        ////hires_worker[1].gameObject.SetActive(true);
        //    StartCoroutine(hires_worker[1].PlayEffects());
        //    totalHires++;
        //}
        //if(totalHires == 2)
        //{ 
        //hires_worker[2].gameObject.SetActive(true);
        //    totalHires++;
        //    hires_worker[2].PlayEffects();
        //}
    }
     
}
