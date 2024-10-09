using UnityEngine;

public class grenadethrow_script : MonoBehaviour
{

    public int throwforce = 5;
    public Rigidbody2D rb;
    public GameObject GranataPrefab;
    Vector2 granatapont;
    public Transform granataindul;
    public Camera cam;
    bool granata = false;
    // Update is called once per frame
    void Update()
    {
        granatapont = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            Throw();

        }

        void Throw()
        {

            GameObject granata = Instantiate(GranataPrefab, granataindul.position, granataindul.rotation);
            Rigidbody2D rb = granata.GetComponent<Rigidbody2D>();
            rb.AddForce(granataindul.up * throwforce, ForceMode2D.Force);
        }
    }


}