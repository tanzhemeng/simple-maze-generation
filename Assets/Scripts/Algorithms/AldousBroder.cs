using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AldousBroder : Algorithm
{
    public override void On(Gridmap grid)
    {
        Cell cell = grid.GetRandomCell();
        int unvisited = grid.Size - 1;

        while (unvisited > 0)
        {
            int index = Random.Range(0, cell.Neighbors.Count);
            Cell neighbor = cell.Neighbors[index];

            if (neighbor.Links.Count == 0)
            {
                cell.Link(neighbor);
                unvisited -= 1;
            }
            cell = neighbor;
        }
    }
}
