using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;


public class UnlockWorker : MonoBehaviour
{
    public RoomManager roomManager;
    public WorkerNPC workerNpc;
    public float hireCost;
    public Button hireButton;
    public GameObject locked;
    public GameObject unlocked;
    public GameObject unlockUI;

    public ParticleSystem unlockEffect;

    public GameObject objectToEnable;

    void Start()
    {
        hireButton.onClick.AddListener(() => StartCoroutine(HireWorker()));
        unlockEffect.Stop();
        LoadData();
    }

    private void Update()
    {
        EnableDisableUpgrade(GameManager.instance.totalSoftCurrency);
    }
    public IEnumerator HireWorker()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !workerNpc.isUnlocked)
        {
            MMVibrationManager.Haptic(HapticTypes.MediumImpact); 
            unlockEffect.Play(); 
            workerNpc.isUnlocked = true;
            roomManager.workerIndex.Add(roomManager.workerList.FindIndex(x=>x==workerNpc));
            roomManager.waiting.CheckForFreeSlots();
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost;
            CanvasManager.instance.UpdateSoftCurrency();
            SaveManager.instance.SaveDataCall();
            objectToEnable.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f); 
            yield return new WaitForSeconds(0.10f);
            Destroy(unlockUI.gameObject);
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            //service1.SetActive(true);
            //service1.transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.75f);

            yield return new WaitForSeconds(0.5f);
            Destroy(unlockEffect.gameObject); 
        }
    }

    public void EnableDisableUpgrade(float bal)
    {
        if (bal >= hireCost)
        {
            hireButton.interactable = true;
        }
        else
        {
            hireButton.interactable = false;

        }
    }

    public void LoadData()
    {
        if (workerNpc.isUnlocked)
        {
            locked.SetActive(false);
            unlocked.SetActive(true);
            objectToEnable.SetActive(true);
            Destroy(unlockUI.gameObject);
            Destroy(unlockEffect.gameObject);

        }
    }
}
