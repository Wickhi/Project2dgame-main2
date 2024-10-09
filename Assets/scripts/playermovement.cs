using UnityEngine;

public class playermovement : MonoBehaviour
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
    public float sprint = 10f;
    public bool shiftle = false;
    public float basemovespeed;
    // Update is called once per frame

    private void Start()
    {

    }
    void Update()
    {
        moveSpeed = basemovespeed;

        if (sprint < 0f)
        {
            moveSpeed = basemovespeed / 2;

        }

        if (shiftle == true && sprint > 0f)
        {
            sprint -= Time.deltaTime;
            if (sprint > 0f)
            {
                moveSpeed = basemovespeed * 2;

            }
        }
        if (shiftle == false)
        {
            if (sprint < 10f)
            {
                sprint += Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftle = true;



        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftle = false;
            moveSpeed = basemovespeed;


        }

    }

    void FixedUpdate()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");





        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousepos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);




        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);






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



}


