using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drobe : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movedir;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movedir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        rb.velocity = movedir * speed;
    }
}
