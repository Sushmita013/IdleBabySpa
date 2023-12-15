using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseCursor;
    [SerializeField] InputManager inputManager;
    [SerializeField] Grid grid;
    [SerializeField] Transform possiblePlacement;
    [SerializeField] MeshRenderer placementPosBlock;
    [SerializeField] LayerMask spawnedLayer;

    public List<GameObject> blocks;
    public List<GameObject> tunnels;
    public List<GameObject> actors;
    public List<GameObject> emptyBase;
    public List<GameObject> barrelBase;

    public Material block, actor, tunnel,barrel;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition=inputManager.GetSelectedMapPosition();
        Vector3Int gridPos=grid.WorldToCell(mousePosition);
        mouseCursor.transform.position = mousePosition;
        possiblePlacement.position = grid.CellToWorld(gridPos);

        if(Input.GetMouseButton(0)) 
        {
            if (Physics.CheckSphere(possiblePlacement.position, 0.3f, spawnedLayer))
                return;
            else
                SpawnData();
        }

        if (Input.GetMouseButton(1))
        {
            var blocks = Physics.OverlapSphere(possiblePlacement.position, 0.3f, spawnedLayer);
            RemoveData(blocks);
        }
    }

    public Vector3 GetPrefabPlacementPosition()
    {
        return possiblePlacement.position;
    }

    public void UpdateIndicatorData(DataType data)
    {
        if(data==DataType.Block)    placementPosBlock.material=block;
        if (data==DataType.Tunnels) placementPosBlock.material = tunnel;
        if(data==DataType.ActorTile|| data == DataType.EmptyTile)    placementPosBlock.material = actor;
        if(data==DataType.BarrelTile)    placementPosBlock.material = barrel;
    }

    public void RemoveData(Collider[] toRemove)
    {
        for (int i = 0; i < toRemove.Length; i++)
        {
            Destroy(toRemove[i].gameObject);
        }

        blocks.RemoveAll(x => x == null);
        tunnels.RemoveAll(x => x == null);
        actors.RemoveAll(x => x == null);
        emptyBase.RemoveAll(x => x == null);
        barrelBase.RemoveAll(x => x == null);
    }

    public void SpawnData()
    {
        var x=Instantiate(possiblePlacement,possiblePlacement.position,Quaternion.identity);
        x.gameObject.layer = 6;

        if (LevelDataManager.Instance.DataType == DataType.Block)
            blocks.Add(x.gameObject);

        if (LevelDataManager.Instance.DataType == DataType.Tunnels)
        {
            tunnels.Add(x.gameObject);
            x.gameObject.AddComponent<Tunnel>();
        }

        if (LevelDataManager.Instance.DataType == DataType.ActorTile)
        {
            x.localScale = Vector3.one * 0.8f;
            x.gameObject.AddComponent<ColorIndexer>().ColorIndex=ColorMarker.instance.GetColorIndex();
            actors.Add(x.gameObject);
        }

        if (LevelDataManager.Instance.DataType == DataType.BarrelTile)
        {
            x.localScale = Vector3.one * 0.8f;
            x.gameObject.AddComponent<ColorIndexer>().ColorIndex = ColorMarker.instance.GetColorIndex();
            barrelBase.Add(x.gameObject);
        }

        if (LevelDataManager.Instance.DataType == DataType.EmptyTile)
        {
            x.localScale = Vector3.one * 0.8f;
            emptyBase.Add(x.gameObject);
        }
    }


    public void RecreateData(LevelData levelData)
    {
        blocks.ForEach(x => Destroy(x));
        tunnels.ForEach(x => Destroy(x));
        actors.ForEach(x => Destroy(x));
        emptyBase.ForEach(x => Destroy(x));
        barrelBase.ForEach(x => Destroy(x));

        blocks.Clear();
        tunnels.Clear();
        actors.Clear();
        emptyBase.Clear();
        barrelBase.Clear();

        for (int i = 0; i < levelData.objects.Count; i++)
        {
            var info = levelData.objects[i];

            UpdateIndicatorData(info.objectType);

            var x = Instantiate(possiblePlacement,info.position, Quaternion.identity);
            x.gameObject.layer = 6;

            if (info.objectType == DataType.Block)
                blocks.Add(x.gameObject);

            if (info.objectType == DataType.ActorTile)
            {
                x.localScale = Vector3.one * 0.8f;
                x.gameObject.AddComponent<ColorIndexer>().ColorIndex = info.colorIndex;
                actors.Add(x.gameObject);
            }

            if (info.objectType == DataType.BarrelTile)
            {
                x.localScale = Vector3.one * 0.8f;
                x.gameObject.AddComponent<ColorIndexer>().ColorIndex = info.colorIndex;
                barrelBase.Add(x.gameObject);
            }

            if (info.objectType == DataType.EmptyTile)
            {
                x.localScale = Vector3.one * 0.8f;
                emptyBase.Add(x.gameObject);
            }
        }


        //Create Tunnels in Level Editor
        UpdateIndicatorData(DataType.Tunnels);

        for (int i=0;i<levelData.tunnels.Count;i++)
        {
            var tunnel = levelData.tunnels[i];
            var x= Instantiate(possiblePlacement, tunnel.position, Quaternion.identity);
            x.transform.eulerAngles = tunnel.eulerAngles;
            tunnels.Add(x.gameObject);
            x.AddComponent<Tunnel>().tunnelArray.AddRange(tunnel.colorArray);
        }
       
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        if (LevelDataManager.Instance.DataType == DataType.ActorTile || LevelDataManager.Instance.DataType==DataType.BarrelTile)
        {
            var ColorIndex = ColorMarker.instance.ColorIndex;
            Gizmos.DrawIcon(possiblePlacement.position, "Color", true, LevelDataManager.Instance.currentLevelData.colorArray[ColorIndex]);
        }
    }
}
