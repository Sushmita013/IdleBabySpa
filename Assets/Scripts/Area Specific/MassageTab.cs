using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MassageTab : MonoBehaviour
{
    public float costPerLevel;
    public float incomePerLevel;
    public float cost_percentageIncrease;
    public float income_Increase;

    public TMP_Text cost_upgrade;
    public TMP_Text income_value;

    public RoomManager room;

    public int multiplier;

    public List<Slider> levelSlider;

    public List<TaskButton3> taskList;

    public List<TMP_Text> level;

    public Button upgradeButton;

    public List<GameObject> panels;
    //public List<GameObject> lamps;
    //public List<GameObject> lampsLevels;
    public List<GameObject> lampsPlantRooms;
    public List<GameObject> lampsPlantLevel2;
    public List<GameObject> lampsPlantLevel3;
    //public List<GameObject> plants;
    //public List<GameObject> plantsLevels;
    public List<GameObject> wallFloor;
    public List<GameObject> glassWall;
    public List<GameObject> services;

    public ParticleSystem upgradeEffect;
    public ParticleSystem upgradeEffect1;
    public ParticleSystem upgradeEffect2;
    public ParticleSystem upgradeEffect3;
    public ParticleSystem upgradeEffect4;

    public bool isHolding;
    public bool startTimer;

    public float holdTimer;

    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeClick);
        upgradeEffect.Stop();
        upgradeEffect1.Stop();
        upgradeEffect2.Stop();
        upgradeEffect3.Stop();
        upgradeEffect4.Stop();
    }
    private void Update()
    {
        if (startTimer)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= 0.75f)
            {
                isHolding = true;
                StartCoroutine(UpgradeHold());
            }
        }
        EnableDisableUpgrade(GameManager.instance.totalSoftCurrency);
    }

    public void UpgradeClick()
    {
        if (GameManager.instance.totalSoftCurrency >= costPerLevel)
        {
            upgradeEffect.Play();
            if (room.serviceLevel <= 25)
            {
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.2f;
                room.serviceLevel++;
                taskList[0].progressText.text = room.serviceLevel.ToString();
                taskList[0].progressionSlider.value = room.serviceLevel;
                if (room.serviceLevel == 2)
                {
                    //Tutorial.instance.ResetHands();
                    //Tutorial.instance.MassageUpgradeDone();
                    Camera.main.GetComponent<PanZoom>().enabled = true;
                }
                if (room.serviceLevel == 13)
                {
                    VisualUpgrade(13);
                }
                if (room.serviceLevel == 25)
                {
                    VisualUpgrade(25);
                    multiplier = 2;
                    incomePerLevel *= multiplier;
                    income_Increase = 0.4f;
                    StartCoroutine(taskList[0].TaskComplete());
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[0].text = room.serviceLevel.ToString();
                    levelSlider[0].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            if (room.serviceLevel > 25 && room.serviceLevel <= 50)
            {
                room.serviceLevel++;
                taskList[1].progressText.text = room.serviceLevel.ToString();
                taskList[1].progressionSlider.value = room.serviceLevel;
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 0.4f;
                if(room.serviceLevel == 38)
                {
                    VisualUpgrade(38);
                }
                if (room.serviceLevel == 50)
                {
                    VisualUpgrade(50);
                    StartCoroutine(taskList[1].TaskComplete());
                    multiplier = 3;
                    incomePerLevel *= multiplier;
                    income_Increase = 1.2f;
                    room.serviceLevel++;
                    foreach (GameObject item in panels)
                    {
                        item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                    level[1].text = room.serviceLevel.ToString();
                    levelSlider[1].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[1].text = room.serviceLevel.ToString();
                    levelSlider[1].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            if (room.serviceLevel > 50 && room.serviceLevel <= 75)
            {
                room.serviceLevel++;
                taskList[2].progressText.text = room.serviceLevel.ToString();
                taskList[2].progressionSlider.value = room.serviceLevel;
                multiplier = 1;
                incomePerLevel *= multiplier;
                income_Increase = 1.2f;
                if(room.serviceLevel == 63)
                {
                    VisualUpgrade(63);
                }
                if (room.serviceLevel == 75)
                {
                    StartCoroutine(taskList[2].TaskComplete());
                    multiplier = 4;
                    incomePerLevel *= multiplier;
                    income_Increase = 4.5f;
                    //room.serviceLevel++;
                    foreach (GameObject item in panels)
                    {
                        //item.transform.DOLocalMoveX(item.transform.localPosition.x - 1000, 1f);
                    }
                    level[2].text = room.serviceLevel.ToString();
                    levelSlider[2].value = room.serviceLevel;
                    UpdateCost();
                }
                else
                {
                    level[2].text = room.serviceLevel.ToString();
                    levelSlider[2].value = room.serviceLevel;
                    UpdateCost();
                }
            }
            //if (room.serviceLevel > 75 && room.serviceLevel <= 100)
            //{ 
            //    room.serviceLevel++;
            //        taskList[3].progressText.text = room.serviceLevel.ToString();
            //       taskList[3].progressionSlider.value = room.serviceLevel; 
            //    multiplier = 1;
            //    incomePerLevel *= multiplier;
            //    income_Increase = 4.5f;
            //    if (room.serviceLevel == 100)
            //    { 
            //        StartCoroutine(taskList[3].TaskComplete());
            //        //multiplier = 4;
            //        //incomePerLevel *= multiplier;
            //        //income_Increase = 4.5f;
            //        room.serviceLevel++;
            //        //foreach (GameObject item in panels)
            //        //{
            //        //    item.transform.DOLocalMoveX(item.transform.localPosition.x - 800, 1f);
            //        //}
            //        level[3].text = room.serviceLevel.ToString();
            //        levelSlider[3].value = room.serviceLevel;
            //        UpdateCost();
            //        upgradeButton.interactable = false;
            //    }
            //    else
            //    { 
            //        level[3].text = room.serviceLevel.ToString();
            //        levelSlider[3].value = room.serviceLevel;
            //        UpdateCost();
            //    }
            //} 
        }
    }

    public void EnableDisableUpgrade(float bal)
    {
        if (bal >= costPerLevel && room.serviceLevel <=74)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;

        }
    }

    public IEnumerator UpgradeHold()
    {
        startTimer = false;
        while (isHolding)
        {
            UpgradeClick();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void OnUpgradeDown()
    {
        startTimer = true;
    }
    public void OnUpgradeUp()
    {
        startTimer = false;
        isHolding = false;
        holdTimer = 0;
    }
    public void UpdateCost()
    {
        GameManager.instance.totalSoftCurrency -= costPerLevel;
        CanvasManager.instance.UpdateSoftCurrency();
        costPerLevel += costPerLevel * (cost_percentageIncrease / 100);
        incomePerLevel += income_Increase;
        costPerLevel = Mathf.Round(costPerLevel * 100) / 100; // Round to 2 decimal places
        incomePerLevel = Mathf.Round(incomePerLevel * 10) / 10; // Round to 1 decimal place
        room.serviceCost = incomePerLevel;
        cost_upgrade.text = costPerLevel.ToString();
        income_value.text = incomePerLevel.ToString();
    }

    public void UpdateHard()
    {
        CanvasManager.instance.totalBalanceHard_text.text = GameManager.instance.totalHardCurrency.ToString();
    }

    public void VisualUpgrade(int level)
    {
        switch (level)
        {
            case 13:
                upgradeEffect1.Play();
                lampsPlantRooms[0].SetActive(true);
                lampsPlantRooms[0].transform.DOScale(new Vector3(1, 1, 1), 1f);
                //lamps[0].SetActive(true);
                //lamps[0].transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
                //plants[0].SetActive(true);
                //plants[0].transform.DOScale(new Vector3(4, 4, 4), 1f); 
                break;
            case 25:
                StartCoroutine(SizeExpansion());
                break;
            case 38:
                LampPlantUpgrade();
                break;
            case 50:
                StartCoroutine(SizeExpansion2());
                break;
            case 63:
                LampPlantUpgrade1();
                break;
        }
    }

    public IEnumerator SizeExpansion()
    {
        upgradeEffect2.Play();
        wallFloor[1].SetActive(true);
        wallFloor[1].transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        yield return new WaitForSeconds(0);
        services[1].SetActive(true);
        services[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        glassWall[0].SetActive(false);
        wallFloor[0].SetActive(false);
        glassWall[1].SetActive(true);
        lampsPlantRooms[1].SetActive(true);
        lampsPlantRooms[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        //lamps[1].SetActive(true);
        //lamps[1].transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
        //plants[1].SetActive(true);
        //plants[1].transform.DOScale(new Vector3(4, 4, 4), 1f);

    }
    public IEnumerator SizeExpansion2()
    {
        upgradeEffect2.Play();
        wallFloor[2].SetActive(true);
        wallFloor[2].transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        yield return new WaitForSeconds(0);
        services[2].SetActive(true);
        services[2].transform.DOScale(new Vector3(1, 1, 1), 1f);
        glassWall[1].SetActive(false);
        wallFloor[1].SetActive(false); 
        lampsPlantLevel2[2].SetActive(true);
        lampsPlantLevel2[2].transform.DOScale(new Vector3(1, 1, 1), 1f);
        //lamps[1].SetActive(true);
        //lamps[1].transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
        //plants[1].SetActive(true);
        //plants[1].transform.DOScale(new Vector3(4, 4, 4), 1f);

    }

    public void LampPlantUpgrade()
    {
        upgradeEffect1.Play();
        upgradeEffect3.Play();
        lampsPlantRooms[0].SetActive(false);
        lampsPlantRooms[1].SetActive(false);
        lampsPlantLevel2[0].SetActive(true);
        lampsPlantLevel2[0].transform.DOScale(new Vector3(1, 1, 1), 1f);

        lampsPlantLevel2[1].SetActive(true);
        lampsPlantLevel2[1].transform.DOScale(new Vector3(1, 1, 1), 1f);


        //lamps[1].SetActive(true);
        //lamps[1].transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
        //plants[1].SetActive(true);
        //plants[1].transform.DOScale(new Vector3(4, 4, 4), 1f);

    }
    public void LampPlantUpgrade1()
    {
        upgradeEffect1.Play();
        upgradeEffect3.Play();
        upgradeEffect4.Play();
        lampsPlantLevel2[0].SetActive(false);
        lampsPlantLevel2[1].SetActive(false);
        lampsPlantLevel2[2].SetActive(false);
        lampsPlantLevel3[0].SetActive(true);
        lampsPlantLevel3[0].transform.DOScale(new Vector3(1, 1, 1), 1f);

        lampsPlantLevel3[1].SetActive(true);
        lampsPlantLevel3[1].transform.DOScale(new Vector3(1, 1, 1), 1f);
        lampsPlantLevel3[2].SetActive(true);
        lampsPlantLevel3[2].transform.DOScale(new Vector3(1, 1, 1), 1f);


        //lamps[1].SetActive(true);
        //lamps[1].transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 1f);
        //plants[1].SetActive(true);
        //plants[1].transform.DOScale(new Vector3(4, 4, 4), 1f);

    }
}
