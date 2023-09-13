using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ServiceHire : MonoBehaviour
{
    public bool isOccupied;
    public List<ParticleSystem> effects;

    public int childrenDestroyed;

    public GameObject service;
    void Start()
    {
        foreach (ParticleSystem item in effects)
        {
            item.Stop();
        }
    }

    public IEnumerator PlayEffects()
    {
        service.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
        effects[0].Play(); 
        effects[1].Play();
        yield return new WaitForSeconds(0.10f);
        service.SetActive(true);
        service.transform.DOScale(new Vector3(1, 1, 1), 0.75f); 
        yield return new WaitForSeconds(0.75f);
        foreach (Transform child in transform)
        {
            // Check if we have destroyed the first two children.
            if (childrenDestroyed < 2)
            {
                // Destroy the child.
                Destroy(child.gameObject);
                childrenDestroyed++;
            }
            else
            {
                // If we have already destroyed the first two children, break out of the loop.
                break;
            }
        }

    }



}
