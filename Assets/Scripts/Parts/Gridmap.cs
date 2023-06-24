using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridmap
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Cell[][] Cells { get; private set; }

    public int Size
    {
        get
        {
            return Rows * Columns;
        }
    }

    public Gridmap(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        PrepareCells();
        ConfigureCells();
    }

    private void PrepareCells()
    {
        Cells = new Cell[Rows][];

        for (int row = 0; row < Rows; row++)
        {
            Cells[row] = new Cell[Columns];

            for (int column = 0; column < Columns; column++)
            {
                Cells[row][column] = new Cell(row, column);
            }
        }
    }

    private void ConfigureCells()
    {
        for (int row = 0; row < Cells.Length; row++)
        {
            for (int column = 0; column < Cells[row].Length; column++)
            {
                if (row - 1 >= 0)
                {
                    Cells[row][column].South = Cells[row - 1][column];
                }

                if (row + 1 < Rows)
                {
                    Cells[row][column].North = Cells[row + 1][column];
                }

                if (column - 1 >= 0)
                {
                    Cells[row][column].West = Cells[row][column - 1];
                }

                if (column + 1 < Columns)
                {
                    Cells[row][column].East = Cells[row][column + 1];
                }
            }
        }
    }

    public IEnumerable<Cell[]> EachRow()
    {
        for (int row = 0; row < Rows; row++)
        {
            yield return Cells[row];
        }
    }

    public IEnumerable<Cell> EachCell()
    {
        for (int row = 0; row < Cells.Length; row++)
        {
            for (int column = 0; column < Cells[row].Length; column++)
            {
                yield return Cells[row][column];
            }
        }
    }

    public Cell GetCell(int row, int column)
    {
        return Cells[row][column];
    }

    public Cell GetRandomCell()
    {
        int randomRow = Random.Range(0, Rows);
        int randomColumn = Random.Range(0, Cells[randomRow].Length);

        return Cells[randomRow][randomColumn];
    }
}
