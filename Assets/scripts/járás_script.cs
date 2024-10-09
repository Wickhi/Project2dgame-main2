using UnityEngine;

public class járás : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rbn;
    Vector2 playerpoint;
    public Transform playerp;
    public Camera cam;
    Vector2 movement;
    // Update is called once per frame
    void start()
    {
        rbn = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerpoint = cam.ScreenToWorldPoint(playerp.position);
    }
    private void FixedUpdate()
    {
        Vector3 lookDir = playerp.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbn.rotation = angle;
        lookDir.Normalize();
        movementek(lookDir);


    }
    void movementek(Vector2 lookDir)
    {
        rbn.MovePosition((Vector2)transform.position + (lookDir * moveSpeed * Time.deltaTime));
    }
}
