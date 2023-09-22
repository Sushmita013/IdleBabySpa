using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public string workerType;

    public Animation anim;

    public int workerLevel; 
    public float levelUpCost; 
    public float levelCost; 
    public float workingDuration; 

    public bool isWorking; 

    public List<GameObject> workerUpgrades;
     

    private Animator animator;
    public float animationDuration = 5.0f;


    void Start()
    {
    animator = GetComponent<Animator>(); 
    }
    public IEnumerator Movement()
    {
        yield return new WaitForSeconds(1);
        PlayAnimation("Massage");
    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
        //if (isWorking)
        //{
        //    anim.Play(animation);
        //    animationDuration -= Time.deltaTime;

        //    // If the duration is less than or equal to 0, stop the animation
        //    if (animationDuration <= 0)
        //    {
        //        animator.speed = 0; // Pause the animation
        //                            // You can also add any other logic you want to perform when stopping the animation here
        //    }
        //}
        //else
        //{
        //    anim.Stop(animation);
        //}
    }

    public void LevelUp()
    {
        if(GameManager.instance.totalBalance>= levelUpCost)
        { 
        }
    }
}
