﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterswitch_stuart2_script : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject cam;
    public string Hmgname;
    public string playername;
    public string camname;
    public int playerszam;
   // public GameObject fal;
    public bool mozoghat = false;
    public bool usinghmg = false;
   // public GameObject hmg;
    // ||

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hmg = GameObject.Find(Hmgname);
        Stuart = GameObject.Find(playername);
        cam = GameObject.Find(camname);

        playerszam = cam.GetComponent<follow_script>().playervalue;
        mozoghat = Stuart.GetComponent<building_script>().mozoghat;
        //usinghmg = hmg.GetComponent<collidee>().usinghmg;


        //   mozoghat = fal.GetComponent<szar>().mozgás;
        //    && mozoghat == true
        if (mozoghat == true)
        {

            Stuart.GetComponent<playermovement_orgia_script>().enabled = true;
            Stuart.GetComponent<shooting_script>().enabled = true;
            Stuart.GetComponent<building_script>().enabled = true;
            Stuart.GetComponent<grenadethrow_script>().enabled = true;
            Stuart.GetComponent<car>().enabled = true;

        }
        else
        {
            Stuart.GetComponent<playermovement_orgia_script>().enabled = false;
            Stuart.GetComponent<shooting_script>().enabled = false;
           // Stuart.GetComponent<building>().enabled = false;
            Stuart.GetComponent<grenadethrow_script>().enabled = false;
            Stuart.GetComponent<car>().enabled = false;
        }


    }
}