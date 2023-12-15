using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Assets/Create New Item",order =1)]
public class ItemSO : ScriptableObject
{
    public int itemId;
    public Sprite UIImage;
    public GameObject inGamePrefab;
}
