using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public List<Cell> Links { get; private set; }

    public Cell North { get; set; }
    public Cell South { get; set; }
    public Cell East { get; set; }
    public Cell West { get; set; }

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;

        Links = new List<Cell>();
    }

    public Cell Link(Cell cell, bool bidirectional = true)
    {
        if (!Links.Contains(cell))
        {
            Links.Add(cell);
        }

        if (bidirectional)
        {
            cell.Link(this, false);
        }

        return this;
    }

    public Cell Unlink(Cell cell, bool bidirectional = true)
    {
        if (Links.Contains(cell))
        {
            Links.Remove(cell);
        }

        if (bidirectional)
        {
            cell.Unlink(this, false);
        }

        return this;
    }

    public bool? Linked(Cell cell)
    {
        if (cell == null)
        {
            return null;
        }

        return Links.Contains(cell);
    }

    public List<Cell> Neighbors
    {
        get
        {
            List<Cell> list = new List<Cell>();
            if (North != null) list.Add(North);
            if (South != null) list.Add(South);
            if (East != null) list.Add(East);
            if (West != null) list.Add(West);
            return list;
        }
    }
}
