﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject George;
    public GameObject John;
    public int playervalue = 1;

    // Start is called before the first frame update
    void Start()
    {
        Stuart = GameObject.Find("Stuart");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Stuart.transform.position.x, Stuart.transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playervalue = playervalue + 1;
        }
        if (playervalue > 3)
        {
            playervalue = 1;
        }
        if (playervalue == 1)
        {
        //    transform.position = new Vector3(Stuart.position.x, Stuart.position.y, transform.position.z);
            Stuart = GameObject.Find("Stuart");



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
        //baseangle < angle4 && angle4 >= 90;
        //angle3 = angle4 - baseangle;
        //angle3 = angle3 - change;
        /////////////b/aseangle = baseangle - change;
    }
}
