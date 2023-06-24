using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HuntAndKill : Algorithm
{
    public override void On(Gridmap grid)
    {
        Cell current = grid.GetRandomCell();

        while (current != null)
        {
            List<Cell> unvisited_neighbors = current.Neighbors.Where(c => c.Links.Count == 0).ToList();

            if (unvisited_neighbors.Any())
            {
                int index = Random.Range(0, unvisited_neighbors.Count);
                Cell neighbor = unvisited_neighbors[index];
                current.Link(neighbor);
                current = neighbor;
            }
            else
            {
                current = null;

                foreach (var cell in grid.EachCell())
                {
                    List<Cell> visited_neighbors = cell.Neighbors.Where(c => c.Links.Any()).ToList();
                    if (cell.Links.Count == 0 && visited_neighbors.Any())
                    {
                        current = cell;

                        int index = Random.Range(0, visited_neighbors.Count);
                        var neighbor = visited_neighbors[index];
                        current.Link(neighbor);
                        break;
                    }
                }
            }
        }
    }
}
