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
        duration.SetActive(true);
        fillbar.DOFillAmount(1, 9); 
        PlayAnimation("Massage");
        yield return new WaitForSeconds(9);
        duration.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        PlayAnimation("Idle"); 
    }
    public IEnumerator Action3()
    { 
        duration.SetActive(true);
        fillbar.DOFillAmount(1, 9); 
        PlayAnimation("Massage");
        yield return new WaitForSeconds(9);
        duration.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        PlayAnimation("Idle"); 
    }
    public IEnumerator Action1()
    { 
        duration1.SetActive(true);
        fillbar1.DOFillAmount(1, 9);
        yield return new WaitForSeconds(9);
        duration1.SetActive(false); 
        fillbar1.DOFillAmount(0, 0.1f);
        effect.Play();
        if (GameManager.instance.massageUnlocked && !GameManager.instance.haircutUnlocked)
        { 
        GameManager.instance.totalSoftCurrency += RoomManager.instance.serviceCost;
        CanvasManager.instance.UpdateSoftCurrency();
        }
        if (GameManager.instance.massageUnlocked && GameManager.instance.haircutUnlocked)
        {
            if (RoomManager.instance.roomName == Departments.Massage) 
            {
                GameManager.instance.totalSoftCurrency += RoomManager.instance.serviceCost;
            }
            if (RoomManager.instance.roomName == Departments.Haircut) 
            {
                GameManager.instance.totalSoftCurrency += RoomManager.instance.serviceCost;
            } 
        CanvasManager.instance.UpdateSoftCurrency();
        }
    }



    public void PlayAnimation(string animation)
    {
        massage.Play(animation); 
    }
}
