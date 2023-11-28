using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float totalSoftCurrency;
    public float totalHardCurrency;
    public int totalUpgrades;

    public int totalDecor;

    //public int reception_hires;
    //public int water_hires;
    //public int massage_hires;
    //public int haircut_hires;
    //public int pamper_hires;
    //public int play_hires;
    //public int photo_hires;
    //public int cafe_hires;

    public bool massageUnlocked;
    public bool haircutUnlocked;
    private void Awake()
    {
        instance = this;
        totalSoftCurrency = 40000;
        totalHardCurrency = 0; 
        //reception_hires = PlayerPrefs.GetInt("Receptionist");
        //water_hires = PlayerPrefs.GetInt("Trainer");
        //massage_hires = PlayerPrefs.GetInt("Masseuse");
        //haircut_hires = PlayerPrefs.GetInt("Dresser");
        //pamper_hires = PlayerPrefs.GetInt("Nurse");
        //play_hires = PlayerPrefs.GetInt("Nanny");
        //photo_hires = PlayerPrefs.GetInt("Photographer");
        //cafe_hires = PlayerPrefs.GetInt("Waiters");
    }
    void Start()
    { 
        instance = this;
    } 
}
