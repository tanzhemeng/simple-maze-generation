using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private int size = 4;

    [Header("Prefabs")]
    [SerializeField] private Transform _floorTilePrefab;
    [SerializeField] private Transform _horizontalWallPrefab;
    [SerializeField] private Transform _verticalWallPrefab;

    [Header("Parents")]
    [SerializeField] private Transform _floorTileParent;
    [SerializeField] private Transform _horizontalWallParent;
    [SerializeField] private Transform _verticalWallParent;

    public void Spawn(Gridmap grid)
    {
        for (int row = 0; row < grid.Rows; row++)
        {
            for (int column = 0; column < grid.Columns; column++)
            {
                Cell cell = grid.GetCell(row, column);

                if (column + 1 < grid.Columns && cell.Linked(cell.East) == false)
                {
                    Instantiate(_verticalWallPrefab, GridToWorld(row, column + 0.5f, grid), _verticalWallPrefab.rotation, _verticalWallParent);
                }

                if (row + 1 < grid.Rows && cell.Linked(cell.North) == false)
                {
                    Instantiate(_horizontalWallPrefab, GridToWorld(row + 0.5f, column, grid), _horizontalWallPrefab.rotation, _horizontalWallParent);
                }

                Instantiate(_floorTilePrefab, GridToWorld(row, column, grid), _floorTilePrefab.rotation, _floorTileParent);
            }
        }
    }

    private Vector3 GridToWorld(float row, float column, Gridmap grid)
    {
        return new Vector3((-grid.Columns / 2 + column + 0.5f) * size, 0, (-grid.Rows / 2 + row + 0.5f) * size);
    }
}
