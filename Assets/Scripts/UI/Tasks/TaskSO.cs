using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Task",menuName ="BabySpa Task/Create New Task",order =1)]
[Serializable]
public class TaskSO : ScriptableObject
{
    public string taskName;

    public TaskType taskType;
}
