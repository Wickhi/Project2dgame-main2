using UnityEngine;

public class tankcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sebesség;
    public float sebesség2;
    public bool előre;
    public bool hátra;
    public Transform force1;
    public Transform force2;
    public Vector3 irány;
    public float fordulás;
    public bool bal;
    public bool jobb;
    public float change = 20f;
    public float fordulásfok = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            bal = true;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            bal = false;

        }

        if (bal == true)
        {
            fordulás = fordulás + fordulásfok;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, fordulás));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            jobb = true;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            jobb = false;
        }
        if (jobb == true)
        {
            fordulás = fordulás - fordulásfok;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, fordulás));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            előre = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            előre = false;
        }
        if (előre == true)
        {
            rb.AddForce(force1.up * sebesség);
            rb.AddForce(force2.up * sebesség2);



        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            hátra = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            hátra = false;
        }
        if (hátra == true)
        {
            rb.AddForce(-force1.up * sebesség);
            rb.AddForce(-force2.up * sebesség2);

        }

    }
}
