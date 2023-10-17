using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTip : MonoBehaviour
{
    public RoomManager room;
    public float tipAmount;
    public ParticleSystem glitterEffect;
     
    void Start()
    {
        glitterEffect.Play();
    }

    private void OnMouseDown()
    {
        TipManager.instance.collectedTips++; 
        GameManager.instance.totalSoftCurrency += tipAmount;
        CanvasManager.instance.UpdateSoftCurrency();
        glitterEffect.Stop();
        gameObject.SetActive(false);
        room.customersServed = 0;
    }

    public void OnEnable()
    {
        gameObject.SetActive(true);
        glitterEffect.Play();
    }
    void Update()
    {
        
    }
}
