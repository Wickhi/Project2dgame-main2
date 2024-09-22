using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronedeploy : MonoBehaviour
{
    public  GameObject Drone;
    public Transform buildingspot;
    public int numberofdrones;
    public bool deployed;
    public follow_script follow;
    // make drone recahrge
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deployed == false)
        {
            if (numberofdrones > 0)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GameObject droe = Instantiate(Drone, buildingspot.position, gameObject.transform.rotation);
                    droe.GetComponent<drobe>().player = gameObject;
                    droe.GetComponent<drobe>().dronedeploy = this;
                    droe.GetComponent<drobe>().follow = follow;

                    deployed = true;
                    numberofdrones--;
                }

            }
        }
    }
}
