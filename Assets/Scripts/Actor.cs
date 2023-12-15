using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    public static float speed = 0.2f;
    [SerializeField] bool canInteract;
    [SerializeField] int materialIndex;
    [SerializeField] Color color;

    public UnityEvent interactEvent;

    public Animator animator;
    public MeshRenderer meshRenderer;
    public UnityEvent destroyEvent;
    public Base currentBase;

    public List<Base> path;
    public int pathCost;

    public Color Color
    {
        get => color;
        set
        {
            color = value;
            
            if(LevelGenerator.instance.IsPrefabMode==true)
                meshRenderer.materials[materialIndex].SetColor("_BaseColor", color);
        }
    }

    public bool CanInteract
    {
        get => canInteract;
        set
        {
            canInteract = value;
            if (canInteract)
            {
                animator.SetBool("SitDown", false);
            }
            else
            {
                animator.SetBool("SitDown", true);
            }
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseUpAsButton()
    {
        if (UIManager.IsPointerOverUIObject())
            return;

        if (!CanInteract)
            return;

        transform.DOPunchScale(Vector3.one * 1.003f, 0.3f, 1, 0).SetEase(Ease.OutBack);
        transform.parent = null;
       
        GetComponent<Collider>().enabled = false;
        animator.SetBool("Walk", true);
        interactEvent?.Invoke();

        if (transform.position.z <= -2)
        {
            GameplayManager.instance.AddInNest(this);
            currentBase.dataType = DataType.EmptyTile;
            Base.CheckForFree?.Invoke();
            return;
        }
        else
        {
            Queue<Base> foundPath = new Queue<Base>();
            foundPath = ShortestPath.instance.FindShortestPath(currentBase);
            if (foundPath != null)
            {
                path.AddRange(foundPath);
                FollowPath(path);
                currentBase.dataType = DataType.EmptyTile;
            }

            Base.CheckForFree?.Invoke();
        }
    }

    int index = 0;
    void FollowPath(List<Base> path)
    {
        transform.DOMove(path[index].transform.position + Vector3.up * 0.1f, speed).SetEase(Ease.Linear)
            .OnStart(() =>
            {
                if (index < path.Count)
                    transform.DOLookAt(path[index].transform.position, 0.1f, AxisConstraint.Y);
            })
            .OnComplete(() =>
               {
                   if (transform.position.z <= -2)
                   {
                       GameplayManager.instance.AddInNest(this);
                       return;
                   }
                   if (index < path.Count)
                       FollowPath(path);
               });
        index++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + Vector3.up * 0.2f, Vector3.forward * 0.5f);
        Gizmos.DrawRay(transform.position + Vector3.up * 0.2f, Vector3.back * 0.5f);
        Gizmos.DrawRay(transform.position + Vector3.up * 0.2f, Vector3.left * 0.5f);
        Gizmos.DrawRay(transform.position + Vector3.up * 0.2f, Vector3.right * 0.5f);
    }
}