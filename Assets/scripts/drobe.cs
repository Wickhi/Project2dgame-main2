using UnityEngine;

public class drobe : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movedir;
    public float speed = 2f;
    public float lifetime;
    public GameObject player;
    public dronedeploy dronedeploy;
    public follow_script follow;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        follow.Stuart = gameObject;
        player.GetComponent<playermovement_orgia_script>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        movedir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;

        }
        if (Input.GetButtonDown("Fire1"))
        {
            lifetime = 0;

        }
        if (lifetime == 0 || lifetime < 0)
        {
            dronedeploy.deployed = false;
            follow.Stuart = player;
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject);
            player.GetComponent<playermovement_orgia_script>().enabled = true;

        }

    }
    private void FixedUpdate()
    {
        rb.velocity = movedir * speed;
        var mouse = new Vector3(0f, 0f, speed);
        Quaternion rotation = Quaternion.Euler(mouse * 5);
        transform.rotation = transform.rotation * rotation;

    }
}
