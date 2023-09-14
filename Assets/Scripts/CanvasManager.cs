using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public TMP_Text totalBalance_text;
    public TMP_Text totalHires;


    void Start()
    {
        instance = this;
        totalBalance_text.text = GameManager.instance.totalBalance.ToString();
    }
     
    void Update()
    {
        
    }
}
