using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    // Start is called before the first frame update
    //https://github.com/pixelfac/2D-Astar-Pathfinding-in-Unity
    //https://www.reddit.com/r/Unity2D/comments/19exwop/help_with_pathfinding_in_simple_unity_beginner/
    //variables
    [SerializeField] public int gridWidth = 10;
    [SerializeField] public int gridHeight = 10;
    [SerializeField] public int cellWidth = 1;
    [SerializeField] public int cellHeight = 1;
    public int CellSize = 1;
    public int numberOfWalls;
    [SerializeField] public bool newPath;
    public bool Generatenewpath;

    [SerializeField] public bool showTexts;

    [SerializeField] public Transform textPrefab;
    [SerializeField] public Transform textParent;

    [SerializeField] public Dictionary<Vector2, Cell2> cells;

    [SerializeField] public Dictionary<Cell2, GameObject> objectCell;
    [SerializeField] public Dictionary<GameObject, Cell2> objectCell2;
    public Dictionary<Cell2, cell3> celltocell;
    public Dictionary<Vector2, GameObject> cells2;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public List<Vector2> cellsToSearch;
    public List<Vector2> searchedCells;
    public List<Vector2> finalPath;
    public List<Vector2> finalfinalPath;
    public List<Vector2> Objectfinalpos;
    public List<Vector2> Walls;
    [SerializeField] public int x;
    [SerializeField] public int y;
    public bool pathGenerated;
    public bool generated;
    public int GcostToNeighbour;
    public bool reset;
    public Vector2 Endpoint;
    public Vector2 Startpoint;
    public PathfindingOptimized pt;
    public List<Vector2> Path;
    public Rigidbody2D Rb;
    public bool a;
    public bool b;
    public void Start()
    {
        GenerateGrid();
        cellsToSearch = new List<Vector2>();
        searchedCells = new List<Vector2>();
        finalPath = new List<Vector2>();

    }
    public void Update()
    {
        if (a == true)
        {
            a = false;
            pt.Pathfindingalgorith(Startpoint, Endpoint);
        }
        if (b == true)
        {
            clearhistory();
            b = false;
        }
        if (newPath && !pathGenerated)
        {

            pt.FindPath(Startpoint, Endpoint);
            Path = pt.finalPath;
            Path.Reverse();
            Rb.position = pt.cells2[Path[0]].transform.position;
            foreach (Vector2 c in Path)
            {
                gameObject.transform.position = pt.cells2[c].transform.position;
                Debug.Log("fos");
            }


            //}



            pathGenerated = true;
            newPath = false;
            reset = true;

        }
        else if (!newPath)
        {
            if (reset == true)
            {
                pt.clearhistory();
                reset = false;
                newPath = true;
                pathGenerated = false;
                Path.Clear();
            }

        }
        //FindPath(new Vector2(0, 0), new Vector2(x, y));
        if (newPath && !pathGenerated)
        {
            GenerateWalls();

            FindPath(Startpoint, Endpoint);




            pathGenerated = true;
        }
        else if (!newPath)
        {
            if (reset == true)
            {
                clearhistory();
            }

        }
        if (pathGenerated == true)
        {
            if (showTexts)
            {
                for (float x = 0; x < gridWidth; x += cellWidth)
                {
                    for (float y = 0; y < gridHeight; y += cellHeight)
                    {
                        Vector2 pos = new Vector2(x, y);
                        cells2[pos].GetComponent<SpriteRenderer>().color = Color.white;


                    }

                }
                foreach (Vector2 c in finalPath)
                {

                    //Debug.Log("kurva");
                    cells2[c].GetComponent<SpriteRenderer>().color = Color.magenta;
                }
                foreach (Vector2 V in Walls)
                {

                    //Debug.Log("kurva");
                    cells2[V].GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
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
        generated = true;

    }

    public void SearchCellNeighbors(Vector2 cellPos, Vector2 endPos)
    {
        for (float x = cellPos.x - cellWidth; x <= cellWidth + cellPos.x; x += cellWidth)
        {
            Debug.Log("1");

            for (float y = cellPos.y - cellHeight; y <= cellHeight + cellPos.y; y += cellHeight)
            {
                Debug.Log("2");
                Vector2 neighborPos = new Vector2(x, y);
                Debug.Log("3");
                if (cells.TryGetValue(neighborPos, out Cell2 c) && !searchedCells.Contains(neighborPos) && !cells[neighborPos].isWall)
                {
                    Debug.Log("4");

                    GcostToNeighbour = cells[cellPos].gCost + GetDistance(cellPos, neighborPos);
                    Debug.Log("5");
                    if (GcostToNeighbour < cells[neighborPos].gCost)
                    {
                        Debug.Log("6");
                        Cell2 neighbourNode = cells[neighborPos];

                        neighbourNode.connection = cellPos;
                        neighbourNode.gCost = GcostToNeighbour;
                        neighbourNode.hCost = GetDistance(neighborPos, endPos);
                        neighbourNode.fCost = neighbourNode.gCost + neighbourNode.hCost;

                        if (!cellsToSearch.Contains(neighborPos))
                        {
                            Debug.Log("7");
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
                cellObject.AddComponent<SpriteRenderer>();
                //cellObject.AddComponent<Cell2>();
                var collider = cellObject.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(1, 1);
                collider.isTrigger = true;
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
        pathGenerated = false;
        Walls = null;
        finalPath = null;
        cellsToSearch = null;
        searchedCells = null;
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
                c.isWall = false;
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
        }
        clearhistory();
    }
}


//Cell for calculation

