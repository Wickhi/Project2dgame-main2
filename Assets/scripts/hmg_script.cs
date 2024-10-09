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
    public GameObject Stuart;
    public bool jobbra;
    public bool balra;
    public int building;

    // Start is called before the first frame update
    void Start()
    {
        állás = rb.rotation;
        cam = Camera.main;



    }

    // Update is called once per frame
    void Update()
    {
        Stuart = GameObject.Find("Stuart");

        //   állás = rb.rotation;
        jobbra = Stuart.GetComponent<building_script>().jobbra;
        balra = Stuart.GetComponent<building_script>().balra;
        building = Stuart.GetComponent<building_script>().whattobuild;

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        //   if (állás < -fordulás)
        // {
        //   állás = állás + 360;
        //}
        if (building == 3)
        {
            if (jobbra == true)
            {
                transform.Rotate(0, 0, -0.5f);
                állás = rb.rotation;

            }
            if (balra == true)
            {
                transform.Rotate(0, 0, 0.5f);
                állás = rb.rotation;
            }
        }
        Vector2 lookDir = mousepos - rb.position;

        //  float angle = Mathf.Abs( Mathf.Atan2(lookDir.y, lookDir.x)) * Mathf.Rad2Deg - 90f;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //  angle = Mathf.Clamp(angle, állás - fordulás, állás + fordulás);

        mouse = new Vector3(0f, 0f, angle);

        Quaternion rotation = Quaternion.Euler(mouse);


        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);





    }
}
