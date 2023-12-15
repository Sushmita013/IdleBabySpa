using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tunnel : MonoBehaviour
{
    [SerializeField] Actor spawnedActor;
    public Base spawnTile;
    public List<int> tunnelArray=new List<int>();
    [SerializeField] int index;
    [SerializeField] TextMeshPro remaining;

    public int Index 
    { 
        get => index;
        set
        { 
            index = value;
            remaining.text = $"{tunnelArray.Count - index}";
        }
    }

    private void Start()
    {
        Index = 0;
        remaining.transform.eulerAngles = new Vector3(90, 90, 90);
        if (SceneManager.GetActiveScene().name != "GameScene")
            return;

        var up = Physics.OverlapSphere(transform.position + transform.forward * 1, 0.1f, LevelGenerator.instance.baseMask);

        if (up.Length > 0)
        {
            spawnTile = up[0].GetComponent<Base>();
            spawnTile.actor.interactEvent.AddListener(SpawnActor);
        }
    }

    public void SpawnActor()
    {
        if (Index >= tunnelArray.Count)
            return;

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject spawnedGO;
        if (LevelGenerator.instance.IsPrefabMode == false)
        {
            spawnedGO = Instantiate(GameplayManager.instance.currentLoadedLevel.actors[tunnelArray[Index]], transform.position, Quaternion.identity, transform);
        }
        else
        {
            spawnedGO = Instantiate(LevelGenerator.instance.actorPrefab, transform.position, Quaternion.identity, transform);
        }

        spawnedGO.transform.localScale = Vector3.zero;
        spawnedGO.transform.DOLocalMoveY(spawnedGO.transform.position.y + 0.02f, 0);
        spawnedGO.transform.localEulerAngles = Vector3.zero;
        
        spawnedActor = spawnTile.actor = spawnedGO.GetComponent<Actor>();
        spawnedActor.Color = GameplayManager.instance.currentLoadedLevel.colorArray[tunnelArray[Index]];
        spawnedActor.currentBase = spawnTile;
        spawnTile.dataType = DataType.ActorTile;
        Base.CheckForFree?.Invoke();
        spawnedGO.transform.DOMove(spawnTile.transform.position, 0.3f).SetEase(Ease.Linear);
        spawnedGO.transform.DOScale(Vector3.one*0.8f, 0.3f).SetEase(Ease.Linear).OnComplete(() => 
        {
            Instantiate(LevelGenerator.instance.smokeTrail, spawnedGO.transform.position, Quaternion.identity, spawnedGO.transform);
            spawnedGO.transform.DORotate(new Vector3(0, 180, 0), 0.1f);
            spawnTile.actor.interactEvent.AddListener(SpawnActor);
        });
        LevelGenerator.instance.levelRelatedGameobjects.Add(spawnedActor.gameObject);
        Index++;
    }
}
