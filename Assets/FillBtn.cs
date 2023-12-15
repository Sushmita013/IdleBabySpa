using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillBtn : MonoBehaviour
{
    public int itemID;
    [SerializeField] int quantity;
    [SerializeField] TextMeshProUGUI quantText;

    public int Quantity { get => quantity; set { quantity = value; quantText.text=$"x{quantity}"; } }

    public void Fill()
    {
        FillManager.instance.FillObject(itemID, Quantity, transform);
    }
}
