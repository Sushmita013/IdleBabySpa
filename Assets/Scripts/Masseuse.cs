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
    public GameObject duration2;

    public Animator massage;
    public Animator cashier;
    public Animator barber;

    public Image fillbar;
    public Image fillbar1;
    public Image fillbar2;

    public ParticleSystem effect;
    public ParticleSystem effect1;
    public ParticleSystem effect2;

    void Start()
    {
        effect.Stop();
        effect1.Stop();
        effect2.Stop();
        instance = this;
    }

    public IEnumerator Action()
    { 
        duration.SetActive(true);
        fillbar.DOFillAmount(1, 9); 
        PlayAnimationMassage("Massage");
        yield return new WaitForSeconds(9);
        effect1.Play();
        duration.SetActive(false);
        fillbar.DOFillAmount(0, 0.1f);
        PlayAnimationMassage("Idle"); 
    }
    public IEnumerator Action3()
    { 
        duration2.SetActive(true);
        fillbar2.DOFillAmount(1, 9); 
        PlayAnimationBarber("Haircut");
        yield return new WaitForSeconds(9);
        effect2.Play(); 
        duration2.SetActive(false);
        fillbar2.DOFillAmount(0, 0.1f);
        PlayAnimationBarber("Idle"); 
    }
    public IEnumerator Action1()
    { 
        duration1.SetActive(true);
        fillbar1.DOFillAmount(1, 9);
        PlayAnimationCashier("Payment");
        yield return new WaitForSeconds(9);
        duration1.SetActive(false); 
        fillbar1.DOFillAmount(0, 0.1f);
        effect.Play();
        PlayAnimationCashier("Idle");

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



    public void PlayAnimationMassage(string animation)
    {
        massage.Play(animation); 
    }
    public void PlayAnimationCashier(string animation)
    {
        cashier.Play(animation); 
    }
    public void PlayAnimationBarber(string animation)
    {
        barber.Play(animation); 
    }
}
