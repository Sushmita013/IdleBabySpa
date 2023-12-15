using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct FillObjectData
{
    public int itemID;
    public List<GameObject> fillObjects;
}

public class FillManager : MonoBehaviour
{
    public static FillManager instance;
    public List<FillObjectData> fillObjects;
    public void FillObject(int itemId,int quantity,Transform imagePos)
    {
        var x=fillObjects.Find(x => x.itemID == itemId);
        CameraMovementManager.instance.MoveCameraToPos(x.fillObjects[0].transform, () => 
        {
            StartCoroutine(FillDataObject(quantity, x, imagePos));
        });
    }

    IEnumerator FillDataObject(int quantity,FillObjectData x,Transform imagePos)
    {
        quantity=Mathf.Clamp(quantity,0,x.fillObjects.Count);
        for (int i = 0; i < quantity; i++)
        {
            var orgPos = x.fillObjects[i].transform.position;
            x.fillObjects[i].transform.position = Camera.main.ScreenToWorldPoint(imagePos.GetComponent<RectTransform>().anchoredPosition);
            x.fillObjects[i].transform.localScale = Vector3.one * 2.5f;
            x.fillObjects[i].SetActive(true);
            x.fillObjects[i].transform.DOJump(orgPos,1,1,1f).SetDelay(i * 0.3f);
            x.fillObjects[i].transform.DOScale(Vector3.one, 1f).SetDelay(i * 0.3f).WaitForCompletion();
        }
        x.fillObjects.RemoveRange(0, quantity);
        yield return new WaitForSeconds(0.2f);
        Destroy(imagePos.gameObject);
    }

    private void Awake()
    {
        instance = this;
    }
}
