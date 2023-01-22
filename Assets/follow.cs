using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject George;
    public GameObject John;
    public int playervalue = 1;
    public GameObject hmg;


    // Start is called before the first frame update
    void Start()
    {
        Stuart = GameObject.Find("Stuart");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Stuart.transform.position.x, Stuart.transform.position.y, transform.position.z);
        hmg = GameObject.Find("M3(Clone)");
        bool usinghmg = hmg.GetComponent<collidee>().usinghmg;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playervalue = playervalue + 1;
        }
        if (playervalue > 4)
        {
            playervalue = 1;
        }
        if (playervalue == 1)
        {
        //    transform.position = new Vector3(Stuart.position.x, Stuart.position.y, transform.position.z);
            if (usinghmg == true)
            {
                Stuart = GameObject.Find("M3(Clone)");
            }
            else
            {
                Stuart = GameObject.Find("Stuart");
            }
            



        }
        if (playervalue == 2)
        {
          //  transform.position = new Vector3(George.position.x, George.position.y, transform.position.z);
            Stuart = GameObject.Find("George");
            

        }
        if (playervalue == 3)
        {
           // transform.position = new Vector3(John.position.x, John.position.y, transform.position.z);
            Stuart = GameObject.Find("John");


        }
        if (playervalue == 4)
        {
            // transform.position = new Vector3(John.position.x, John.position.y, transform.position.z);
            Stuart = GameObject.Find("t72_luka (2)");


        }
        //baseangle < angle4 && angle4 >= 90;
        //angle3 = angle4 - baseangle;
        //angle3 = angle3 - change;
        /////////////b/aseangle = baseangle - change;
    }
}
