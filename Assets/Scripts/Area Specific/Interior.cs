using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

[Serializable]
public struct ThemeObject
{
    public List<MeshRenderer> meshRenderers;
}

[Serializable]
public struct Theme
{
    public List<ThemeObject> objects;
    public List<Material> materials;
}

public class Interior : MonoBehaviour
{
    public RoomManager room;

    public List<Theme> themes;
    public int currentIndex; 

    public List<bool> isUnlocked;

    public List<Button> previewButtons;
    public List<Button> buyButtons;


    void Start()
    {
        for (int i = 0; i < previewButtons.Count; i++)
        {
            int buttonIndex = i;
            previewButtons[i].onClick.AddListener(() => SetColorFunc(buttonIndex));
        }
        
        for (int i = 0; i < buyButtons.Count; i++)
        {
            int buttonIndex = i; 
            buyButtons[i].onClick.AddListener(() => UnlockColorTheme(buttonIndex));
        } 
    } 

    public void SetColorFunc(int currectActiveTheme)
    {
        Debug.Log(currectActiveTheme);
        if (isUnlocked[currectActiveTheme])
        {
            currentIndex = currectActiveTheme;
        }
        Theme theme = new Theme();

        for (int i = 0; i < themes.Count; i++)
        {
            if (i == currectActiveTheme)
            {
                theme = themes[i];
            }
        }

        for (int i = 0; i < theme.objects.Count; i++)
        {
            for (int j = 0; j < theme.objects[i].meshRenderers.Count; j++)
            {
                theme.objects[i].meshRenderers[j].material = theme.materials[i];
            }

        }
    }

    public void UnlockColorTheme(int themeNum)
    {
        if (GameManager.instance.totalSoftCurrency >= 1500)
        {
            buyButtons[themeNum].gameObject.SetActive(false);
            currentIndex = themeNum;
            isUnlocked[themeNum] = true;
            GameManager.instance.totalSoftCurrency -= 1500;
            CanvasManager.instance.UpdateSoftCurrency();
            SetColorFunc(themeNum);
        }
    }






}
