using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hmg : MonoBehaviour
{
    Vector2 mousepos;
    public Camera cam;
    public Rigidbody2D rb;
    public float change = 20f;
    public Vector3 mouse;
    public float állás;
    public float fordulás;
    // Start is called before the first frame update
    void Start()
    {
        állás = rb.rotation;

    }

    // Update is called once per frame
    void Update()
    {
    //    állás = rb.rotation;

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        //   if (állás < -fordulás)
        // {
        //   állás = állás + 360;
        //}
        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        angle = Mathf.Clamp(angle, állás - fordulás, állás + fordulás);

        mouse = new Vector3(0f, 0f, angle);

        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);





    }
}
