using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Interior : MonoBehaviour
{
    public RoomManager room;

    public List<Button> plantButton;
    public List<Button> tvButton;
    public List<Button> chairButton;
    public List<Button> wallButton;

    public List<GameObject> plantsObject;
    public List<GameObject> tvObject;
    public List<GameObject> chairObject;
    public List<GameObject> wallObject;

    public GameObject activePlant;
    public GameObject mainPlant;
    public GameObject activeChair;
    public GameObject mainChair;
    public GameObject activeTv;
    public GameObject mainTv;
    public GameObject activeWall;
    public GameObject mainWall;

    public Button plantBuy;
    public Button sofaBuy;

    public Button closeButton;

    public TaskButton6 task;

    public GameObject nameUI;

    public Slider levelSlider;
    public TMP_Text levelNumber;

    public Button nextButton;

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
        for (int i = 0; i < wallButton.Count; i++)
        {
            int index = i; 
            wallButton[i].onClick.AddListener(() => StartCoroutine(WallUpgrade(index)));
        }

        plantBuy.onClick.AddListener(OnPlantButtonClick);
        sofaBuy.onClick.AddListener(OnSofaButtonClick);
        closeButton.onClick.AddListener(ResetToDefault);
    }

    private void Update()
    {
        if (GameManager.instance.totalHardCurrency >= 20)
        {
            plantBuy.interactable = true;
            sofaBuy.interactable = true;
        }
        else
        {
            plantBuy.interactable = false;
            sofaBuy.interactable = false;
        }
    }

    public IEnumerator PlantUpgrade(int i)
    {
        plantsObject[i].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        activePlant.SetActive(false);
        mainPlant.SetActive(false);
        yield return new WaitForSeconds(0.25f); 
        plantsObject[i].SetActive(true);
        plantsObject[i].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        activePlant = plantsObject[i];
    }

    public IEnumerator TvUpgrade(int i)
    {
        tvObject[i].transform.DOScale(new Vector3(75, 75, 75), 0.1f);
        activeTv.SetActive(false);
        mainTv.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        tvObject[i].SetActive(true);
        tvObject[i].transform.DOScale(new Vector3(150, 150, 150), 0.5f);
        activeTv = tvObject[i];
    }
    public IEnumerator ChairUpgrade(int i)
    {
        chairObject[i].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        activeChair.SetActive(false);
        mainChair.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        chairObject[i].SetActive(true);
        chairObject[i].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        activeChair = chairObject[i];
    }
    public IEnumerator WallUpgrade(int i)
    {
        nameUI.SetActive(false);
        wallObject[i].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.1f);
        activeWall.SetActive(false);
        mainWall.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        wallObject[i].SetActive(true);
        wallObject[i].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        activeWall = wallObject[i];
    }

    public void ResetToDefault()
    {
        for (int i = 0; i < plantsObject.Count; i++)
        {
            plantsObject[i].SetActive(false);
        }
        for (int i = 0; i < tvObject.Count; i++)
        {
            tvObject[i].SetActive(false);
        }
        for (int i = 0; i < chairObject.Count; i++)
        {
            chairObject[i].SetActive(false);
        }
        for (int i = 0; i < wallObject.Count; i++)
        {
            wallObject[i].SetActive(false);
        }
        nameUI.SetActive(true);
        mainChair.SetActive(true);
        mainPlant.SetActive(true);
        mainTv.SetActive(true);
        mainWall.SetActive(true); 
    }

    public void ResetChair()
    {
        for (int i = 0; i < chairObject.Count; i++)
        {
            chairObject[i].SetActive(false);
        }
    }

    public void OnPlantButtonClick()
    {
        if (GameManager.instance.totalHardCurrency >= 20)
        {
            GameManager.instance.totalHardCurrency -= 20;
            CanvasManager.instance.UpdateHardCurrency();
            mainPlant = plantsObject[0];
        plantBuy.gameObject.SetActive(false);
            StartCoroutine(task.TaskComplete());
            Camera.main.GetComponent<PanZoom>().enabled = true;
            levelNumber.text = "4";
            levelSlider.value = 4;
            nextButton.interactable = true;
        }
    }
    public void OnSofaButtonClick()
    {
        if (GameManager.instance.totalHardCurrency >= 20)
        {
            GameManager.instance.totalHardCurrency -= 20;
            CanvasManager.instance.UpdateHardCurrency();
            mainChair = chairObject[0];
            ResetChair();
            mainChair.SetActive(true);
            sofaBuy.gameObject.SetActive(false);
            levelNumber.text = "8";
            levelSlider.value = 8;
        }
    }
}
