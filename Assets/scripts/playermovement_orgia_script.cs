using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class playermovement_orgia_script : NetworkBehaviour
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
    public bool moving;
    public AudioSource audi;
    // Update is called once per frame

    private void Start()
    {
        //  stamina = maxstamina;
        


    }
    void Update()
    {

        if (!IsOwner) return;

        moveSpeed = Mathf.Round(moveSpeed * 2) / 2;
        moveSpeed = basemovespeed;


        if (stamina < 0f)
        {
            moveSpeed = basemovespeed / 2;
            moveSpeed = Mathf.Round(moveSpeed * 2) / 2;
        }

        if (shiftle == true && stamina > 0f)
        {
            stamina -= Time.deltaTime * staminause;
            if (stamina > 0f)
            {
                moveSpeed = basemovespeed * sprintgrade;
                moveSpeed = Mathf.Round(moveSpeed * 2) / 2;
            }
        }
        if (shiftle == false)
        {
            if (stamina < maxstamina)
            {
                stamina += Time.deltaTime * staminaregen;

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftle = true;
            moving = true;




        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftle = false;
            moving = false;

            moveSpeed = basemovespeed;
            moveSpeed = Mathf.Round(moveSpeed * 2) / 2;


        }
        if (moving == false)
        {
            if(!audi.isPlaying)
            {
                audi.Play();
            }
            else
            {
                audi.Stop();

            }
        }
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        if (forcemethod == false)
        {
            sima();
        }
        if (forcemethod == true)
        {


            forcemethod1();

        }













        //  mozgas = fal.GetComponent<szar>().mozgás;
        //    if (mozgas == true)
        //   { 
        //  movement.x = Input.GetAxisRaw("Horizontal");
        //  movement.y = Input.GetAxisRaw("Vertical");
        //   }   
        //  mousepos = cam.ScreenToWorldPoint(Input.mousePosition);




        //    transform.position = new Vector2(Mathf.Round(transform.position.x * 100) / 100, Mathf.Round(transform.position.y * 100) / 100);

        //   angle4 = angle;

        // Mathf.Round((angle * 100) / 100);

        //  Debug.Log(Stuart.rotation.z);
        //     if (angle < 0)
        //    {
        //       angle4 = angle + 360;
        //   }

        // if(baseangle < 90 && angle4 > 270)
        //{
        //   angle3 = angle3 - change;
        // }
        //if (baseangle < angle4)
        //{
        //   baseangle = baseangle + change;
        //  faszom = 1;
        //}
        //if ((baseangle > angle4) || (angle4 > 270 && baseangle < 90))
        // {
        //    if (angle4 > 270 && baseangle < 90)
        //  {
        //      angle4 -= 360;
        //     baseangle = baseangle - change;
        //       faszom = 2;
        //  }
        // else
        //{

        //    baseangle = baseangle - change;
        //   faszom = 2;
        //}
        //  Mathf.Round(Stuart.rotation.z);




    }

    // rb.rotation = Quaternion.RotateTowards(transform.rotation, lookdir, change * Time.deltaTime);
    void forcemethod1()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            előre = true;
            moving = true;

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            előre = false;
            moving = false;

        }
        if (előre == true)
        {
            rb.AddForce(transform.up * moveSpeed);



        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            hátra = true;
            moving = true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            hátra = false;
            moving = false;
        }
        if (hátra == true)
        {
            rb.AddForce(-transform.up * moveSpeed);


        }
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
    }
    void sima()

    {
        movement.x = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        movement.y = Mathf.Round(Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);


    }


}


