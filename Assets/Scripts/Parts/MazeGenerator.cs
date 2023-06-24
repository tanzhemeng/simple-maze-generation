using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    private Algorithm algorithm;

    public MazeGenerator(MazeType type)
    {
        switch (type)
        {
            case MazeType.AldousBroder:
                algorithm = new AldousBroder();
                break;

            case MazeType.BinaryTree:
                algorithm = new BinaryTree();
                break;

            case MazeType.HuntAndKill:
                algorithm = new HuntAndKill();
                break;

            case MazeType.RecursiveBacktracker:
                algorithm = new RecursiveBacktracker();
                break;

            case MazeType.Sidewinder:
                algorithm = new Sidewinder();
                break;
        }
    }

    public Gridmap Generate(Gridmap grid, int? seed = null)
    {
        if (seed != null)
        {
            Random.InitState(seed.Value);
        }

        algorithm.On(grid);

        return grid;
    }
}
