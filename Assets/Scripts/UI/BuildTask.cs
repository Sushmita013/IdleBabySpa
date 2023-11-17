using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTask : MonoBehaviour
{ 
    void Start()
    {
        
    }

    public IEnumerator OnCollectReward()
    { 
        yield return new WaitForSeconds(0.05f);
        HideReward(); 

        //GameManager.instance.totalSoftCurrency += rewardValue;
        CanvasManager.instance.totalBalance_text.text = GameManager.instance.totalSoftCurrency.ToString();
        Destroy(gameObject);
    }

    public void ShowPopup(string errorMessage)
    {
        //room.ResetPanels();
        if (CanvasManager.instance.popupObject == null)
        {
            CanvasManager.instance.popupObject = Instantiate(CanvasManager.instance.buildPopup, CanvasManager.instance.prefabParent1);
            BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
            errorPopup.EnablePanel();
            errorPopup.SetErrorMessage(errorMessage);
            errorPopup.SetDescription(errorMessage); 
        }
    }

    public void ShowReward(string message)
    { 
        if (CanvasManager.instance.popupObject1 == null)
        {
            CanvasManager.instance.popupObject1 = Instantiate(CanvasManager.instance.rewardPopup, CanvasManager.instance.prefabParent1);
            RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
            errorPopup.EnablePanel(); 
            //errorPopup.SetRewardMessage(rewardValue.ToString());
            errorPopup.SetRewardText(message);
            errorPopup.SetButton("Collect Reward", () => StartCoroutine(OnCollectReward()));
        }
    }

    public void HidePopup()
    {
        BuildPopup errorPopup = CanvasManager.instance.popupObject.GetComponent<BuildPopup>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject);
    }
    public void HideReward()
    {
        RewardPanel errorPopup = CanvasManager.instance.popupObject1.GetComponent<RewardPanel>();
        errorPopup.DisablePanel();
        Destroy(CanvasManager.instance.popupObject1);
    }
}
