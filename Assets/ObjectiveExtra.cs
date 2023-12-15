using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveExtra : MonoBehaviour
{
    public static ObjectiveExtra instance;
    public List<ItemSO> itemSOs;

    private void Awake()
    {
        instance = this;
    }

    public List<ItemSO> GetRandomsOtherThan(List<ItemSO> toExculde,int varaince)
    {
        List<ItemSO> returnList = new List<ItemSO>();

        while (true)
        {
            var x = itemSOs[Random.Range(0, itemSOs.Count)];
            if (toExculde.Contains(x) || returnList.Contains(x))
                continue;
            else
            {
                returnList.Add(x);
                if(returnList.Count==varaince)
                    break;
            }
        }
        return returnList;
    }
}
