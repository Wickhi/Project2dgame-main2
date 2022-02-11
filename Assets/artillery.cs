using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artillery : MonoBehaviour
{
    Vector2 mousepos;
    Vector3 szarpos;
    public Camera cam;
    public Transform nem;
    public GameObject szar;
    public Transform player;
    public Transform szarrot;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.J))
        {
            Vector3 arty = cam.ScreenToWorldPoint(Input.mousePosition);
            arty.z = player.position.z ;
            GameObject szar2 = Instantiate(szar, arty, Quaternion.Euler(new Vector3(0, 0, 0)));



        }
      
        
    }
}
