using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Interior : MonoBehaviour
{
    public RoomManager room;

    public List<Button> plantButton;
    public List<Button> tvButton;
    public List<Button> chairButton;

    public List<GameObject> plantsObject;
    public List<GameObject> tvObject;
    public List<GameObject> chairObject;

    public GameObject activePlant;
    public GameObject activeChair;
    public GameObject activeTv;
    void Start()
    {
        for (int i = 0; i < plantButton.Count; i++)
        {
            int index = i;
            plantButton[i].onClick.AddListener(() => StartCoroutine(PlantUpgrade(index))); 
        }
        for (int i = 0; i < tvButton.Count; i++)
        {
            int index = i; 
            tvButton[i].onClick.AddListener(() => StartCoroutine(TvUpgrade(index)));
        }
        for (int i = 0; i < chairButton.Count; i++)
        {
            int index = i; 
            chairButton[i].onClick.AddListener(() => StartCoroutine(ChairUpgrade(index)));
        }
    } 

    public IEnumerator PlantUpgrade(int i)
    {
        plantsObject[i].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        activePlant.SetActive(false);
        yield return new WaitForSeconds(0.25f); 
        plantsObject[i].SetActive(true);
        plantsObject[i].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        activePlant = plantsObject[i];
    }

    public IEnumerator TvUpgrade(int i)
    {
        tvObject[i].transform.DOScale(new Vector3(75, 75, 75), 0.1f);
        activeTv.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        tvObject[i].SetActive(true);
        tvObject[i].transform.DOScale(new Vector3(150, 150, 150), 0.5f);
        activeTv = tvObject[i];
    }
    public IEnumerator ChairUpgrade(int i)
    {
        chairObject[i].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        activeChair.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        chairObject[i].SetActive(true);
        chairObject[i].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        activeChair = chairObject[i];
    }

}
