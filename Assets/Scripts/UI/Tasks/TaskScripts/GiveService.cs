using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveService : ITaskType
{
    public RoomManager roomManager;

    public int currentLevel;
    public int targetLevel;
    public override float CheckCurrentProgress()
    { 
        var progress = (float)currentLevel / (float)targetLevel;
        TaskManager.Instance.SetSliderValue($"{currentLevel}/{targetLevel}");
        return progress;
    }

    public override bool CheckIsTaskCompleted()
    { 

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
        roomManager.CamZoom();
    }
}

