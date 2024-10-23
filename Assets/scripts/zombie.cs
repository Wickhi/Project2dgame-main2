using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zombie : MonoBehaviour
{

    public bool activepathfinding;

    public Rigidbody2D Rb;
    public Transform playerpoint;
    public float attacktimebase;
    public float attacktime;
    public float attackdistance;
    public float stopmovementdistance;

    public int attackdamage;
    public float RetargetTimeBase;

    public float navmeshrefreshbase;

    public int moveSpeed;
    public float change;

    public PathfindingOptimized pt;
    public GameObject player;
    public AudioSource src;
    public AudioClip attacksound;
    public Collider2D coll;
    public Collider2D coll2;
    public Collider2D collsaved;
    public Collider2D coll2saved;
    public Collider2D heararea;
    public Collider2D attackarea;


    public Vector2 startpoint;
    public Vector2 targetpoint;
    public List<Vector2> path;
    public List<Vector2> path2;

    public bool pathGenerated;
    public bool adjustment;
    public bool attackable = true;

    public LayerMask layermask;

    public LayerMask layermask2;

    public bool canexecute;


    public List<Vector2> cellsToSearch;
    public List<Vector2> searchedCells;
    public List<Vector2> finalPath;
    public List<Vector2> finalfinalPath;
    public List<Vector2> finalfinalfinalPath;
    public List<Vector2> Objectfinalpos;
    public List<Vector2> Walls;
    public List<Vector2> TilesToAvoid;
    public List<GameObject> players;
    public List<float> szamok;

    [Header("Pathfinding Function")]
    public int GcostToNeighbour;
    public bool reset;
    public bool visualizegrid;
    public int Gcostmodifier;
    public bool alwayssee;
    public bool lockviewangle;
    public bool desiredposition;
    public bool retarget = true;
    public Vector3 lookDir;
    public float navmeshrefresh2;



    // Start is called before the first frame update
    void Start()
    {
        canexecute = true;
        navmeshrefreshbase = Random.Range(navmeshrefreshbase - 0.2f, navmeshrefreshbase + 0.2f);
    }

    // Update is called once per frame 
    void Update()
    {
        if (navmeshrefresh2 > 0)
        {
            navmeshrefresh2 -= Time.deltaTime;
        }
        if (navmeshrefresh2 < 0)
        {
            navmeshrefresh2 = 0;
        }
        if (attacktime > 0)
        {
            attacktime -= Time.deltaTime;
        }
        if (attacktime < 0)
        {
            attacktime = 0;
        }






    }
    private void FixedUpdate()
    {
        Determineiftomove(stopmovementdistance);
        if (lockviewangle == true)
        {
            lookDir = new Vector3(player.transform.position.x, player.transform.position.y, 0) - transform.position;

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            var mouse = new Vector3(0f, 0f, angle);
            Quaternion rotation = Quaternion.Euler(mouse);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

        }
        Getroute(player.transform);
        Move();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {

            if (attackable == true)
            {
                attackable = false;
                Debug.Log("attack");
                src.PlayOneShot(attacksound);
                attacktime = attacktimebase;

            }
            if (attacktime == 0)
            {

                attack();

            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("attack over");
            attackable = true;
        }

    }
    void movementek(Vector2 lookDir2)
    {
        Rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * lookDir2));

    }

    public void FindPath(Vector2 startPos, Vector2 endPos)
    {
        cellsToSearch.Clear();
        cellsToSearch.Add(startPos);
        searchedCells.Clear();
        finalPath.Clear();






        pt.cells[startPos].gCost = 0;
        pt.cells[startPos].hCost = GetDistance(startPos, endPos);
        pt.cells[startPos].fCost = GetDistance(startPos, endPos);

        while (cellsToSearch.Count > 0)
        {
            Vector2 cellToSearch = cellsToSearch[0];

            foreach (Vector2 pos in cellsToSearch)
            {
                Cell2 c = pt.cells[pos];
                if (c.fCost < pt.cells[cellToSearch].fCost || c.fCost == pt.cells[cellToSearch].fCost && c.hCost == pt.cells[cellToSearch].hCost)
                {
                    cellToSearch = pos;
                }
            }
            cellsToSearch.Remove(cellToSearch);
            searchedCells.Add(cellToSearch);

            if (cellToSearch == endPos)
            {
                Cell2 pathCell = pt.cells[endPos];

                while (pathCell.position != startPos)
                {
                    finalPath.Add(pathCell.position);
                    pathCell = pt.cells[pathCell.connection];
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
        for (float x = cellPos.x - pt.cellWidth; x <= pt.cellWidth + cellPos.x; x += pt.cellWidth)
        {
            //Debug.Log("1");

            for (float y = cellPos.y - pt.cellHeight; y <= pt.cellHeight + cellPos.y; y += pt.cellHeight)
            {
                //Debug.Log("2");
                Vector2 neighborPos = new Vector2(x, y);
                //Debug.Log("3");
                if (pt.cells.TryGetValue(neighborPos, out Cell2 c) && !searchedCells.Contains(neighborPos) && !pt.cells[neighborPos].isWall)
                {
                    //Debug.Log("4");

                    GcostToNeighbour = pt.cells[cellPos].gCost + GetDistance(cellPos, neighborPos);
                    if (c.tiletoavoid == true)
                    {
                        GcostToNeighbour = GcostToNeighbour + Gcostmodifier;
                    }
                    //Debug.Log("5");
                    if (GcostToNeighbour < pt.cells[neighborPos].gCost)
                    {
                        //Debug.Log("6");
                        Cell2 neighbourNode = pt.cells[neighborPos];

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
    public void Pathfindingalgorith(Vector2 sp, Vector2 ep)
    {
        FindPath(sp, ep);
        finalfinalPath = finalPath;
        finalfinalPath.Reverse();
        foreach (Vector2 c in finalfinalPath)
        {
            Objectfinalpos.Add(pt.cells2[c].transform.position);
            finalfinalfinalPath.Add(c);
        }
        clearhistory();
    }
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
        for (float x = 0; x < pt.gridWidth; x += pt.cellWidth)
        {
            for (float y = 0; y < pt.gridHeight; y += pt.cellHeight)
            {
                Vector2 pos = new Vector2(x, y);
                Cell2 c = pt.cells[pos];
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
    public void getplayer()
    {
        foreach (GameObject c in players)
        {
            int szam = players.IndexOf(c);
            float distance2 = Vector3.Distance(Rb.position, c.transform.position);
            szamok.Add(distance2);


        }
        float distance = szamok.Min();
        int szam2 = szamok.IndexOf(distance);
        player = players[szam2];
        playerpoint = player.transform;
        szamok.Clear();
    }
    void attack()
    {

        RaycastHit2D hit4 = Physics2D.Raycast(player.transform.position, player.transform.position, Mathf.Infinity, layermask2);
        if (hit4.collider != null)
        {
            if (hit4.collider.gameObject == gameObject)
            {
                Debug.Log("attacking");

                player.GetComponent<hp_system>().hp -= attackdamage;
            }
            attackable = true;

        }

    }
    void navmeshrefreshing()
    {

    }
    void Determineiftomove(float Stopmovementdistance)
    {
        if (Vector3.Distance(Rb.position, player.transform.position) < Stopmovementdistance)
        {
            activepathfinding = false;
            path.Clear();
        }
        if (Vector3.Distance(Rb.position, player.transform.position) > Stopmovementdistance)
        {

            activepathfinding = true;
        }
    }

    void Getroute(Transform Target)
    {
        if (navmeshrefresh2 == 0)
        {
            if (retarget == true)
            {
                getplayer();
            }
            collsaved = coll;
            coll2saved = coll2;
            RaycastHit2D hit = Physics2D.Raycast(Rb.position, Rb.position, Mathf.Infinity, layermask);
            RaycastHit2D hit2 = Physics2D.Raycast(Target.position, Target.position, Mathf.Infinity, layermask);
            coll = hit.collider;
            coll2 = hit2.collider;
            canexecute = false;
            if (activepathfinding == true)
            {
                if (coll != null)
                {
                    if (coll2 != coll2saved)
                    {
                        path.Clear();
                        path2.Clear();
                        //Rb.position = pt.cells2[startpoint].transform.position;
                        startpoint = pt.objectCell2[coll.gameObject].position;
                        targetpoint = pt.objectCell2[coll2.gameObject].position;
                        Pathfindingalgorith(startpoint, targetpoint);
                        path = Objectfinalpos;
                        path2 = finalfinalfinalPath;
                        adjustment = true;
                        navmeshrefresh2 = navmeshrefreshbase;
                    }
                }
            }
        }
    }
    void Move()
    {
        if (path.Count != 0)
        { 
            RaycastHit2D hit3 = Physics2D.Raycast(Rb.position, Rb.position, Mathf.Infinity, layermask);
            coll = hit3.collider;
            if (adjustment == true)
            {
                if (path.Count != 1)
                {

                    path.RemoveAt(0);
                    path2.RemoveAt(0);
                    adjustment = false;

                }

            }
            if (Vector3.Distance(Rb.position, player.transform.position) < attackdistance)
            {
                lockviewangle = true;
                //Debug.Log(Vector3.Distance(Rb.position, player.transform.position));
            }
            else
            {
                lockviewangle = false;
                //Debug.Log(Vector3.Distance(Rb.position, player.transform.position));

            }



            lookDir.Normalize();
            movementek(lookDir);


            if (lockviewangle == false)
            {
                lookDir = new Vector3(path[0].x, path[0].y, 0) - transform.position;

                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                var mouse = new Vector3(0f, 0f, angle);
                Quaternion rotation = Quaternion.Euler(mouse);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
            }

            if (coll.gameObject == pt.cells2[path2[0]])
            {
                path.RemoveAt(0);
                path2.RemoveAt(0);
            }
        }
    }
}
