using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretcontrol : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    public float change = 20f;
    public Vector3 mouse;
    public Transform hull;
    public Transform turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousepos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
        turret.position = hull.position;
    }
}
