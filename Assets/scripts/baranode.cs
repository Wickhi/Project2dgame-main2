using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baranode : MonoBehaviour
{
    public Vector2Int position;
    public bool walkable;
    public GameObject Regifaszanyad;
    public GameObject Faszanyad;
    public List<GameObject> neighbors;
    public int gCost;
    public int hcost;
    public int fCost;
    public baranode parent;
    public bool special;
    public string place = "normal";


    public int CalculateDistanceCost(baranode targetNode)
    {
        return Mathf.Abs(position.x - targetNode.position.x) + Mathf.Abs(position.y - targetNode.position.y);
    }

    void Update()
    {
        if (Faszanyad != Regifaszanyad)
        {
            neighbors.Add(Faszanyad);

        }
    }
}
