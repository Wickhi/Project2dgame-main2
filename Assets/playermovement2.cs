using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    public float majom;
    public float majom2 = 0f;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousepos - rb.position;
        float angle = majom;


        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        rb.rotation = angle;
        rb.MoveRotation(rb.rotation + 1 * Time.fixedDeltaTime);


    }

}

