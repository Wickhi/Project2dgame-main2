using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kurva : MonoBehaviour
{
    public int magas;
    public int szélesség;
    public float cellsize;
    public int[,] gridarray;
    // Start is called before the first frame update
    void Start()
    {
        //https://github.com/7ark/Unity-Pathfinding

        gridarray = gridarray [magas, szélesség];
        for (int x = 0; x < gridarray.GetLength(0); x++)
        {
            for (int y = 0; x < gridarray.GetLength(1); y++)
            {
                Debug.Log(x, y);
            }
        }




    }


// Update is called once per frame
    void Update()
    {

    }
}
