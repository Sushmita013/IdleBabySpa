using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public class Task : MonoBehaviour
{
    public TaskSO taskObject;
    public string taskName;
    public ITaskType taskType;
    public int rewardValue;

    //private void OnValidate()
    //{
    //    if (!taskObject)
    //        return;

    //    gameObject.name = taskName = taskObject.taskName;

    //    UnityEditor.EditorApplication.delayCall += () =>
    //    {
    //        if (taskObject.taskType == TaskType.BuildReception)
    //        {
    //            taskType = gameObject.GetOrAddComponent<ReceptionBuild>();
    //        }
    //        else if (taskObject.taskType == TaskType.BuildTask)
    //        {
    //            taskType = gameObject.GetOrAddComponent<BuildTask>();
    //        }
    //        else if (taskObject.taskType == TaskType.UpgradeTask)
    //        {
    //            taskType = gameObject.GetOrAddComponent<UpgradeTask>();
    //        }
    //        //else if (taskObject.taskType == TaskType.SpendTask)
    //        //{
    //        //    taskType = gameObject.GetOrAddComponent<SpendTask>();
    //        //}
    //        //else if (taskObject.taskType == TaskType.TotalUpgradeTask)
    //        //{
    //        //    taskType = gameObject.GetOrAddComponent<TotalUpgradeTask>();
    //        //}
    //        //else if (taskObject.taskType == TaskType.TriviaCorrectTask)
    //        //{
    //        //    taskType = gameObject.GetOrAddComponent<TriviaCorrectTask>();
    //        //}
    //        //else if (taskObject.taskType == TaskType.CompleteCarTask)
    //        //{
    //        //    taskType = gameObject.GetOrAddComponent<CompleteCarTask>();
    //        //}

    //        foreach (var comp in gameObject.GetComponents<ITaskType>())
    //        {
    //            if (taskType != comp)
    //                DestroyImmediate(comp);
    //        }
    //    };

    //}
}
