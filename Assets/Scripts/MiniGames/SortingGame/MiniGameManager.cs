using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniGameManager : MonoBehaviour
{
    public GameObject giftbox; 
    public GameObject lid; 
    public ParticleSystem effect;

    public GameObject toys;

    public int effectPlayed;

    void Start()
    {
        effect.Stop(); 
    }
    private void Update()
    {
        if(toys.transform.childCount == 0)
        {
            if(effectPlayed == 0)
            { 
            StartCoroutine(OnWin());  
            }
        }
    }

    public IEnumerator OnWin()
    {
        effectPlayed++;
        yield return new WaitForSeconds(1f);
        foreach (GameObject item in MatchMaker.instance.collectedObjects)
        {
            Destroy(item);
        } 
        lid.SetActive(true);
        lid.transform.DOLocalMoveY(0.35f, 2f);
        yield return new WaitForSeconds(2f); 
        giftbox.transform.DOMoveZ(0, 2f); 
        yield return new WaitForSeconds(2f);
        effect.Play();
    }

}
