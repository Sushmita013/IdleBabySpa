using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUIManager : MonoBehaviour
{
    public Transform contentParent;
    public FillBtn fillBtn;
    public FillBtn SpawnInventoryData()
    {
        var fillBtn_Clone = Instantiate(fillBtn, contentParent);
        return fillBtn_Clone;
    }
}
