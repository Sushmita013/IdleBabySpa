using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public TMP_Text totalBalance_text;
    public TMP_Text totalBalanceHard_text; 

    public Transform prefabParent1; 

    public GameObject buildPopup;
    public GameObject rewardPopup;
    public GameObject popupObject;
    public GameObject popupObject1;
     
    public List<GameObject> tasksGO; 

    public int taskNumber; 

    public Sprite completedTask;

    public int tipsCollected;
     
    void Start()
    {
        Camera.main.transform.position = new Vector3(-125f, 60, -70);
        Camera.main.orthographicSize = 20;
        instance = this;
        taskNumber = 1;
        GameManager.instance.totalSoftCurrency = Mathf.Round(GameManager.instance.totalSoftCurrency * 10) / 10; // Round to 1 decimal place 
        totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString(); 
    }

    public void UpdateSoftCurrency()
    {
        GameManager.instance.totalSoftCurrency = Mathf.Round(GameManager.instance.totalSoftCurrency * 10) / 10; // Round to 1 decimal place 
        totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
    }
    public void UpdateHardCurrency()
    {
        totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }

}

