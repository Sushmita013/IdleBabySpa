using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] StoreUIManager manager;
    private void Start()
    {
        var inInventory=Inventory.instance.data.Count;
        for (int i = 0; i < inInventory; i++)
        {
            var invData=manager.SpawnInventoryData();
            invData.itemID = Inventory.instance.data[i].itemID;
            invData.Quantity = Inventory.instance.data[i].quantity;
        }
    }
}
