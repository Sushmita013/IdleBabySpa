//using AdvancedEditorTools.Attributes;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager Instance;

    [SerializeField] PlacementSystem placementSystem;
    [SerializeField] string levelName;
    [SerializeField] DataType dataType;
    [SerializeField] TextMeshProUGUI editingLevel;

    public LevelData currentLevelData;
    public List<ObjectInfo> levelInfo;
    public List<TunnelData> tunnelInfo;

    private void Awake()
    {
        Instance = this;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
            return;

        levelName=currentLevelData.name;
    }

    private void Start()
    {
        editingLevel.text = $"Editing {levelName}";
    }

    public DataType DataType 
    { 
        get => dataType;
        set
        {
            dataType = (DataType)Mathf.Clamp((int)value, 0, 4);
            placementSystem.UpdateIndicatorData(dataType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var number = Input.mouseScrollDelta.y;
        PerformScroll(number);
    }

    //[Button("Create New Level Data")]
    public void CreateNewLevelData()
    { 
        LevelData levelData = ScriptableObject.CreateInstance<LevelData>();
        string path = $"Assets/Scriptables/LevelData/{levelName}.asset";
        editingLevel.text = $"Editing {levelName}";
        AssetDatabase.CreateAsset(levelData, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        currentLevelData = levelData;
    }

    //[Button("Save/Update Level Data")]
    public void SaveLevelData()
    {
        if (currentLevelData == null)
            return;
        levelInfo.Clear();
        tunnelInfo.Clear();

        placementSystem.blocks.ForEach(x => 
        {
            ObjectInfo objectInfo = new ObjectInfo();
            objectInfo.objectType = DataType.Block;
            objectInfo.position = x.transform.position;
            levelInfo.Add(objectInfo);
        });


        placementSystem.actors.ForEach(x =>
        {
            ObjectInfo objectInfo = new ObjectInfo();
            objectInfo.objectType = DataType.ActorTile;
            objectInfo.position = x.transform.position;
            objectInfo.colorIndex = x.GetComponent<ColorIndexer>().ColorIndex;
            levelInfo.Add(objectInfo);
        });

        placementSystem.barrelBase.ForEach(x =>
        {
            ObjectInfo objectInfo = new ObjectInfo();
            objectInfo.objectType = DataType.BarrelTile;
            objectInfo.position = x.transform.position;
            objectInfo.colorIndex = x.GetComponent<ColorIndexer>().ColorIndex;
            levelInfo.Add(objectInfo);
        });

        placementSystem.emptyBase.ForEach(x =>
        {
            ObjectInfo objectInfo = new ObjectInfo();
            objectInfo.objectType = DataType.EmptyTile;
            objectInfo.position = x.transform.position;
            levelInfo.Add(objectInfo);
        });


        placementSystem.tunnels.ForEach(x =>
        {
            TunnelData tunnel = new TunnelData(x.transform.position, x.transform.eulerAngles, x.GetComponent<Tunnel>().tunnelArray);
            tunnelInfo.Add(tunnel);
        });

        currentLevelData.objects.Clear();
        currentLevelData.tunnels.Clear();
        currentLevelData.objects.AddRange(levelInfo);
        currentLevelData.tunnels.AddRange(tunnelInfo);
        EditorUtility.SetDirty(currentLevelData);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    //[Button("Load Level Data from Asset")]
    public void LoadDatafromAsset()
    {
        levelInfo.Clear();
        levelInfo.AddRange(currentLevelData.objects);
        levelName = currentLevelData.name;
        editingLevel.text = $"Editing {levelName}";
        placementSystem.RecreateData(currentLevelData);
        DataType = 0;
        ColorMarker.instance.ColorIndex = 0;
    }

    void PerformScroll(float number)
    {
        if (number > 0)
            DataType += 1;
        if (number < 0)
            DataType -= 1;
    }

}
