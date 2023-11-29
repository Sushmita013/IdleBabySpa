using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;


public class UnlockArea : MonoBehaviour
{
    public float unlockValue;
    public GameObject addUI;
    public ParticleSystem effectUI;
    public ParticleSystem explosionFx;
    public GameObject objectToEnable;
    public GameObject borderWalls;
    public GameObject enableNextPanel;
    public RoomManager roomManager;

    public string messageText;
    public string descriptionText;

    public Button unlockButton;

    public bool areaUnlocked;
    void Start()
    {
        //unlockButton = GetComponent<Button>();
        unlockButton.onClick.AddListener(UnlockAreaTask);
        if (areaUnlocked)
        {
            LoadData();
        }
    } 

    public void UnlockAreaTask()
    {
        if (!roomManager.isUnlocked)
        {
            if (unlockValue == 0)
            { 
            CanvasManager.instance.ShowPopup(messageText, descriptionText,()=> StartCoroutine(BuildFunction()));
            }
            else
            {
                CanvasManager.instance.ShowPopup1(messageText, descriptionText,unlockValue, () => StartCoroutine(BuildFunction())); 
            }
            objectToEnable.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f); 
            roomManager.CamZoom();
        } 
    }

    public IEnumerator BuildFunction()
    {
        if (GameManager.instance.totalSoftCurrency >= unlockValue)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            CanvasManager.instance.HidePopup();
            GameManager.instance.totalSoftCurrency -= unlockValue;
            CanvasManager.instance.UpdateSoftCurrency();
            roomManager.isUnlocked = true; 
            if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.BuildTask)
            {
                TaskManager.BuildAction?.Invoke();
            }
            yield return new WaitForSeconds(0.5f);
            explosionFx.Play();
            borderWalls.SetActive(false);
            enableNextPanel.SetActive(true);
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            yield return new WaitForSeconds(0.5f);
            Destroy(explosionFx.gameObject);
            Destroy(effectUI.gameObject);
            Destroy(addUI.gameObject);
        }
    }

    public void LoadData()
    {
        roomManager.isUnlocked = true;
        objectToEnable.SetActive(true);
        Destroy(explosionFx.gameObject);
        Destroy(effectUI.gameObject);
        Destroy(addUI.gameObject);
    }
}
