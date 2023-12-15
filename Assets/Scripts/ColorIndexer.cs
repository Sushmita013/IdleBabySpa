using UnityEngine;

public class ColorIndexer : MonoBehaviour
{
    [SerializeField] int colorIndex = 0;

    public int ColorIndex { get => colorIndex; set => colorIndex = value; }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, ColorIndex.ToString(), true, LevelDataManager.Instance.currentLevelData.colorArray[ColorIndex]);
    }
}
