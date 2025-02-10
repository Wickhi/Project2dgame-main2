using Unity.Netcode;
using UnityEngine;

public class playermovement_orgia_script : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    public float change = 20f;
    public Vector3 mouse;
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
    public float aimdownsightsmodifier;
    public bool aimingdownsights;
    public bool boolean;
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
            if (!audi.isPlaying)
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
        if (movement.y != 0 || movement.x != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if(aimingdownsights == true)
        {
            moveSpeed = moveSpeed / aimdownsightsmodifier;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);


    }


}


