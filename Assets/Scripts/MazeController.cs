using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MazeType
{
    AldousBroder,
    BinaryTree,
    HuntAndKill,
    RecursiveBacktracker,
    Sidewinder
}

public class MazeController : MonoBehaviour
{
    [SerializeField, Range(8, 32)] private int _rows = 16;
    [SerializeField, Range(8, 32)] private int _columns = 16;

    [SerializeField] private MazeType _type;

    private MazeSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<MazeSpawner>();
    }

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        Gridmap grid = new Gridmap(_rows, _columns);
        new MazeGenerator(_type).Generate(grid);
        _spawner.Spawn(grid);
    }
}
