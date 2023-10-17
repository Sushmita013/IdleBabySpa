using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipManager : MonoBehaviour
{
    public static TipManager instance;

    public int collectedTips;

    void Start()
    {
        instance = this;
    }
     
    void Update()
    { 
        if (collectedTips <= 3)
        {
            TaskManager.instance.taskList[0].progressionSlider.value = collectedTips;
            TaskManager.instance.taskList[0].progressText.text = collectedTips.ToString();
            if (collectedTips == 3)
            { 
            StartCoroutine(TaskManager.instance.taskList[0].TaskComplete());
            collectedTips = 0;
            }
        }
    }
}
