using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public Actor[] actorsInNest;
    public List<Transform> nests;

    public Levels levels;
    public int currentLevel = 0;
    [SerializeField] int track = 0;
    public LevelData currentLoadedLevel;

    public int actorsRequired;
    [SerializeField] int actorsDone;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        actorsInNest = new Actor[7];
        Track = track;
        StartCoroutine(LevelGenerator.instance.MakeLevel(currentLoadedLevel));
    }

    public void ReloadLevel()
    {
        actorsInNest = new Actor[7];
        StartCoroutine(LevelGenerator.instance.MakeLevel(currentLoadedLevel));
    }

    public void AddInNest(Actor actor)
    {
        var actorsList = actorsInNest.ToList();
        actorsList.RemoveAll(a => a == null);

        if (actorsList.Count >= 7)
            return;

        var lastActorOfSameColor = actorsList.FindLast(x => x.Color == actor.Color);
        if (lastActorOfSameColor != null)
        {
            int index = actorsList.IndexOf(lastActorOfSameColor);

            //Shifting elements
            for (int i = actorsInNest.Length - 2; i > index; i--)
            {
                actorsInNest[i + 1] = actorsInNest[i];
                actorsInNest[i] = null;
            }
            actorsInNest[index + 1] = actor;
        }
        else
        {
            actorsInNest[actorsList.Count] = actor;
        }
        PositionSelf();
    }

    public List<Actor> tempList = new List<Actor>();

    public int ActorsDone
    {
        get => actorsDone;
        set
        {
            actorsDone = value;
            if (actorsDone >= actorsRequired)
            {
                StartCoroutine(LoadNextLevel());
            }
        }
    }

    public int Track
    {
        get => track;
        set
        {
            track = value;

            if (track == 0)
                currentLoadedLevel = levels.levels[currentLevel].levelA;

            if (track == 1)
                currentLoadedLevel = levels.levels[currentLevel].levelB;

            if (track == 2)
                currentLoadedLevel = levels.levels[currentLevel].levelC;

            if (track >= 3)
            {
                currentLevel++;
                track = 0;
                currentLoadedLevel = levels.levels[currentLevel].levelA;
            }

            UIManager.instance.levelName.text = $"Level {currentLevel + 1}";
        }
    }

    IEnumerator LoadNextLevel()
    {
        print("Next Level");
        yield return new WaitForSeconds(3f);
        Track++;
        StartCoroutine(LevelGenerator.instance.MakeLevel(currentLoadedLevel));
    }

    IEnumerator CheckForWin()
    {
        yield return new WaitForSeconds(0.5f);
        tempList = new List<Actor>();
        var actor = actorsInNest[0];
        tempList.Add(actor);
        int counter = 1;
        for (int i = 1; i < actorsInNest.Length; i++)
        {
            if (actorsInNest[i] == null)
            {
                if (counter == 3)
                {
                    Debug.Log(1);
                    RemoveActorsRoutine=StartCoroutine(RemoveActors(tempList));
                }
                break;
            }

            if (actor.Color == actorsInNest[i].Color)
            {
                tempList.Add(actorsInNest[i]);
                counter++;
            }
            else
            {
                tempList.Clear();
                actor = actorsInNest[i];
                tempList.Add(actor);
                counter = 1;
            }

            if (counter >= 3)
            {
                Debug.Log(2);
                RemoveActorsRoutine=StartCoroutine(RemoveActors(tempList));
                tempList.Clear();
            }
        }

        var list = actorsInNest.ToList();
        list.RemoveAll(x => x == null);
        if (list.Count >= 7)
        {
            UIManager.instance.ShowFailScreen();
        }
    }

    Coroutine RemoveActorsRoutine,CheckWinRountine;

    IEnumerator RemoveActors(List<Actor> actors)
    {
        var list = actorsInNest.ToList();
        actors.ForEach(x => 
        { 
            list.Remove(x); 
            //Inventory.instance.AddItem(x.GetComponent<Item>()); 
            x.destroyEvent?.Invoke(); 
            ActorsDone++; 
        });

        actorsInNest = new Actor[7];
        for (int i = 0; i < list.Count; i++)
        {
            actorsInNest[i] = list[i];
        }
        yield return new WaitForSeconds(0.8f);
        PositionSelf();
    }

    void PositionSelf()
    {
        var actorsList = actorsInNest.ToList();
        actorsList.RemoveAll(a => a == null);
        for (int i = 0; i < actorsList.Count; i++)
        {
            var actor = actorsInNest[i];
            actor.transform.DODynamicLookAt(nests[i].position+Vector3.back*0.1f, 0.5f, AxisConstraint.Y);
            actor.transform.DOMove(nests[i].position, 0.4f)
                .OnComplete(() => 
                { 
                    actor.animator.SetBool("crawl to sit", true); 
                    actor.animator.SetBool("crawling", false); })
                .WaitForCompletion();
        }


        if (CheckWinRountine != null)
            StopCoroutine(CheckWinRountine);

        CheckWinRountine= StartCoroutine(CheckForWin());
    }
}
