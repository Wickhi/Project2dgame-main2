using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    //  public float angle1; 
    //  public float angle2;
    //  public float baseangle;
    public float change = 20f;
    //   public float angle3 = 1f;
    //   public float angle4;
    //  public float nul = 0f;
    //  public int faszom;
    //   public Transform target;
    public Vector3 mouse;
    //public Transform Stuart;
    //   public bool mozgas;
    // public GameObject fal;
    public float stamina = 10f;
    public float maxstamina;
    public bool shiftle = false;
    public float basemovespeed;
    public float staminause;
    public float staminaregen;
    public float sprintgrade;
    public Transform Stuart;
    public bool forcemethod;
    public bool előre;
    public bool hátra;
    public Transform forcepoint;
    public bool jobbra;
    public bool balra;
    public Quaternion rotation;
    private float revSpeed = 2.0f;
    public Vector2 mousepos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x);


        mouse = new Vector3(0f, 0f, angle * Mathf.Rad2Deg - 90f);
        rotation = Quaternion.Euler(mouse);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousepos2 = mousepos;


        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

    }
    void FixedUpdate()
    {



        // rb.MoveRotation(rb.rotation + revSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);

    }
}