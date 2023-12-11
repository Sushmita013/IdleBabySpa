using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCashier : ITaskType
{
    public Reception reception;

    public int currentLevel;
    public int targetLevel;
    public override float CheckCurrentProgress()
    {
        currentLevel = reception.receptionistList[0].receptionistLevel;
        var progress = (float)currentLevel / (float)targetLevel;
        TaskManager.Instance.SetSliderValue($"{currentLevel}/{targetLevel}");
        return progress;
    }

    public override bool CheckIsTaskCompleted()
    {
        currentLevel = reception.receptionistList[0].receptionistLevel; 

        if (currentLevel >= targetLevel)
            return true;
        else
            return false;
    }

    public override void SetProgress(float progress)
    {
        currentLevel = (int)(progress * targetLevel);
    }
    public override void GoToTarget()
    {
        StartCoroutine(reception.CameraZoomIn()); 
    }
}
