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
    public GameObject node;
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    public GameObject Upleft;
    public GameObject Upright;
    public GameObject Downleft;
    public GameObject Downright;
    public Sprite sprite;
    public Dictionary<Vector2, GameObject> backgroundszar;
    public Dictionary<GameObject, Vector2> backgroundszar2;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> neighbors;
    // https://pavcreations.com/tilemap-based-a-star-algorithm-implementation-in-unity-game/
    // https://pavcreations.com/pathfinding-with-a-star-algorithm-in-unity-small-game-project/
    // Start is called before the first frame update
    void Start()
    {
        backgroundszar = new Dictionary<Vector2, GameObject>();
        backgroundszar2 = new Dictionary<GameObject, Vector2>();
        CreateGrid();
        GenerateNavMesh();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            //neighbors.Add(GameObject.Find("Stuart"));
            //node.GetComponent<baranode>().neighbors = neighbors;

        }
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
                cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 10f);
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
                neighbors.Clear();
                node = GameObject.Find(("Cell (" + fx + ", " + fy + ")"));
                node.GetComponent<baranode>().place = "normal";
                //Debug.Log("Node= " + node.name);
                if (fy == GridSizeY - 1)
                {
                    //Top
                    if (fx == GridSizeX - GridSizeX)
                    {
                        //Top left
                        node.GetComponent<baranode>().special = true;
                        node.GetComponent<baranode>().place = "top left";
                        //neighbors.Add(GameObject.Find("Stuart"));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx)  + ", " + (fy - 1)  + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy) + ")")));
                        

                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Top right
                        node.GetComponent<baranode>().place = "top right";
                        node.GetComponent<baranode>().special = true;
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        //Only Top
                        node.GetComponent<baranode>().place = "only top";
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy + 1) + ")")));
                    }
                }

                if (fy == GridSizeY - GridSizeY)
                {
                    //Bottom
                    if (fx == GridSizeX - GridSizeX)
                    {
                        //Bottom left
                        node.GetComponent<baranode>().place = "bottom left";
                        node.GetComponent<baranode>().special = true;
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));

                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Bottom right
                        node.GetComponent<baranode>().place = "bottom right";
                        node.GetComponent<baranode>().special = true;
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));

                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        //Only bottom
                        node.GetComponent<baranode>().place = "only bottom";
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy) + ")")));

                    }
                }

                if (fx == GridSizeX - 1)
                {
                    //right
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {
                        node.GetComponent<baranode>().place = "right";
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx -  1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx ) + ", " + (fy - 1) + ")")));
                    }
                }

                if (fx == GridSizeX - GridSizeX)
                {
                    //left
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {
                        node.GetComponent<baranode>().place = "left";
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy - 1) + ")")));
                        neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy - 1) + ")")));

                    }
                }

                if (node.GetComponent<baranode>().place != "normal")
                {
                    node.GetComponent<SpriteRenderer>().color = Color.red;
                    neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy) + ")")));

                    neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy - 1) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy - 1) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy - 1) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx - 1) + ", " + (fy + 1) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx) + ", " + (fy + 1) + ")")));
                    neighbors.Add(GameObject.Find(("Cell (" + (fx + 1) + ", " + (fy + 1) + ")")));
                }
                node.GetComponent<baranode>().neighbors = neighbors;
                Vector2Int position = new Vector2Int(fx, fy);
                backgroundszar.Add(position, node);
                backgroundszar2.Add(node, position);

                backgroundszar[new Vector2(fx, fy)] = node;
                backgroundszar2[node] = new Vector2(fx, fy);



            }


        }
    }
    public GameObject Getileatpostition(Vector2 pos)
    {
        if (backgroundszar.TryGetValue(pos, out var point))
        {
            return point;
        }
        return null;
    }
}

