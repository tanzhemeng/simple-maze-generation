using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidewinder : Algorithm
{
    public override void On(Gridmap grid)
    {
        foreach (var cellRow in grid.EachRow())
        {
            var run = new List<Cell>();

            foreach (var cell in cellRow)
            {
                run.Add(cell);

                bool atEasternBoundary = (cell.East == null);
                bool atNorthernBoundary = (cell.North == null);

                bool shouldCloseOut =
                    atEasternBoundary ||
                    (!atNorthernBoundary && Random.Range(0, 2) == 0);

                if (shouldCloseOut)
                {
                    Cell member = run[Random.Range(0, run.Count - 1)];
                    if (member.North != null)
                    {
                        member.Link(member.North);
                    }
                    run.Clear();
                }
                else
                {
                    cell.Link(cell.East!);
                }
            }
        }
    }
}
