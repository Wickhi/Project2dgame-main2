using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterswitch_george : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject cam;
    public int playerszam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerszam = cam.GetComponent<follow>().playervalue;
        if (playerszam == 2)
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
            Stuart.GetComponent<building>().enabled = false;
            Stuart.GetComponent<grenadethrow>().enabled = false;
            Stuart.GetComponent<grab>().enabled = false;
        }
    }
}
