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
     
    void Start()
    {
        //glitterEffect.Play();
    }

    private void OnMouseDown()
    {
        
    }

    public void OnEnable() 
    {
        glitterEffect.Play();
        gameObject.SetActive(true);
    }  

    public IEnumerator CollecTip()
    {
        TipManager.instance.collectedTips++;
        GameManager.instance.totalSoftCurrency += tipAmount;
        CanvasManager.instance.UpdateSoftCurrency();
        tipText.text = "+" + tipAmount.ToString();
        tipValue.SetActive(true);
        tipValue.transform.DOLocalMoveZ(-9, 1f);
        yield return new WaitForSeconds(1);
        tipValue.SetActive(false);
        tipValue.transform.DOLocalMoveZ(-7, 0.1f);
        glitterEffect.Stop();
        gameObject.SetActive(false);
        room.customersServed = 0;
    }
}
