using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baranode : MonoBehaviour
{
    public Vector2Int position;
    public bool walkable;
    public List<GameObject> neighbors;
    public int gCost;
    public int hcost;
    public int fCost;
    public baranode parent;
    public bool special;
    public string place = "normal";
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    public GameObject Upleft;
    public GameObject Upright;
    public GameObject Downleft;
    public GameObject Downright;
    public bool szamlalo = false;

    public int CalculateDistanceCost(baranode targetNode)
    {
        return Mathf.Abs(position.x - targetNode.position.x) + Mathf.Abs(position.y - targetNode.position.y);
    }
    void Update()
    {
        if (szamlalo == false)
            {
            if (place == "normal")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Left = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Upright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y + 1) + ")"));
                Downright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y - 1) + ")"));
                Upleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y + 1) + ")"));
                Downleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y - 1) + ")"));
                neighbors.Add(Up);
                neighbors.Add(Left);
                neighbors.Add(Down);
                neighbors.Add(Right);
                neighbors.Add(Downleft);
                neighbors.Add(Downright);
                neighbors.Add(Upright);
                neighbors.Add(Upleft);


            }
            if (place == "top left")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Downright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y - 1) + ")"));
                neighbors.Add(Right);
                neighbors.Add(Down);
                neighbors.Add(Downright);
            }
            if (place == "top right")
            {
                Left = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Downleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y - 1) + ")"));
                neighbors.Add(Left);
                neighbors.Add(Down);
                neighbors.Add(Downleft);
            }
            if (place == "only top")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Left = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Downleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y - 1) + ")"));
                Downright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y - 1) + ")"));
                neighbors.Add(Right);
                neighbors.Add(Left);
                neighbors.Add(Down);
                neighbors.Add(Downleft);
                neighbors.Add(Downright);
            }
            if (place == "bottom left")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Debug.Log("Cell (" + (position.x + 1) + ", " + position.y + ")");
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Upright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y + 1) + ")"));
                neighbors.Add(Right);
                neighbors.Add(Up);
                neighbors.Add(Upright);

            }
            if (place == "bottom right")
            {
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Left = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Upleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y + 1) + ")"));
                neighbors.Add(Up);
                neighbors.Add(Left);
                neighbors.Add(Upleft);
            }
            if (place == "only bottom")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Left = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Upleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y + 1) + ")"));
                Upright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y + 1) + ")"));
                neighbors.Add(Right);
                neighbors.Add(Left);
                neighbors.Add(Up);
                neighbors.Add(Upleft);
                neighbors.Add(Upright);
            }
            if (place == "right")
            {
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Upleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y + 1) + ")"));
                Downleft = GameObject.Find(("Cell (" + (position.x - 1) + ", " + (position.y - 1) + ")"));

                neighbors.Add(Up);
                neighbors.Add(Down);
                neighbors.Add(Upleft);
                neighbors.Add(Downleft);
            }
            if (place == "left")
            {
                Right = GameObject.Find(("Cell (" + (position.x + 1) + ", " + position.y + ")"));
                Up = GameObject.Find(("Cell (" + (position.x) + ", " + (position.y + 1) + ")"));
                Down = GameObject.Find(("Cell (" + position.x + ", " + (position.y - 1) + ")"));
                Upright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y + 1) + ")"));
                Downright = GameObject.Find(("Cell (" + (position.x + 1) + ", " + (position.y - 1) + ")"));
                neighbors.Add(Right);
                neighbors.Add(Up);
                neighbors.Add(Down);
                neighbors.Add(Upright);
                neighbors.Add(Downright);
            }
            
        }
        szamlalo = true;
    }
}
