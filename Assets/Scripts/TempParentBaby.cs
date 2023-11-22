using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempParentBaby : MonoBehaviour
{
    public Animator parent;
    public Animator baby;
    void Start()
    {
        
    }

    public void PlayAnimationParent(string animation)
    {
        parent.Play(animation);
    }
    public void PlayAnimationBaby(string animation)
    {
        baby.Play(animation);
    }
}
