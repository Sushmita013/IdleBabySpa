using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Masseuse : MonoBehaviour
{
    public static Masseuse instance;

    public GameObject duration;
    public GameObject duration1;

    public Animator massage;

    public Image fillbar;
    public Image fillbar1;

    public ParticleSystem effect;

    void Start()
    {
        effect.Stop();
        instance = this;
    }

    public IEnumerator Action()
    {
        yield return new WaitForSeconds(0);
        duration.SetActive(true);
        fillbar.DOFillAmount(1, 12); 
        PlayAnimation("Massage");
        yield return new WaitForSeconds(12);
        duration.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        PlayAnimation("Idle");

    }
    public IEnumerator Action1()
    {
        yield return new WaitForSeconds(0);
        duration1.SetActive(true);
        fillbar1.DOFillAmount(1, 9);
        yield return new WaitForSeconds(9);
        duration1.SetActive(false);
        fillbar1.DOFillAmount(1, 0.1f);
        effect.Play(); 
    }



    public void PlayAnimation(string animation)
    {
        massage.Play(animation); 
    }
}
