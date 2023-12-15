using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InventoryData
{
    public int itemID;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryData> data=new List<InventoryData>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Item item)
    {
        if (data.Exists(x => x.itemID == item.itemSO.itemId))
        {
            var foundItem = data.Find(x => x.itemID == item.itemSO.itemId);
            int index=data.IndexOf(foundItem);
            foundItem.quantity++;
            data[index] = foundItem;
        }
        else
        {
            InventoryData newData = new InventoryData();
            newData.itemID = item.itemSO.itemId;
            newData.quantity = 1;
            data.Add(newData);
        }
    }
}
