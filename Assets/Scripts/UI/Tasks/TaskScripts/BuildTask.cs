using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTask : ITaskType
{
    public RoomManager roomManager;
    public override float CheckCurrentProgress()
    { 
        if (roomManager.isUnlocked)
        {
            TaskManager.Instance.SetSliderValue("1/1");
            return 1;
        }
        else
        {
            TaskManager.Instance.SetSliderValue("0/1"); 
            return 0;
        }
    }

    public override bool CheckIsTaskCompleted()
    { 
        if (roomManager.isUnlocked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void SetProgress(float progress)
    {
        throw new System.NotImplementedException(); 
    }

    public override void GoToTarget()
    {
        roomManager.CamZoom();
    }
}
