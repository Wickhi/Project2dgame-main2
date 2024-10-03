using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracc : MonoBehaviour
{
    public Transform playerp;
    public Transform irány;
    Vector2 playerpoint;
    public Camera cam;
    public Rigidbody2D rbn;
    public float change;
    public löves lvs;
    public LayerMask laymr;



    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        rbn = this.GetComponent<Rigidbody2D>();

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //transform.rotation = irány.rotation;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerpoint = cam.ScreenToWorldPoint(playerp.position);
            Vector3 lookDir = playerp.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            var mouse = new Vector3(0f, 0f, angle);
            Quaternion rotation = Quaternion.Euler(mouse);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
            lookDir.Normalize();
        }
        




    }
}
