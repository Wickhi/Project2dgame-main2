using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sebesség;
    public float sebesség2;
    public bool előre;
    public bool hátra;
    public Transform force1;
    public Transform force2;
    public Vector3 irány;
    //Vector2 mousepos;
    //public Camera cam;
    //public Vector3 mouse;
    public float fordulás;
    public bool bal;
    public bool jobb;
    public float change = 20f;
    public float fordulásfok = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //   irány = force1.up + force2.up;
        //   mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        //   Vector2 lookDir = mousepos - rb.position;

        //     float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        // mouse = new Vector3(0f, 0f, angle);

        //  force1.rotation = Quaternion.Euler(mouse);
        //   force2.rotation = Quaternion.Euler(mouse);
        //   transform.rotation = force1.rotation
        if (Input.GetKeyDown(KeyCode.A))
        {
             bal = true;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            bal = false;

        }

        if (bal == true)
        {
            fordulás = fordulás + fordulásfok;
            Quaternion rotation = Quaternion.Euler(new Vector3 (0,0,fordulás));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            jobb = true;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            jobb = false;
        }
        if (jobb == true)
        {
            fordulás = fordulás - fordulásfok;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, fordulás));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

        }
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
            rb.AddForce(force1.up * sebesség);
            rb.AddForce(force2.up * sebesség2);



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
            rb.AddForce(-force1.up * sebesség);
            rb.AddForce(-force2.up * sebesség2);

        }

    }
}
