using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public GameObject eggPrefab;
    public Color color;
    private void Start()
    {
        color = GetComponent<Actor>().Color;
    }
    public void Hatch()
    {
        StartCoroutine(HatchAction());
    }

    IEnumerator HatchAction()
    {
        GetComponent<Actor>().meshRenderer.enabled = false;
        var ChickenEgg = Instantiate(eggPrefab, transform.position, transform.rotation);
        Instantiate(LevelGenerator.instance.smokeTrail, ChickenEgg.transform.position, Quaternion.identity, ChickenEgg.transform.GetChild(0).GetChild(2).GetChild(2));
        foreach (MeshRenderer meshRenderer in ChickenEgg.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material.SetColor("_Color", color);
        }
        yield return new WaitForSeconds(0.35f);
        Destroy(ChickenEgg.transform.GetChild(1).gameObject);
        ChickenEgg.transform.DOMoveZ(-15f, 2f).SetEase(Ease.Linear).OnComplete(() => Destroy(ChickenEgg.gameObject));
        Destroy(gameObject,0.1f);
    }
}
