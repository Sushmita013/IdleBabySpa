using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public static Objective Instance;
    public List<ItemSO> itemSOs = new List<ItemSO>();
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        itemSOs.Clear();
    }

    public void GetExtra(int varaince)
    {
        var extras = ObjectiveExtra.instance.GetRandomsOtherThan(itemSOs,varaince);
    }
}
