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
    public Collider2D coll;
    public Camera cam;
    public GameObject campart;
    public Vector2 startpoint;
    public Vector2 targetpoint;
    public List<Vector2> path;
    public PathfindingOptimized pt;
    public bool newPath;
    public int moveSpeed;
    public bool pathGenerated;
    public bool reset;
    public bool a;
    public bool b;
    public Vector3 pospos;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (a == true)
        {
            pt.Pathfindingalgorith(startpoint, targetpoint);
            path = pt.Objectfinalpos;
            a = false;

        }
        
        if (b == true)
        {
            StartCoroutine(Move());
            b = false;
        }
    }

    void CastRay()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            coll = hit.collider;
            pt.FindPath(startpoint, targetpoint);
            path = pt.finalPath;
            path.Reverse();
            Rb.position = pt.cells2[path[0]].transform.position;
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
        void gethelp()
        {
            pt.FindPath(startpoint, targetpoint);
        }
        void gethelp2()
        {
            pt.clearhistory();

        }
        void gethelp3()
        {
            pt.updategrid();

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
