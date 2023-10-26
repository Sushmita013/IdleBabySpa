using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CollectTip : MonoBehaviour
{
    public RoomManager room;
    public float tipAmount;
    public ParticleSystem glitterEffect;
    public TMP_Text tipText;
    public GameObject tipValue;
    public GameObject imageDollar;

    public List<TaskButton5> taskList;


    void Start()
    { 
    }

    private void OnMouseDown()
    {
        StartCoroutine(CollectTips());
    }

    public void OnEnable() 
    {
        glitterEffect.Play();
        gameObject.SetActive(true);
    }  

    public IEnumerator CollectTips()
    {
        if (CanvasManager.instance.taskNumber == 9)
        {
        TipManager.instance.collectedTips++;
            //TipManager.instance.collectedTips=0;
            if (TipManager.instance.collectedTips <= 3)
            {
                taskList[0].progressionSlider.value = TipManager.instance.collectedTips;
                taskList[0].progressText.text = TipManager.instance.collectedTips.ToString();
                if (TipManager.instance.collectedTips == 3)
                {
                    StartCoroutine(taskList[0].TaskComplete());
                }
            }
        }
        GameManager.instance.totalSoftCurrency += tipAmount;
        CanvasManager.instance.UpdateSoftCurrency();
        tipText.text = "+" + tipAmount.ToString();
        tipValue.SetActive(true);
        tipValue.transform.DOLocalMoveZ(-9, 1f);
        imageDollar.SetActive(false);
        yield return new WaitForSeconds(1);
        tipValue.SetActive(false);
        tipValue.transform.DOLocalMoveZ(-7, 0.1f);
        glitterEffect.Stop();
        room.customersServed = 0;
        imageDollar.SetActive(true); 
        gameObject.SetActive(false);
    }
}
