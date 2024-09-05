using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2
{
    public Vector2 position;
    public int fCost = int.MaxValue;
    public int gCost = int.MaxValue;
    public int hCost = int.MaxValue;
    public Vector2 connection;
    public bool isWall;
    public bool tiletoavoid;
    public Cell2(Vector2 pos)
    {
        position = pos;
    }
}
