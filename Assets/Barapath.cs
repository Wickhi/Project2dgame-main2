using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barapath : MonoBehaviour
{
    public int GridSizeX;
    public int GridSizeY;
    public int CellSize;
    private baranode[,] grid;
    public GameObject neighbor;
    public baranode node;
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    public GameObject Upleft;
    public GameObject Upright;
    public GameObject Downleft;
    public GameObject Downright;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> neighbors;
    // https://pavcreations.com/tilemap-based-a-star-algorithm-implementation-in-unity-game/
    // https://pavcreations.com/pathfinding-with-a-star-algorithm-in-unity-small-game-project/
    // Start is called before the first frame update
    private void Start()
    {
        CreateGrid();
        GenerateNavMesh();
    }
    private void Update()
    {

    }
    void CreateGrid()
    {
        grid = new baranode[GridSizeX, GridSizeY];
        Vector3 gridOffset = transform.position - new Vector3(GridSizeX * CellSize / 2f, GridSizeY * CellSize / 2f, 0f);

        for (int x = 0; x < GridSizeX; x++)
        {
            for (int y = 0; y < GridSizeY; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                bool isWalkable = false;
                //RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.zero);
                //if (hit.collider == null)
                //{
                // No collision, cell is walkable
                isWalkable = true;
                //}
                GameObject cellObject = new GameObject("Cell (" + x + ", " + y + ")");
                cellObject.transform.SetParent(transform);
                cellObject.AddComponent<SpriteRenderer>();
                spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 0f);
                grid[x, y] = cellObject.AddComponent<baranode>();
                grid[x, y].position = position;
                grid[x, y].walkable = isWalkable;
                
            }
        }
    }
    void GenerateNavMesh()
    {





        for (int fx = 0; fx < GridSizeX; fx++)
        {
            for (int fy = 0; fy < GridSizeY; fy++)
            {
                node = GameObject.Find(("Cell (" + fx + ", " + fy + ")"));
                node.GetComponent<baranode>().place = "normal";
                Debug.Log("Node= " + node.name);
                if (fy == GridSizeY - 1)
                {

                    //Top
                    if (fx == GridSizeX - GridSizeX)
                    {
                        //Top left
                        node.GetComponent<baranode>().special = true;
                        node.GetComponent<baranode>().place = "top left";
                        
                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Top right
                        node.GetComponent<baranode>().place = "top right";
                        node.GetComponent<baranode>().special = true;
                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        node.GetComponent<baranode>().place = "only top";
                        
                    }


                }
                if (fy == GridSizeY - GridSizeY)
                {
                    //Bottom
                    Debug.Log("Node= " + node.name);
                    if (fx == GridSizeX - GridSizeX)
                    {
                        //Bottom left
                        node.GetComponent<baranode>().place = "bottom left";
                        node.GetComponent<baranode>().special = true;
 

                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Bottom right
                        node.GetComponent<baranode>().place = "bottom right";
                        node.GetComponent<baranode>().special = true;


                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        node.GetComponent<baranode>().place = "only bottom";


                    }


                }
                if (fx == GridSizeX - 1)
                {
                    //node.GetComponent<baranode>().place = "right";
                    //right
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {

                        node.GetComponent<baranode>().place = "right";
 
                    }
                }
                if (fx == GridSizeX - GridSizeX)
                {

                    //left
                    //node.GetComponent<baranode>().place = "left";
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {

                        node.GetComponent<baranode>().place = "left";

                    }
                }
                if (node.GetComponent<baranode>().place != "normal")
                {
                    node.GetComponent<SpriteRenderer>().color = Color.red;

                }
                if (node.position.x - 1 >=0)
                {

                }



            }


        }
    }
 }

