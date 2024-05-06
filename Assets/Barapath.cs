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
    //public GameObject Up;
    //public GameObject Down;
    //public GameObject Right;
    //public GameObject Left;
    //public GameObject Upleft;
    //public GameObject Upright;
    //public GameObject Downleft;
    //public GameObject Downright;
    public Sprite sprite;
//Ez a szar kell a neighbornek, mert a faszért nem mûködik, majd át kell írni
    public Dictionary<Vector2Int, GameObject> nodeplace;
    public Dictionary<GameObject, Vector2Int> objecttovector;
    public Dictionary<GameObject, GameObject> neighbourdata;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> neighbors;
    public Vector3 worldPoint;
    public int Yoffset;
    public int Xoffset;
    public Vector2Int position;
    public string HitObjectName;
    public GameObject Fasz;
    // https://pavcreations.com/tilemap-based-a-star-algorithm-implementation-in-unity-game/
    // https://pavcreations.com/pathfinding-with-a-star-algorithm-in-unity-small-game-project/
    // Start is called before the first frame update
    void Start()
    {
        nodeplace = new Dictionary<Vector2Int, GameObject>();
        objecttovector = new Dictionary<GameObject, Vector2Int>();
        CreateGrid();
        Navmeshgenerationphase1();
        GenerateNavMesh();
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            //CastRay();

        //}
    }
    void CreateGrid()
    {
        grid = new baranode[GridSizeX, GridSizeY];
        Vector3 gridOffset = transform.position - new Vector3(GridSizeX * CellSize / 2f, GridSizeY * CellSize / 2f, 0f);

        for (int x = 0; x < GridSizeX; x++)
        {
            for (int y = 0; y < GridSizeY; y++)
            {
                position = new Vector2Int(x, y);
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
                var collider = cellObject.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(1,1);
                spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 10f);
                grid[x, y] = cellObject.AddComponent<baranode>();
                grid[x, y].position = position;
                grid[x, y].walkable = isWalkable;
                //nodeplace.Add(position, cellObject);
                //objecttovector.Add(cellObject, position);

            }
        }
    }
    void Navmeshgenerationphase1()
    {
        for (int gx = 0; gx < GridSizeX; gx++)
        {
            for (int gy = 0; gy < GridSizeY; gy++)
            {
                nodeplace.Add(new Vector2Int(gx, gy), GameObject.Find(("Cell (" + gx + ", " + gy + ")")));
                objecttovector.Add(GameObject.Find(("Cell (" + gx + ", " + gy + ")")), new Vector2Int(gx, gy));
            }
        }
    }
    void GenerateNavMesh()
    {


        //change doctopnary vector 2 to vector 2int and change  neigbor to dictionary base one



        for (int fx = 0; fx < GridSizeX; fx++)
        {
            for (int fy = 0; fy < GridSizeY; fy++)
            {
                neighbors.Clear();

                position = new Vector2Int(fx, fy);

                node = nodeplace[position];
                //nodeplace[new Vector2Int(fx, fy)] = node;

                //Debug.Log(node.name);
                node.GetComponent<baranode>().place = "normal";
                //Debug.Log("Node= " + node.name);
                //Vector2Int position = new Vector2Int(fx, fy);


                objecttovector[node] = new Vector2Int(fx, fy);
                if (fy == GridSizeY - 1)
                {
                    //Top
                    if (fx == GridSizeX - GridSizeX)
                    {
                        //Top left
                        node.GetComponent<baranode>().special = true;
                        node.GetComponent<baranode>().place = "top left";
                        //neighbors.Add(GameObject.Find("Stuart"));
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y-1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x+1, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x + 1 , position.y)]);
                        

                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Top right
                        node.GetComponent<baranode>().place = "top right";
                        node.GetComponent<baranode>().special = true;
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x-1, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x -1 , position.y)]);
                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        //Only Top
                        node.GetComponent<baranode>().place = "only top";
                        neighbors.Add(nodeplace[new Vector2Int(position.x -1 , position.y)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x-1, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x+1, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y)]);
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
                        neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y )]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x + 1 , position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);

                    }
                    if (fx == GridSizeX - 1)
                    {
                        //Bottom right
                        node.GetComponent<baranode>().place = "bottom right";
                        node.GetComponent<baranode>().special = true;
                        neighbors.Add(nodeplace[new Vector2Int(position.x +-1, position.y)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);

                    }
                    if (node.GetComponent<baranode>().special == false)
                    {
                        //Only bottom
                        node.GetComponent<baranode>().place = "only bottom";
                        neighbors.Add(nodeplace[new Vector2Int(position.x-1, position.y)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x +1, position.y)]);

                    }
                }

                if (fx == GridSizeX - 1)
                {
                    //right
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {
                        node.GetComponent<baranode>().place = "right";
                        neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x -1 , position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y - 1)]);
                    }
                }

                if (fx == GridSizeX - GridSizeX)
                {
                    //left
                    if (fy > GridSizeY - GridSizeY && fy < GridSizeY - 1)
                    {
                        node.GetComponent<baranode>().place = "left";
                        neighbors.Add(nodeplace[new Vector2Int(position.x +1, position.y)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x+1, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x +1, position.y - 1)]);
                        neighbors.Add(nodeplace[new Vector2Int(position.x, position.y - 1)]);

                    }
                }

                if (node.GetComponent<baranode>().place != "normal")
                {
                    node.GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (node.GetComponent<baranode>().place == "normal")
                {
                    neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y)]);

                    neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y - 1)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x, position.y - 1)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y - 1)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x - 1, position.y + 1)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x, position.y + 1)]);
                    neighbors.Add(nodeplace[new Vector2Int(position.x + 1, position.y + 1)]);

                }
                //node.GetComponent<baranode>().neighbors3 = neighbors;
                foreach(GameObject I in neighbors)
                {
                //Debug.Log(I.name);
                Fasz = I;
                //Debug.Log(I.name);
                //node.GetComponent<baranode>().neighbors3.Add(Fasz);
                node.GetComponent<baranode>().Faszanyad = Fasz;
                //Debug.Log(I.name);
                }





            }


        }
    }
    public GameObject Getileatpostition(Vector2Int pos)
    {
        if (nodeplace.TryGetValue(pos, out var point))
        {
            return point;
        }
        return null;
    }
    
    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        HitObjectName = hit.collider.gameObject.name;
        Debug.Log(HitObjectName);

    }
}


