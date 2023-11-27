using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleted : MonoBehaviour
{
    public float rewardValue;
    public string taskName;

    public void OnClick()
    {
        CanvasManager.instance.ShowReward( taskName, rewardValue); Destroy(this.gameObject);
    }

}
