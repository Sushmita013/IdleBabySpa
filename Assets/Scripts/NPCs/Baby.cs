using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  

public class Baby : MonoBehaviour
{
    public Animation anim;

    public bool isEngaged;

    public float serviceDuration;
    private Animator animator;


    void Start()
    {
    animator = GetComponent<Animator>(); 
    }

    public void PlayAnimation(string animation)
    {
        if (isEngaged)
        {
            anim.Play(animation);
            serviceDuration -= Time.deltaTime;

            // If the duration is less than or equal to 0, stop the animation
            if (serviceDuration <= 0)
            {
                animator.speed = 0; // Pause the animation
                                    // You can also add any other logic you want to perform when stopping the animation here
            }
        }
        else
        {
            anim.Stop(animation);
        }
    }
}
