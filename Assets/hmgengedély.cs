﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hmgengedély : MonoBehaviour
{
    public GameObject Hmg;
    public bool usinghmg = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usinghmg = Hmg.GetComponent<collidee>().usinghmg;
        if (usinghmg == false)
        {
            Hmg.GetComponent<hmg>().enabled = false;
            Hmg.GetComponent<shooting>().enabled = false;

        }
        if (usinghmg == true)
        {
            Hmg.GetComponent<hmg>().enabled = true;
            Hmg.GetComponent<shooting>().enabled = true;

        }




    }
}
