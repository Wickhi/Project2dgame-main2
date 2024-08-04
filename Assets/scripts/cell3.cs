using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cell3 : MonoBehaviour
{
     public Vector2 position;
    public int fCost = int.MaxValue;
    public int gCost = int.MaxValue;
    public int hCost = int.MaxValue;
    public Vector2 connection;
    public bool isWall;

    
}
