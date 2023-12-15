using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;
    public ParticleSystem woodBlast;
    private void Awake()
    {
        instance = this;
    }
}
