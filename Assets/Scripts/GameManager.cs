using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int totalBalance;
    public int totalUpgrades;

    public int totalDecor;
    void Start()
    { 
        instance = this;
    } 
}
