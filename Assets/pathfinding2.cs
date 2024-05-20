using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathfindingOptimized : MonoBehaviour
{


    //variables
    [SerializeField] private int gridWidth = 10;
    [SerializeField] private int gridHeight = 10;
    [SerializeField] private int cellWidth = 1;
    [SerializeField] private int cellHeight = 1;
    public int CellSize = 1;
    public int numberOfWalls;
    [SerializeField] private bool newPath;
    public bool Generatenewpath;
    //[SerializeField] private bool visualiseGrid;
    [SerializeField] private bool showTexts;

    [SerializeField] private Transform textPrefab;
    [SerializeField] private Transform textParent;

    [SerializeField]  private Dictionary<Vector2, Cell2> cells;
    
    [SerializeField] public Dictionary<Cell2, GameObject> objectCell;
    [SerializeField] public Dictionary<GameObject, Cell2> objectCell2;
    private Dictionary<Vector2, GameObject> cells2;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public List<Vector2> cellsToSearch;
    public List<Vector2> searchedCells;
    public List<Vector2> finalPath;
    public List<Vector2> Walls;
    [SerializeField] public int x;
    [SerializeField] public int y;
    public bool pathGenerated;
    public bool generated;
    public int GcostToNeighbour;
    public bool reset;
    private void Start()
    {
        GenerateGrid();

    }
    private void Update()
    {
        //FindPath(new Vector2(0, 0), new Vector2(x, y));
        if (newPath && !pathGenerated)
        {

            FindPath(new Vector2(0, 0), new Vector2(x, y));

            GenerateWalls();
            if (reset == true)
            {
                pathGenerated = false;
                Walls = null;
                finalPath = null;
                cellsToSearch = null;
                searchedCells = null;
                finalPath = null;
            }
            //FindPath(new Vector2(0, 0), new Vector2(x, y));

            //foreach (Vector2 c in finalPath)
            //{
            //objectCell[cells[c]].GetComponent<SpriteRenderer>().color = Color.magenta;
            //}


            pathGenerated = true;
        }
        else if (!newPath)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                for (float x = 0; x < gridWidth; x += cellWidth)
                {
                    for (float y = 0; y < gridHeight; y += cellHeight)
                    {
                        Vector2 pos = new Vector2(x, y);
                        Destroy(cells2[pos]);


                    }

                }
            }

        }
        if (pathGenerated == true)
        {
            if (showTexts)
            {
                //Debug.Log("kurva");
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


    private void FindPath(Vector2 startPos, Vector2 endPos)
    {
        
        cellsToSearch = new List<Vector2> { startPos };
        searchedCells = new List<Vector2>();
        finalPath = new List<Vector2>();

        
 

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

    //private void VisualiseText()
    //{
        //foreach (Transform child in textParent)
        //{
            //Destroy(child.gameObject);
        //}

        //foreach (Vector2 pos in cells.Keys)
        //{
            //Transform text = Instantiate(textPrefab, pos + (Vector2)transform.position, new Quaternion(), textParent);
            //text.GetChild(0).GetComponent<Text>().text = cells[pos].gCost.ToString();
            //text.GetChild(1).GetComponent<Text>().text = cells[pos].hCost.ToString();
            //text.GetChild(2).GetComponent<Text>().text = cells[pos].fCost.ToString();
        //}
    //}

    private void SearchCellNeighbors(Vector2 cellPos, Vector2 endPos)
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
    void GenerateGrid()
    {
        cells = new Dictionary<Vector2, Cell2>();
        cells2 = new Dictionary<Vector2, GameObject>();
        objectCell = new Dictionary<Cell2, GameObject>();
        objectCell2 = new Dictionary<GameObject, Cell2>();
        Vector3 gridOffset = transform.position - new Vector3(gridHeight * CellSize / 2f, gridWidth * CellSize / 2f, 0f);
        for (float x = 0; x < gridWidth; x += cellWidth)
        {
            for (float y = 0; y < gridHeight; y += cellHeight)
            {
                GameObject cellObject = new GameObject("Cell (" + x + ", " + y + ")");
                cellObject.transform.SetParent(transform);
                cellObject.AddComponent<SpriteRenderer>();
                var collider = cellObject.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(1, 1);
                spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 10f);
                Vector2 pos = new Vector2(x, y);
                cells.Add(pos, new Cell2(pos));
                cells2.Add(pos, cellObject);
                objectCell.Add(new Cell2(pos), cellObject);
                objectCell2.Add(cellObject, new Cell2(pos));


            }

        }
        
    }
    void GenerateWalls()
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
    private void VisualizeGrid()
    {
        //if (!visualiseGrid || cells == null)
        //{
            //return;
            
        //}

        //foreach (KeyValuePair<Vector2, Cell2> kvp in cells)
        //{
            //if (!kvp.Value.isWall)
           // if (Walls.Contains(kvp.Key))
            //{
                //Debug.Log("kurva");
                //objectCell[cells[kvp.Key]].GetComponent<SpriteRenderer>().color = Color.black;
            }
            //else
            //{
                //Debug.Log("kurva");
                //objectCell[cells[kvp.Key]].GetComponent<SpriteRenderer>().color = Color.white;
            //}

            //if (finalPath.Contains(kvp.Key))
            //{
                //Debug.Log("kurva");
               // objectCell[cells[kvp.Key]].GetComponent<SpriteRenderer>().color = Color.magenta;
            //}

            //float gizmoSize = showTexts ? 0.2f : 1;

            //Gizmos.DrawCube(kvp.Key + (Vector2)transform.position, new Vector3(cellWidth, cellHeight) * gizmoSize);
        //}
    //}

    public int GetDistance(Vector2 pos1, Vector2 pos2)
    {
        Vector2Int dist = new Vector2Int(Mathf.Abs((int)pos1.x - (int)pos2.x), Mathf.Abs((int)pos1.y - (int)pos2.y));
        int lowest = Mathf.Min(dist.x, dist.y);
        int highest = Mathf.Max(dist.x, dist.y);
        int horizontalMovesRequired = highest - lowest;
        return lowest * 14 + horizontalMovesRequired * 10;
    }
}


//Cell for calculation
