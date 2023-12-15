using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI levelName;
    public GameObject failScreen;

    private void Awake()
    {
        instance = this;
    }

    public void ReloadLevel()
    {
        failScreen.SetActive(false);
        GameplayManager.instance.ReloadLevel();
    }

    public void ShowFailScreen()
    {
        failScreen.SetActive(true);
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
