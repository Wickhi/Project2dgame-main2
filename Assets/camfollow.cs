using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    public Transform Stuart;
    public Vector3 mouse;
    public Quaternion rotation;
    public float angle;
    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = mousepos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        mouse = new Vector3(0f, 0f, angle);
        rotation = Quaternion.Euler(mouse);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
