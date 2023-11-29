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
    public int ThemeIndex;
     

    void Start()
    { 
    }
     
    public void SetColorFunc(int currectActiveTheme)
    {
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



     
}
