using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }
    public List<Task> tasks = new List<Task>();
    [SerializeField] int currentTaskNo;
    [SerializeField] Task currentActiveTask;
    public TaskPanel taskPanel;
     
    public TextMeshProUGUI collectMoneyTxt;  
    [SerializeField] float taskProgress = 0;
    [SerializeField] float totalearnings; 

    //Tasks
    public static Action BuildReceptionAction; 
    public static Action BuildAction; 
    public static Action UpgradeAction; 
    public static Action <int> CollectTipsAction;
    
    public static Action <int> GiveServiceAction; 
    public static Action UpgradeCashierAction;  
    //public static Action BuyInteriorAction; 
    //public static Action IncreaseSpaLevelAction; 


    public Task CurrentActiveTask
    {
        get => currentActiveTask;
        set
        {
            currentActiveTask = value;
            taskPanel.TaskName = CurrentActiveTask.taskName;

            if (TaskProgress == 0)
                taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
            else
            {
                taskPanel.Progress = TaskProgress;
                CurrentActiveTask.taskType.SetProgress(TaskProgress);
            }
            taskPanel.taskButton.onClick.RemoveAllListeners();
            taskPanel.taskButton.onClick.AddListener(CurrentActiveTask.taskType.GoToTarget);
            CurrentActiveTask.taskType.CheckIsTaskCompleted();
        }
    }
    public void SetSliderValue(string value)
    {
        taskPanel.SetSliderValue(value);
    }
    public int CurrentTaskNo
    {
        get => currentTaskNo;
        set
        {
            currentTaskNo = value;

            if (currentTaskNo < tasks.Count)
                CurrentActiveTask = tasks[currentTaskNo];
            else
                taskPanel.incompletePanel.SetActive(false);
        }
    }

    public float Totalearnings
    {
        get => totalearnings;
        set
        {
            totalearnings = value;
        }
    }

    public float TaskProgress
    {
        get => taskProgress;
        set
        {
            taskProgress = value;
            PlayerPrefs.SetFloat("BabySpa_TaskProgress", taskProgress);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        BuildReceptionAction += BuildReception;
        BuildAction += BuildTask;
        UpgradeAction += UpgradeTask;
        CollectTipsAction += CollectTipTask;
        GiveServiceAction += GiveServiceTask;
        UpgradeCashierAction += UpgradeCashier; 
        //BuyInteriorAction += BuyInteriorTask;
        //IncreaseSpaLevelAction += IncreaseLevelTask;
    }

    private void OnDisable()
    {
        BuildReceptionAction -= BuildReception; 
        BuildAction -= BuildTask;
        UpgradeAction -= UpgradeTask; 
        CollectTipsAction -= CollectTipTask;
        GiveServiceAction -= GiveServiceTask;
        UpgradeCashierAction -= UpgradeCashier; 
        //BuyInteriorAction -= BuyInteriorTask;
        //IncreaseSpaLevelAction -= IncreaseLevelTask; 
    }

    void BuildReception()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void BuildTask()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void UpgradeTask()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void CollectTipTask(int value)
    {
        currentActiveTask.GetComponent<CollectTips>().currentLevel += value;
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void GiveServiceTask(int value)
    {
        currentActiveTask.GetComponent<GiveService>().currentLevel += value;

        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void UpgradeCashier()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void BuyInteriorTask()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }void IncreaseLevelTask()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }
    void UpgradeParkingTask()
    {
        taskPanel.Progress = CurrentActiveTask.taskType.CheckCurrentProgress();
        CurrentActiveTask.taskType.CheckIsTaskCompleted();
    }

    public void NextTaskCall()
    {  
        //Reset Progress for Next Task
        TaskProgress = 0;

        StartCoroutine(NextTask());
    }

    private IEnumerator Start()
    {
        taskPanel.gameObject.SetActive(false);
        TaskProgress = PlayerPrefs.GetFloat("BabySpa_TaskProgress", 0);
        yield return new WaitForSeconds(0.1f);
        taskPanel.gameObject.SetActive(true);
        CurrentTaskNo = PlayerPrefs.GetInt("BabySpa_CurrentTask", 0);
    } 

    IEnumerator NextTask()
    { 
        taskPanel.Reset();
        yield return new WaitForSeconds(0.3f);
        CurrentTaskNo++;
        PlayerPrefs.SetInt("BabySpa_CurrentTask", CurrentTaskNo);

        if (CurrentTaskNo < tasks.Count)
            taskPanel.gameObject.SetActive(true);
    }
     
}
