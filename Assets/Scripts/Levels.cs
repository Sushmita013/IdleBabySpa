using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Level
{
    public LevelData levelA, levelB, levelC;
}

public class Levels : MonoBehaviour
{
    public List<Level> levels;
}
