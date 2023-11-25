using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UnlockArea : MonoBehaviour
{
    public float unlockValue;
    public GameObject addUI;
    public ParticleSystem effectUI;
    public ParticleSystem explosionFx;
    public GameObject objectToEnable;
    public RoomManager roomManager;

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
        if (!roomManager.isUnlocked)
        {
            CanvasManager.instance.ShowPopup(messageText, descriptionText,()=> StartCoroutine(BuildFunction()));
            roomManager.CamZoom();
        } 
    }

    public IEnumerator BuildFunction()
    {
        if (GameManager.instance.totalSoftCurrency >= unlockValue)
        {
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
            objectToEnable.SetActive(true);
            objectToEnable.transform.DOScale(new Vector3(1, 1, 1), 0.75f);
            yield return new WaitForSeconds(0.5f);
            Destroy(explosionFx.gameObject);
            Destroy(effectUI.gameObject);
            Destroy(addUI.gameObject);
        }
    }
}