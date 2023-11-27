using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UnlockWorker : MonoBehaviour
{
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
    }
    public IEnumerator HireWorker()
    {
        if (GameManager.instance.totalSoftCurrency >= hireCost && !workerNpc.isUnlocked)
        {
            unlockEffect.Play(); 
            workerNpc.isUnlocked = true;
            locked.SetActive(false);
            unlocked.SetActive(true);
            GameManager.instance.totalSoftCurrency -= hireCost;
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
}
