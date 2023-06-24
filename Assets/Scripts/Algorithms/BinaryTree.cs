using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : Algorithm
{
    public override void On(Gridmap grid)
    {
        foreach (var cell in grid.EachCell())
        {
            var neighbors = new List<Cell>();

            if (cell.North != null)
            {
                neighbors.Add(cell.North);
            }

            if (cell.East != null)
            {
                neighbors.Add(cell.East);
            }

            int randomIndex = Random.Range(0, neighbors.Count);

            if (randomIndex < neighbors.Count)
            {
                var randomNeighbor = neighbors[randomIndex];
                cell.Link(randomNeighbor);
            }
        }
    }
}
