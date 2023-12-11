using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float totalSoftCurrency;
    public float totalHardCurrency;  

    public bool massageUnlocked;
    public bool haircutUnlocked;
    private void Awake()
    {
        instance = this;
        totalSoftCurrency = 99999;
    } 
     
}
