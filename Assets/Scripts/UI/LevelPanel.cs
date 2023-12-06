using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPanel : MonoBehaviour
{
    public Button closeButton;
    public Button nextLevelButton;

    public Slider levelSlider;
    public TMP_Text targetLevel;
    public TMP_Text targetLevel1;
    public TMP_Text targetLevel2;

    public GameObject level0;
    public GameObject level1;

    //public TaskButton7 task;

    void Start()
    {
        closeButton.onClick.AddListener(OnCloseClick);
        nextLevelButton.onClick.AddListener(OnNextLevelClicks);
    } 

    public void OnCloseClick()
    {
        gameObject.SetActive(false);
    }
    public void OnNextLevelClicks()
    {
        levelSlider.maxValue = 12;
        targetLevel.text = "/12";
        targetLevel1.text = "2";
        targetLevel2.text = "2";
        //task.TaskComplete();
        level0.SetActive(false);
        level1.SetActive(true);
        nextLevelButton.interactable = false; 
        //Tutorial.instance.ResetHands();
    }
}
