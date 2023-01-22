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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            előre = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            előre = false;
        }
        if (előre == true)
        {
            rb.AddForce(transform.up * moveSpeed * Time.deltaTime);



        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            hátra = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            hátra = false;
        }
        if (hátra == true)
        {
            rb.AddForce(-transform.up * moveSpeed * Time.deltaTime);


        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            balra = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            balra = false;
        }
        if (balra == true)
        {
            rb.AddForce(-transform.right * moveSpeed * Time.deltaTime);


        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            jobbra = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            jobbra = false;
        }
        if (jobbra == true)
        {
            rb.AddForce(transform.right * moveSpeed * Time.deltaTime);


        }
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
    }
  
    
}
