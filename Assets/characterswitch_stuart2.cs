using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterswitch_stuart2 : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject cam;
    public int playerszam;
   // public GameObject fal;
    public bool mozoghat = false;
    public bool usinghmg = false;
    
    // ||

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerszam = cam.GetComponent<follow>().playervalue;
        mozoghat = Stuart.GetComponent<building>().mozoghat;
        usinghmg = Stuart.GetComponent<collidee>().usinghmg;


        //   mozoghat = fal.GetComponent<szar>().mozgás;
        //    && mozoghat == true
        if (playerszam == 1 && mozoghat == true && usinghmg == false)
        {
            Stuart.GetComponent<playermovement>().enabled = true;
            Stuart.GetComponent<shooting>().enabled = true;
            Stuart.GetComponent<building>().enabled = true;
            Stuart.GetComponent<grenadethrow>().enabled = true;
            Stuart.GetComponent<grab>().enabled = true;

        }
        else
        {
            Stuart.GetComponent<playermovement>().enabled = false;
            Stuart.GetComponent<shooting>().enabled = false;
           // Stuart.GetComponent<building>().enabled = false;
            Stuart.GetComponent<grenadethrow>().enabled = false;
            Stuart.GetComponent<grab>().enabled = false;
        }
    }
}
