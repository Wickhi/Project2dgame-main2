using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

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
        var mouse = new Vector3(0f, 0f, speed);
        Quaternion rotation = Quaternion.Euler(mouse *  5);
        transform.rotation = transform.rotation * rotation;

    }
}
