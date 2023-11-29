using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UnlockReception : MonoBehaviour
{
    public float unlockValue;
    public GameObject addUI;
    public ParticleSystem effectUI;
    public ParticleSystem explosionFx;
    public GameObject objectToEnable;
    public GameObject borderWalls; 
    public GameObject enableNextPanel;

    public Reception reception;

    public string messageText;
    public string descriptionText;

    public Button unlockButton;
    void Start()
    {
        //unlockButton = GetComponent<Button>();
        unlockButton.onClick.AddListener(UnlockAreaTask);
    }

    public void UnlockAreaTask()
    {
        if (!reception.isUnlocked)
        {
            CanvasManager.instance.ShowPopup(messageText, descriptionText, () => StartCoroutine(BuildFunction()));
            objectToEnable.transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.01f); 
            reception.CamZoom();
        }
    }

    public IEnumerator BuildFunction()
    {
        if (GameManager.instance.totalSoftCurrency >= unlockValue)
        {
            CanvasManager.instance.HidePopup();
            GameManager.instance.totalSoftCurrency -= unlockValue;
            CanvasManager.instance.UpdateSoftCurrency();
            reception.isUnlocked = true;
            if (TaskManager.Instance.CurrentActiveTask.taskObject.taskType == TaskType.BuildReception)
            {
                TaskManager.BuildReceptionAction?.Invoke();
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
}
