using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour
{
    public Vector2Int position;
    public bool walkable;
    public List<GridNode> neighbors;
    public int gCost;
    public int hcost;
    public int fCost;
    public GridNode parent;
    public GridNode(Vector2Int pos, bool isWalkable)
    {
        position = pos;
        walkable = isWalkable;
        neighbors = new List<GridNode>();
    }

    public int CalculateDistanceCost(GridNode targetNode)
    {
        return Mathf.Abs(position.x - targetNode.position.x) + Mathf.Abs(position.y - targetNode.position.y);
    }
}

public class GridNavMesh2 : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public float cellSize;
    public Vector2Int startNodePos;
    public Vector2Int targetNodePos;
    public GameObject player;

    private GridNode[,] grid;

    private void Start()
    {
        CreateGrid();
        GenerateNavMesh();
        List<GridNode> path = FindPath(startNodePos, targetNodePos);
        if (path != null)
        {
            Debug.Log("Path found!");
            foreach (GridNode node in path)
            {
                Debug.Log("Node: " + node.position);
            }
        }
        else
        {
            Debug.Log("No path found!");
        }
    }


    private void CreateGrid()
    {
        grid = new GridNode[gridSizeX, gridSizeY];
        Vector3 gridOffset = transform.position - new Vector3(gridSizeX * cellSize / 2f, gridSizeY * cellSize / 2f, 0f);

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                bool isWalkable = false;
                RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.zero);
                if (hit.collider == null)
                {
                    // No collision, cell is walkable
                    isWalkable = true;
                }
                GameObject cellObject = new GameObject("Cell (" + x + ", " + y + ")");
                cellObject.transform.SetParent(transform);
                cellObject.transform.position = gridOffset + new Vector3(x * cellSize, y * cellSize, 0f);
                grid[x, y] = cellObject.AddComponent<GridNode>();
                grid[x, y].position = position;
                grid[x, y].walkable = isWalkable;
            }
        }
    }


    private void GenerateNavMesh()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GridNode node = grid[x, y];
                if (node.walkable)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int neighborX = x + dx;
                            int neighborY = y + dy;
                            if (neighborX >= 0 && neighborX < gridSizeX && neighborY >= 0 && neighborY < gridSizeY)
                            {
                                GridNode neighbor = grid[neighborX, neighborY];
                                if (neighbor.walkable)
                                {
                                    node.neighbors.Add(neighbor);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private List<GridNode> FindPath(Vector2Int start, Vector2Int target)
    {
        GridNode startNode = grid[start.x, start.y];
        GridNode targetNode = grid[target.x, target.y];

        List<GridNode> openSet = new List<GridNode> { startNode };
        HashSet<GridNode> closedSet = new HashSet<GridNode>();

        while (openSet.Count > 0)
        {
            GridNode currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].CalculateDistanceCost(targetNode) < currentNode.CalculateDistanceCost(targetNode)))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (GridNode neighbor in currentNode.neighbors)
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.gCost + currentNode.CalculateDistanceCost(neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.fCost = neighbor.gCost + neighbor.CalculateDistanceCost(targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        return null; // No path found
    }

    private List<GridNode> RetracePath(GridNode startNode, GridNode endNode)
    {
        List<GridNode> path = new List<GridNode>();
        GridNode currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }
}

