using TMPro;
using UnityEngine;

public class ColorMarker : MonoBehaviour
{
    public static ColorMarker instance;

    private int colorIndex = 0;
    [SerializeField] TextMeshProUGUI currentColorIndexTxt;

    private void Awake()
    {
        instance = this;
    }

    public int ColorIndex 
    { 
        get => colorIndex;
        set
        {
            colorIndex = Mathf.Clamp(value, 0, LevelDataManager.Instance.currentLevelData.colorArray.Count-1);
            currentColorIndexTxt.text = $"Current ColorIndex : {colorIndex}";
        }
    }

    private void Start()
    {
        ColorIndex = 0;
    }

    public int GetColorIndex()
    {
        return colorIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ColorIndex++;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            ColorIndex--;
    }
}
