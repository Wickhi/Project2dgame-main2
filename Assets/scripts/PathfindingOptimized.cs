using System.Collections.Generic;
using UnityEngine;

public class PathfindingOptimized : MonoBehaviour
{

    //https://github.com/pixelfac/2D-Astar-Pathfinding-in-Unity
    //https://www.reddit.com/r/Unity2D/comments/19exwop/help_with_pathfinding_in_simple_unity_beginner/
    //variables
    // 1 unity unit = 100 pixels
    public Collider2D collidee;
    [Header("Grid Settings")]

    [SerializeField] public int gridWidth = 10;
    [SerializeField] public int gridHeight = 10;
    [SerializeField] public int cellWidth = 1;
    [SerializeField] public int cellHeight = 1;
    public float CellSize = 1;
    public float sizeofcollider;
    public int Gcostmodifier;


    [Header("Pathfinding Function")]
    public int GcostToNeighbour;
    public bool reset;
    public bool visualizegrid;
    public bool DisableGrid;
    public bool doupdategrid;
    public bool getwalls;
    public int numberOfWalls;


    [Header("Miscellanious")]

    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public LayerMask layrm;
    public Vector2 Endpoint;
    public Vector2 Startpoint;

    [Header("Lists")]
    public List<Vector2> cellsToSearch;
    public List<Vector2> searchedCells;
    public List<Vector2> finalPath;
    public List<Vector2> finalfinalPath;
    public List<Vector2> finalfinalfinalPath;
    public List<Vector2> Objectfinalpos;
    public List<Vector2> Walls;
    public List<Vector2> TilesToAvoid;



    public Dictionary<Vector2, Cell2> cells;
    public Dictionary<Cell2, GameObject> objectCell;
    public Dictionary<GameObject, Cell2> objectCell2;
    public Dictionary<Cell2, cell3> celltocell;
    public Dictionary<Vector2, GameObject> cells2;

    public void Start()
    {
        GenerateGrid();
        cellsToSearch = new List<Vector2>();
        searchedCells = new List<Vector2>();
        finalPath = new List<Vector2>();

    }
    public void Update()
    {
        if (getwalls == true)
        {
            GenerateWalls2();
            //GenerateWalls3();

            getwalls = false;
        }
        if (DisableGrid == true)
        {
            Visualizegrid();
            DisableGrid = false;
        }
        if (doupdategrid == true)
        {
            updategrid();
            doupdategrid = false;
        }
    }


    public void FindPath(Vector2 startPos, Vector2 endPos)
    {
        cellsToSearch.Clear();
        cellsToSearch.Add(startPos);
        searchedCells.Clear();
        finalPath.Clear();






        cells[startPos].gCost = 0;
        cells[startPos].hCost = GetDistance(startPos, endPos);
        cells[startPos].fCost = GetDistance(startPos, endPos);

        while (cellsToSearch.Count > 0)
        {
            Vector2 cellToSearch = cellsToSearch[0];

            foreach (Vector2 pos in cellsToSearch)
            {
                Cell2 c = cells[pos];
                if (c.fCost < cells[cellToSearch].fCost || c.fCost == cells[cellToSearch].fCost && c.hCost == cells[cellToSearch].hCost)
                {
                    cellToSearch = pos;
                }
            }
            cellsToSearch.Remove(cellToSearch);
            searchedCells.Add(cellToSearch);

            if (cellToSearch == endPos)
            {
                Cell2 pathCell = cells[endPos];

                while (pathCell.position != startPos)
                {
                    finalPath.Add(pathCell.position);
                    pathCell = cells[pathCell.connection];
                }

                finalPath.Add(startPos);
                //VisualiseText();
                return;
            }

            SearchCellNeighbors(cellToSearch, endPos);
        }

        if (finalPath.Count == 0)
        {
            Debug.Log("Path not found");
        }

    }

    public void SearchCellNeighbors(Vector2 cellPos, Vector2 endPos)
    {
        for (float x = cellPos.x - cellWidth; x <= cellWidth + cellPos.x; x += cellWidth)
        {
            //Debug.Log("1");

            for (float y = cellPos.y - cellHeight; y <= cellHeight + cellPos.y; y += cellHeight)
            {
                //Debug.Log("2");
                Vector2 neighborPos = new Vector2(x, y);
                //Debug.Log("3");
                if (cells.TryGetValue(neighborPos, out Cell2 c) && !searchedCells.Contains(neighborPos) && !cells[neighborPos].isWall)
                {
                    //Debug.Log("4");

                    GcostToNeighbour = cells[cellPos].gCost + GetDistance(cellPos, neighborPos);
                    if (c.tiletoavoid == true)
                    {
                        GcostToNeighbour = GcostToNeighbour + Gcostmodifier;
                    }
                    //Debug.Log("5");
                    if (GcostToNeighbour < cells[neighborPos].gCost)
                    {
                        //Debug.Log("6");
                        Cell2 neighbourNode = cells[neighborPos];

                        neighbourNode.connection = cellPos;
                        neighbourNode.gCost = GcostToNeighbour;
                        neighbourNode.hCost = GetDistance(neighborPos, endPos);
                        neighbourNode.fCost = neighbourNode.gCost + neighbourNode.hCost;

                        if (!cellsToSearch.Contains(neighborPos))
                        {
                            //Debug.Log("7");
                            cellsToSearch.Add(neighborPos);
                        }
                    }
                }
            }
        }
    }
    public void GenerateGrid()
    {
        cells = new Dictionary<Vector2, Cell2>();
        cells2 = new Dictionary<Vector2, GameObject>();
        objectCell = new Dictionary<Cell2, GameObject>();
        celltocell = new Dictionary<Cell2, cell3>();
        objectCell2 = new Dictionary<GameObject, Cell2>();
        Vector3 gridOffset = transform.position - new Vector3(gridHeight * CellSize / 2f, gridWidth * CellSize / 2f, 0f);
        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {
                GameObject cellObject = new GameObject("Cell (" + x + ", " + y + ")");
                cellObject.transform.SetParent(transform);
                cellObject.tag = "navmeshnode";
                cellObject.layer = 10;
                cellObject.AddComponent<SpriteRenderer>();
                //cellObject.AddComponent<Cell2>();
                var collider = cellObject.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(sizeofcollider, sizeofcollider);
                collider.isTrigger = true;
                //collider.includeLayers = layrm;

                spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 10f);
                Vector2 pos = new Vector2(x, y);
                cellObject.AddComponent<cell3>();
                cells.Add(pos, new Cell2(pos));
                cells2.Add(pos, cellObject);
                objectCell.Add(cells[pos], cellObject);
                objectCell2.Add(cellObject, cells[pos]);
                celltocell.Add(cells[pos], cellObject.GetComponent<cell3>());
                if (collidee.IsTouching(collider) == true)
                {
                    Debug.Log("fasz");
                    cells[pos].isWall = true;
                    spriteRenderer.color = Color.black;
                    Walls.Add(pos);
                }

            }

        }

    }
    public void GenerateWalls()
    {
        for (int i = 0; i < numberOfWalls; i++)
        {
            Vector2 pos = new Vector2(Random.Range(0, gridWidth), Random.Range(0, gridHeight));
            cells[pos].isWall = true;
            //objectCell[cells[pos]].GetComponent<SpriteRenderer>().color = Color.black;
            Walls.Add(pos);

        }
    }
    public void GenerateWalls2()
    {
        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {


                Vector2 pos = new Vector2(x, y);

                GameObject celle = cells2[pos];
                Collider2D collider = celle.GetComponent<BoxCollider2D>();
                spriteRenderer = celle.GetComponent<SpriteRenderer>();
                RaycastHit2D hit = Physics2D.Raycast(celle.transform.position, celle.transform.position, Mathf.Infinity, layrm);

                if (collider.IsTouching(collidee))
                {
                    cells[pos].tiletoavoid = true;
                    TilesToAvoid.Add(pos);
                    spriteRenderer.color = Color.blue;
                }
                if (hit.collider == collidee)
                {
                    cells[pos].isWall = true;
                    spriteRenderer.color = Color.black;
                    Walls.Add(pos);
                }
            }

        }

    }
    public void GenerateWalls3()
    {
        //foreach (Vector2 c in Walls)
        //{
        //Vector2 pos = new Vector2(cells[c].position.x - 1, cells[c].position.y - 1);
        //for (int x = 0; x < 3; x++)
        //{
        //for (int y = 0; y < 3; y++)
        //{
        //Vector2 pos2 = new Vector2(pos.x + x, pos.y + y);
        //if (cells.TryGetValue(pos2, out Cell2 B))
        //{
        //B.tiletoavoid = true;
        //TilesToAvoid.Add(pos2);
        //cells2[pos2].GetComponent<SpriteRenderer>().color = Color.cyan;
        //}

        //}

        //}
        //}
        for (int x = 0; x < gridWidth; x += cellWidth)
        {
            for (int y = 0; y < gridHeight; y += cellHeight)
            {


            }
        }

    }
    //Get grid visualized

    public int GetDistance(Vector2 pos1, Vector2 pos2)
    {
        Vector2Int dist = new Vector2Int(Mathf.Abs((int)pos1.x - (int)pos2.x), Mathf.Abs((int)pos1.y - (int)pos2.y));
        int lowest = Mathf.Min(dist.x, dist.y);
        int highest = Mathf.Max(dist.x, dist.y);
        int horizontalMovesRequired = highest - lowest;
        return lowest * 14 + horizontalMovesRequired * 10;
    }
    public void clearhistory()
    {
        //Walls.Clear();
        finalPath.Clear();
        cellsToSearch.Clear();
        searchedCells.Clear();
        //finalPath = null;
        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {
                Vector2 pos = new Vector2(x, y);
                Cell2 c = cells[pos];
                c.position = pos;
                c.connection = new Vector2(0, 0);
                c.gCost = int.MaxValue;
                c.hCost = int.MaxValue;
                c.fCost = int.MaxValue;
                //c.tiletoavoid = false;
                //c.isWall = false;
                reset = false;
                GcostToNeighbour = 0;
            }

        }
    }
    public void updategrid()
    {

        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {
                Vector2 pos = new Vector2(x, y);
                Cell2 c = cells[pos];
                celltocell[c].gCost = c.gCost;
                celltocell[c].hCost = c.hCost;
                celltocell[c].fCost = c.fCost;
                celltocell[c].isWall = c.isWall;
                celltocell[c].connection = c.connection;
                celltocell[c].position = c.position;
                celltocell[c].tiletoavoid = c.tiletoavoid;
            }

        }
    }
    public void Visualizegrid()
    {
        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {
                Vector2 pos = new Vector2(x, y);
                Cell2 c = cells[pos];
                SpriteRenderer spr = objectCell[c].GetComponent<SpriteRenderer>();
                if (visualizegrid == true)
                {
                    spr.enabled = true;

                }
                if (visualizegrid == false)
                {
                    spr.enabled = false;

                }
            }

        }
    }
    public void Pathfindingalgorith(Vector2 sp, Vector2 ep)
    {
        FindPath(sp, ep);
        finalfinalPath = finalPath;
        finalfinalPath.Reverse();
        foreach (Vector2 c in finalfinalPath)
        {
            Objectfinalpos.Add(cells2[c].transform.position);
            finalfinalfinalPath.Add(c);
        }
        clearhistory();
    }
}


//Cell for calculation
