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
    }  

    public IEnumerator CollectTips()
    {  
        GameManager.instance.totalSoftCurrency += tipAmount;
        CanvasManager.instance.UpdateSoftCurrency();
        tipText.text = "+" + tipAmount.ToString();
        tipValue.SetActive(true); 
        tipValue.GetComponent<RectTransform>().DOAnchorPos(new Vector3(3,1.5f,3), 1f);
        imageDollar.SetActive(false);
        yield return new WaitForSeconds(1);
        tipValue.SetActive(false);
        tipValue.GetComponent<RectTransform>().DOAnchorPos(new Vector3(0.75f, 1.5f, 5), 0.1f);  
        glitterEffect.Stop();
        room.customersServed = 0;
        imageDollar.SetActive(true); 
        gameObject.SetActive(false);
        if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.CollectTips)
        { 
            TaskManager.CollectTipsAction?.Invoke(1);
        }
    }
}
