using UnityEngine;


public abstract class ITaskType : MonoBehaviour
{
    public abstract bool CheckIsTaskCompleted();

    public abstract float CheckCurrentProgress();

    public abstract void SetProgress(float progress);
    public abstract void GoToTarget();

    //public abstract 
}
