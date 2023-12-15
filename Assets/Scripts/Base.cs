using UnityEngine;
using DG.Tweening;
using System;
using System.Collections.Generic;

public class Base : MonoBehaviour
{
    public Actor actor;

    public Color color;
    public int colorIndex;
    public DataType dataType;
    public Base left, right, up, down;

    public GameObject barrel;
    public static Action CheckForFree;
    public static float offset = 1f;
    public static float radius = 0.1f;
    [SerializeField] bool inBarrel;
    public int cost;
    public List<Base> neighbours = new List<Base>();
    public bool InBarrel { get => inBarrel; set => inBarrel = value; }

    private void OnEnable()
    {
        CheckForFree += IsFree;
    }

    private void OnDisable()
    {
        CheckForFree -= IsFree;
    }

    private void Start()
    {
        if (dataType == DataType.ActorTile)
        {
            SpawnActor();
        }

        if (dataType == DataType.BarrelTile)
        {
            SpawnBarrel();
        }

        if (dataType == DataType.EmptyTile)
            cost = 1;

        CheckForNeighboursBases();
    }

    void SpawnBarrel()
    {
        barrel = Instantiate(LevelGenerator.instance.barrelPrefab, transform.position, Quaternion.identity, transform);
        LevelGenerator.instance.levelRelatedGameobjects.Add(barrel);
    }

    void SpawnActor()
    {
        if (InBarrel)
        {
            LevelGenerator.instance.levelRelatedGameobjects.Remove(barrel);
            Instantiate(FXManager.instance.woodBlast, transform.position + Vector3.up * 1f, Quaternion.identity);
            dataType = DataType.ActorTile;
            Destroy(barrel);
        }

        InBarrel = false;
        GameObject spawnedGO;
        if (LevelGenerator.instance.IsPrefabMode == false)
        {
            spawnedGO = Instantiate(GameplayManager.instance.currentLoadedLevel.actors[colorIndex], transform.position, Quaternion.identity, transform);
        }
        else
        {
            spawnedGO = Instantiate(LevelGenerator.instance.actorPrefab, transform.position, Quaternion.identity, transform);
            Instantiate(LevelGenerator.instance.smokeTrail, spawnedGO.transform.position, Quaternion.identity, spawnedGO.transform);
        }
        spawnedGO.transform.DOLocalMoveY(spawnedGO.transform.position.y + 0.02f, 0);
        spawnedGO.transform.DOLocalRotate(new Vector3(0, 180, 0), 0);
        actor = spawnedGO.GetComponent<Actor>();
        actor.Color = color;
        actor.currentBase = this;
        LevelGenerator.instance.levelRelatedGameobjects.Add(actor.gameObject);
    }

    private void CheckForNeighboursBases()
    {
        var up = Physics.OverlapSphere(transform.position + Vector3.forward * offset, radius, LevelGenerator.instance.baseMask);
        var down = Physics.OverlapSphere(transform.position + Vector3.back * offset, radius, LevelGenerator.instance.baseMask);
        var right = Physics.OverlapSphere(transform.position + Vector3.right * offset, radius, LevelGenerator.instance.baseMask);
        var left = Physics.OverlapSphere(transform.position + Vector3.left * offset, radius, LevelGenerator.instance.baseMask);

        if (up.Length > 0)
        {
            this.up = up[0].GetComponent<Base>();
            neighbours.Add(this.up);
        }

        if (down.Length > 0)
        {
            this.down = down[0].GetComponent<Base>();
            neighbours.Add(this.down);
        }
        else
        {
            var isDownfree = Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.back, 0.8f);
            if (!isDownfree)
            {
                ShortestPath.instance.terminalNodes.Add(this);
            }
        }

        if (left.Length > 0)
        {
            this.left = left[0].GetComponent<Base>();
            neighbours.Add(this.left);
        }

        if (right.Length > 0)
        {
            this.right = right[0].GetComponent<Base>();
            neighbours.Add(this.right);
        }

    }

    public void IsFree()
    {
        if (dataType == DataType.ActorTile || dataType == DataType.BarrelTile)
        {
            Queue<Base> foundPath = new Queue<Base>();
            foundPath = ShortestPath.instance.FindShortestPath(this);
            if (foundPath != null)
            {
                if (InBarrel)
                    SpawnActor();

                actor.CanInteract = true;
                return;

            }
            else
            {
                if (ShortestPath.instance.terminalNodes.Contains(this))
                {
                    actor.CanInteract = true;
                    return;
                }
            }

            if (!InBarrel)
                actor.CanInteract = false;
        }
       
        /*
        if (dataType == DataType.ActorTile || dataType == DataType.BarrelTile)
        {
            

        var isLeftFree = Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.left, 0.8f);
        if (isLeftFree == false)
        {
            if (InBarrel)
                SpawnActor();

            actor.CanInteract = true; return;
        }

        var isRightFree = Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.right, 0.8f);
        if (isRightFree == false)
        {
            if (InBarrel)
                SpawnActor();

            actor.CanInteract = true; return;
        }

        var isUpFree = Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.forward, 0.8f);
        if (isUpFree == false)
        {
            if (InBarrel)
                SpawnActor();
            actor.CanInteract = true; return;
        }

        var isDownfree = Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.back, 0.8f);
        if (isDownfree == false)
        {
            if (InBarrel)
                SpawnActor();
            actor.CanInteract = true; return;
        }

        if (!InBarrel)
            actor.CanInteract = false;
        }/*/
    }
}
