using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public GameObject blockPrefab;
    public GameObject tunnelPrefab;
    public GameObject baseTile;

    public GameObject actorPrefab, barrelPrefab;
    public GameObject smokeTrail;
    public LayerMask baseMask;
    public List<GameObject> levelRelatedGameobjects;
    public Transform envParent, tunnelParent;
    public Transform camera;
    public Transform nestPos;
    public bool IsPrefabMode = true;
    private void Awake()
    {
        instance = this;
    }

    public IEnumerator MakeLevel(LevelData levelData)
    {
        //int varaince = levelData.actors.Count - Objective.Instance.itemSOs.Count;
        //if (varaince>0)
        //{
        //    Objective.Instance.GetExtra(varaince);
        //}

        //for (int i = 0; i < levelData.actors.Count; i++)
        //{
        //    levelData.actors[i] = Objective.Instance.itemSOs[i].inGamePrefab;
        //}

        ShortestPath.instance.terminalNodes.Clear();
        levelRelatedGameobjects.ForEach(x => { DOTween.KillAll(); Destroy(x); });
        levelRelatedGameobjects.Clear();
        GameplayManager.instance.actorsRequired = 0;
        yield return new WaitForEndOfFrame();

        camera.position = new Vector3(levelData.cameraPos.x, camera.position.y, camera.position.z);
        nestPos.position = new Vector3(levelData.cameraPos.x, nestPos.position.y, nestPos.position.z);

        for (int i = 0; i < levelData.objects.Count; i++)
        {
            var info = levelData.objects[i];

            GameObject toSpawn = null;

            if (info.objectType == DataType.Block)
                toSpawn = blockPrefab;

            if (info.objectType == DataType.ActorTile || info.objectType == DataType.EmptyTile || info.objectType == DataType.BarrelTile)
            {
                toSpawn = baseTile;
            }

            var clone = Instantiate(toSpawn, info.position, Quaternion.identity);
            clone.AddComponent<BoxCollider>();

            if (info.objectType == DataType.ActorTile || info.objectType == DataType.EmptyTile || info.objectType == DataType.BarrelTile)
            {
                var tile = clone.GetComponent<Base>();
                tile.dataType = info.objectType;
                clone.gameObject.layer = 7;
                clone.gameObject.name = envParent.childCount.ToString();
                if (info.objectType == DataType.ActorTile || info.objectType == DataType.BarrelTile)
                {
                    tile.color = levelData.colorArray[info.colorIndex];
                    tile.colorIndex = info.colorIndex;
                    if (info.objectType == DataType.BarrelTile)
                    {
                        tile.InBarrel = true;
                    }

                    GameplayManager.instance.actorsRequired++;
                }
            }

            levelRelatedGameobjects.Add(clone);
            clone.transform.SetParent(envParent);
        }

        //Generate Tunnels
        for (int i = 0; i < levelData.tunnels.Count; i++)
        {
            GameObject toSpawn = tunnelPrefab;
            var tunnel = levelData.tunnels[i];

            var tunnelClone = Instantiate(toSpawn, tunnel.position, Quaternion.identity);
            tunnelClone.transform.eulerAngles = tunnel.eulerAngles;
            var tunnelScript = tunnelClone.GetComponent<Tunnel>();
            tunnelScript.tunnelArray.AddRange(tunnel.colorArray);
            GameplayManager.instance.actorsRequired += tunnelScript.tunnelArray.Count;
            levelRelatedGameobjects.Add(tunnelClone);
            tunnelClone.transform.SetParent(tunnelParent);
        }

        GameplayManager.instance.ActorsDone = 0;
        yield return new WaitForSeconds(1f);
        Base.CheckForFree?.Invoke();

    }
}
