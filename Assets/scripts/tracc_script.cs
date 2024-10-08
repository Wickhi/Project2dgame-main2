using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class tracc : MonoBehaviour
{
    public Transform playerp;
    public GameObject player;
    public Transform irány;
    Vector2 playerpoint;
    public Camera cam;
    public Rigidbody2D rbn;
    public float change;
    public löves lvs;
    public double firerate;
    public LayerMask laymr;
    public bool retarget;
    public List<GameObject> enemys;
    public float firingtime;
    private float firingtimeBase;
    public bool inside;
    public bool canshoot;
    public float roundsperminute;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        rbn = this.GetComponent<Rigidbody2D>();
        firingtime = 60f / roundsperminute;
    }
    void Update()
    {
        if (firingtimeBase > 0)
        {
            firingtimeBase -= Time.deltaTime;
        }
        if (canshoot == true)
        {
            if (firingtimeBase <= 0)
            {
                lvs.Shoot();
                //lvs.Casing();
                firingtimeBase = firingtime;
            }
        }
        if (retarget == true)
        {
            player = enemys[Random.Range(0, enemys.Count)];
        }

    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            playerpoint = player.transform.position;
            playerpoint = cam.ScreenToWorldPoint(playerp.position);
            Vector3 lookDir = playerp.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            var mouse = new Vector3(0f, 0f, angle);
            Quaternion rotation = Quaternion.Euler(mouse);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
            lookDir.Normalize();
            
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(enemys.Contains(collider.gameObject) == false)
        {
            enemys.Add(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Enemybodypart"))
        {
            if (player == null)
            {
                player = collider.gameObject;
                inside = true;

            }
            
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (enemys.Contains(collider.gameObject) == true)
        {
            enemys.Remove(collider.gameObject);
            if(player == collider.gameObject)
            {
                player = null;

            }
        }
        if (enemys.Count == 0)
        {
            inside = false;
        }
    } 
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemybodypart"))
        {
            if (player == null)
            {
                player = collider.gameObject;
                inside = true;

            }
            if (retarget == true)
            {
                player = enemys[Random.Range(0, enemys.Count)];
            }
        }
        




    }
    
}
