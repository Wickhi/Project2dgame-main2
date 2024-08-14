using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class zombie : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Collider stuart;
    public Collider2D coll;
    public Collider2D coll2;
    public Collider2D collsaved;
    public Collider2D coll2saved;

    public Camera cam;
    public GameObject campart;
    public Vector2 startpoint;
    public Vector2 targetpoint;
    public List<Vector2> path;
    public List<Vector2> path2;

    public PathfindingOptimized pt;
    public bool newPath;
    public int moveSpeed;
    public bool pathGenerated;
    public bool reset;
    public bool a;
    public bool b;
    public Vector3 pospos;
    public Rigidbody2D Player;
    public bool activepathfinding;
    public bool adjustment;
    public float change;
    public ContactFilter2D contactfilter;
    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        

        
        

      


    }
    private void FixedUpdate()
    {
        collsaved = coll;
        coll2saved = coll2;
        RaycastHit2D hit = Physics2D.Raycast(Rb.position, Rb.position, Mathf.Infinity, layermask);
        RaycastHit2D hit2 = Physics2D.Raycast(Player.position, Player.position, Mathf.Infinity, layermask);
        coll = hit.collider;
        coll2 = hit2.collider;
        if (activepathfinding == true)
        {
            if (coll != null)
            {
                if (coll2 != coll2saved)
                {
                    path.Clear();
                    path2.Clear();
                    Rb.position = pt.cells2[startpoint].transform.position;
                    startpoint = pt.objectCell2[coll.gameObject].position;
                    targetpoint = pt.objectCell2[coll2.gameObject].position;
                    pt.Pathfindingalgorith(startpoint, targetpoint);
                    path = pt.Objectfinalpos;
                    path2 = pt.finalfinalfinalPath;
                    adjustment = true;
                    
                }
            }
        }
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
            Vector3 lookDir = new Vector3(path[0].x, path[0].y, 0) - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            var mouse = new Vector3(0f, 0f, angle);
            Quaternion rotation = Quaternion.Euler(mouse);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
            lookDir.Normalize();
            movementek(lookDir);

            if (coll.gameObject == pt.cells2[path2[0]])
            {
                path.RemoveAt(0);
                path2.RemoveAt(0);
            }
        }
    }
    void CastRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            coll = hit.collider;
            pt.FindPath(startpoint, targetpoint);
            path = pt.finalPath;
        //path.Reverse();
            Rb.position = path[0];
            foreach (Vector2 c in path)
            {
                gameObject.transform.position = pt.cells2[c].transform.position;
                Debug.Log("fos");
            }
            pt.clearhistory();
            reset = false;
            newPath = true;
            pathGenerated = false;
            path.Clear();
    }
        
    void movementek(Vector2 lookDir)
    {
        Rb.MovePosition((Vector2)transform.position + (lookDir * moveSpeed * Time.deltaTime));

    }
    IEnumerator Move()
    {
        foreach (Vector2 c in path)
        {
            Rb.position = c;
            yield return new WaitForSeconds(0.4f);
            
        }
        path.Clear();
    }



    
}
