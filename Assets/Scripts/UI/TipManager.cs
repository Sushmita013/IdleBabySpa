using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour
{
    public static TipManager instance;

    public int collectedTips;

    public Button levelButton;
    public GameObject levelPanel;

    void Start()
    {
        instance = this;
        levelButton.onClick.AddListener(OnLevelButtonClick);
    }
      

    public void OnLevelButtonClick()
    {
        levelPanel.SetActive(true);
        Tutorial.instance.LevelUpgrade(); 
    }
}
