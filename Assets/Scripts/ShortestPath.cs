using System;
using System.Collections.Generic;
using UnityEngine;

public class ShortestPath : MonoBehaviour
{
    public static ShortestPath instance;

    public List<Base> terminalNodes;

    private void Awake()
    {
        instance = this;
    }

    bool isTerminalNode(Base node)
    {
        if(terminalNodes.Contains(node))
            return true;
        else
            return false;
    }

    public Queue<Base> FindShortestPath(Base startNode)
    {
        Queue<Base> shortestPath = null;
        for(int i = 0; i < terminalNodes.Count; i++) 
        {
            var foundPath=Dijkstra(startNode, terminalNodes[i]);
            if(foundPath != null)
            {
                if (shortestPath==null)
                {
                    shortestPath = foundPath;
                }
                else
                {
                    if (shortestPath.Count > foundPath.Count)
                    {
                        shortestPath=foundPath;
                    }
                }
            }
        }
        return shortestPath;
    }

    public Queue<Base> Dijkstra(Base start, Base goal)
    {
        if (goal.dataType != DataType.EmptyTile)
            return null;

        Dictionary<Base, Base> NextTileToGoal = new Dictionary<Base, Base>();//Determines for each tile where you need to go to reach the goal. Key=Tile, Value=Direction to Goal
        Dictionary<Base, int> costToReachTile = new Dictionary<Base, int>();//Total Movement Cost to reach the tile

        PriorityQueue<Base> frontier = new PriorityQueue<Base>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Base curTile = frontier.Dequeue();
            if (curTile == start)
                break;

            foreach (Base neighbor in curTile.neighbours)
            {
                int newCost = (costToReachTile[curTile] + neighbor.cost);
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor.dataType == DataType.EmptyTile || neighbor==start)
                    {
                        costToReachTile[neighbor] = newCost;
                        int priority = newCost;
                        frontier.Enqueue(neighbor, priority);
                        NextTileToGoal[neighbor] = curTile;
                        //neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        //Get the Path

        //check if tile is reachable
        if (NextTileToGoal.ContainsKey(start) == false)
        {
            print("No path found");
            return null;
        }

        Queue<Base> path = new Queue<Base>();
        Base pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        print($"Path found ! Count {path.Count}");
        return path;
    }
}

