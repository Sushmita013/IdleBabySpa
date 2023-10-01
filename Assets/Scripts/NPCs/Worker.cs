using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Worker : MonoBehaviour
{
    public string workerType;   

    public bool isUnlocked;
    public bool isWorking;

    public int workerLevel;
    public int startLevel;

    public float workerSpeed; 

    private int childrenDestroyed;
    public float hireCost;
    public float cost_percentageIncrease;
    public float speed_percentageIncrease; 

    public Button upgradeButton;
    public Button upgradeSpeedButton;
    public Button hireButton;

    public TMP_Text speedText;
    public TMP_Text levelText;
    public TMP_Text upgradeCostText;
    public TMP_Text cost_per_Level;
    public TMP_Text income_per_Level;
    public TMP_Text current_Level;

    public GameObject unlocked;
    public GameObject locked;
    public GameObject service;
    public GameObject service1;

    public List<ParticleSystem> effects;

    public Animator animator;  
    public string animIdle;
    public string animWork;

    public List<ButtonTabsChange> tabs;
    public List<GameObject> panels;
    public List<Button> buttons;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => ButtonClick(buttonIndex));
        }
        animator = GetComponent<Animator>(); 
        foreach (ParticleSystem item in effects)
        {
            item.Stop();
        }
        hireButton.onClick.AddListener(() => StartCoroutine(HireWorker()));
        //upgradeButton.onClick.AddListener(UpgradeService);
    }

    public IEnumerator HireWorker()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !isUnlocked)
        {
            isUnlocked = true;
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost;
            Reception.instance.totalCashiers++;
            UpdateValues();
            if (Reception.instance.totalCashiers == 1)
            {
                StartCoroutine(Reception.instance.taskList[0].TaskComplete());
            }
            service.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.05f);
            service1.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.05f);

            effects[0].Play();
            effects[1].Play();
            yield return new WaitForSeconds(0.10f);
            service.SetActive(true);
            service.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            service1.SetActive(true);
            service1.transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.75f);

            yield return new WaitForSeconds(0.5f);
            Destroy(effects[0].gameObject);
            Destroy(effects[1].gameObject);
        }
    }

    public void UpdateValues()
    {
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Reception.instance.totalHires_text.text = Reception.instance.totalCashiers.ToString();
        PlayerPrefs.SetInt("Receptionist", Reception.instance.totalCashiers);
    }

    //public void UpgradeSpeed()
    //{
    //    effects[2].Play();
    //    if (GameManager.instance.totalBalance >= costPerLevel)
    //    {
    //        GameManager.instance.totalBalance -= costPerLevel;
    //        UpdateValues();
    //        workerLevel++;
    //        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
    //        workerSpeed += workerSpeed * (speed_percentageIncrease / 100);
    //        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
    //        workerSpeed = Mathf.Round(workerSpeed * 100) / 100; // Round to 2 decimal place

    //        levelText.text = workerLevel.ToString();
    //        upgradeCostText.text = costPerLevel.ToString();
    //        speedText.text = workerSpeed.ToString();
    //    }
    //    if (workerLevel == 5)
    //    {
    //        StartCoroutine(Reception.instance.taskList[1].TaskComplete());
    //    }
    //}
     
    public IEnumerator Movement()
    {
        PlayAnimation(animIdle);
        yield return new WaitForSeconds(1);
        PlayAnimation(animWork);
    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
        //if (isWorking)
        //{
        //    anim.Play(animation);
        //    animationDuration -= Time.deltaTime;

        //    // If the duration is less than or equal to 0, stop the animation
        //    if (animationDuration <= 0)
        //    {
        //        animator.speed = 0; // Pause the animation
        //                            // You can also add any other logic you want to perform when stopping the animation here
        //    }
        //}
        //else
        //{
        //    anim.Stop(animation);
        //}
    }

    public void HandleButtonStateChange(ButtonTabsChange button)
    {
        ResetPanels();

        int buttonIndex = tabs.IndexOf(button);

        if (buttonIndex != -1 && buttonIndex < panels.Count)
        {
            panels[buttonIndex].SetActive(true);
        }
    }

    public void ButtonClick(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < tabs.Count)
        {
            tabs[buttonIndex].ChangeState(ButtonStates.selected);
        }
    }

    public void ResetPanels()
    {
        foreach (GameObject item in panels)
        {
            item.SetActive(false);
        }
    }

    

}
