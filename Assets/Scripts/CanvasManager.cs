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
     
    void Start()
    { 
        instance = this;
        taskNumber = 1;
        totalBalance_text.text = GameManager.instance.totalBalance.ToString();
        totalBalanceHard_text.text = GameManager.instance.totalBalance_hard.ToString(); 
    }

}

