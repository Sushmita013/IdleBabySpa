using System;
using System.Collections.Generic;
using UnityEngine;

public enum DataType
{
    Block,
    Tunnels,
    ActorTile,
    EmptyTile,
    BarrelTile
}

[Serializable]
public struct ObjectInfo
{
    public DataType objectType;
    public Vector3 position;
    public int colorIndex;
}

[CreateAssetMenu(fileName ="New Level",menuName ="Assets/Create New Level",order =0)]
public class LevelData : ScriptableObject
{
    public List<ObjectInfo> objects=new List<ObjectInfo>();
    public List<TunnelData> tunnels=new List<TunnelData>();
    public List<Color> colorArray=new List<Color>();

    public List<GameObject> actors=new List<GameObject>();

    public Vector3 cameraPos;
}

[Serializable]
public struct TunnelData
{
    public Vector3 position;
    public Vector3 eulerAngles;
    public List<int> colorArray;

    public TunnelData(Vector3 position, Vector3 eulerAngles, List<int> colorArray)
    {
        this.position = position;
        this.eulerAngles = eulerAngles;
        this.colorArray = new List<int>();
        this.colorArray.AddRange(colorArray);
    }
}
