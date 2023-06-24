using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecursiveBacktracker : Algorithm
{
    public override void On(Gridmap grid)
    {
        var stack = new Stack<Cell>();
        stack.Push(grid.GetRandomCell());

        while (stack.Any())
        {
            Cell current = stack.Peek();
            List<Cell> neighbors = current.Neighbors.Where(c => c.Links.Count == 0).ToList();

            if (neighbors.Count == 0)
            {
                stack.Pop();
            }
            else
            {
                int index = Random.Range(0, neighbors.Count);
                var neighbor = neighbors[index];
                current.Link(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}
