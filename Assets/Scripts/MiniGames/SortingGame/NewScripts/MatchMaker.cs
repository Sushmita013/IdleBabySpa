using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static ToonyColorsPro.ShaderGenerator.Enums;
using UnityEditor;

public class MatchMaker : MonoBehaviour
{
    [SerializeField] Transform tra1, tra2, jumpPos, leftOpen, rightOpen;
    [SerializeField] LayerMask ToyLayer;
    [SerializeField] List<GameObject> StoredObg;
    [SerializeField] GameObject storageBox;
    [SerializeField] ParticleSystem confettiEffect;
    bool canSelect = true;
    int FinishCount = 0;
    int index = 0; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && canSelect)
        {
            if (index == 0)
            {
                index = 1;
                other.transform.DOJump(tra1.position, 2, 1, 0.5f);
            }
            else
            {
                index = 0;
                other.transform.DOJump(tra2.position, 2, 1, 0.5f);
            }

            other.transform.DORotate(Vector3.zero, 0.5f);
            other.gameObject.layer = 1;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            StoredObg.Add(other.gameObject);
            CheckForTwoSimmilarObg();
        }
    }


    void CheckForTwoSimmilarObg()
    {
        if (StoredObg.Count >= 2)
        {
            canSelect = false;
            int firstObg = StoredObg[0].GetComponent<Items>().ObjectID;
            int secondObg = StoredObg[1].GetComponent<Items>().ObjectID;

            if (firstObg == secondObg)
            {
                StartCoroutine(SimilarObg());
            }
            else
            {
                NotSimillar();
            }
        }

    }

    IEnumerator SimilarObg()
    {
        // open box 

        leftOpen.DOLocalRotate(new Vector3(90, 0, 0), 1f).SetEase(Ease.OutExpo).OnComplete(() => { StoredObg[0].GetComponent<Rigidbody>().isKinematic = false; });
        rightOpen.DOLocalRotate(new Vector3(-90, 0, 0), 1f).SetEase(Ease.OutExpo).OnComplete(() => { StoredObg[1].GetComponent<Rigidbody>().isKinematic = false; }); ;
        yield return new WaitForSeconds(1.1f);
        canSelect = true;
        FinishCount += 2;
        yield return new WaitForSeconds(0.6f);
        leftOpen.DOLocalRotate(Vector3.zero, 0.6f).SetEase(Ease.OutExpo);
        rightOpen.DOLocalRotate(Vector3.zero, 0.6f).SetEase(Ease.OutExpo);
        StoredObg[0].transform.localScale = Vector3.one * 0.65f;
        StoredObg[1].transform.localScale = Vector3.one * 0.65f;
        StoredObg.Clear();
        if (FinishCount >= 16)
        {
            //win effect 
            foreach (GameObject item in ShortingManager.instance.spawnedToys)
            {
                Destroy(item);
            }
            yield return new WaitForSeconds(0.1f); 
            storageBox.transform.DOLocalMoveZ(0, 2f);
            yield return new WaitForSeconds(2); 
            confettiEffect.Play();
        }

    }
    GameObject tmpObg;
    void NotSimillar()
    {
        index = 1;
        tmpObg = StoredObg[1].gameObject;
        Rigidbody rb = tmpObg.GetComponent<Rigidbody>();
        //    rb.useGravity = false;
        //tmpObg.GetComponent<MeshCollider>().enabled = false;
        //  rb.AddForce(Vector3.forward * Random.Range(10, 12), ForceMode.Impulse);
        // rb.AddForce(Vector3.up * Random.Range(15,18), ForceMode.Impulse);
        Invoke("Jump", 0.5f);
    }

    void Jump()
    {
        tmpObg.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        tmpObg.transform.DOJump(jumpPos.position, 3, 1, 1f).OnComplete(() =>
        {
            tmpObg.transform.gameObject.layer = 7;
            tmpObg.transform.GetComponent<Rigidbody>().isKinematic = false;
        });
        StoredObg.RemoveAt(1);
        canSelect = true;
    }
}
