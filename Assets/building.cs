using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
   
{
    public GameObject fallPrefab;
    public Transform buildingspot;
    public bool buildin = false;
    public int falszam = 2;
    public int bustszam = 10000000;
    public GameObject bustPrefab;
    public bool bustbuild = false;
    // B.U.S.T. Bestday Utility Sentry Turret
    // Start is called before the first frame update
    void Start()
    {
        falszam = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            buildin = true;

        }
        if (buildin == true && falszam > 0)
        {
            build();
            falszam = falszam - 1;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            bustbuild = true;

        }
        if (bustbuild == true && bustszam > 0)
        {
            bustbuilding();
            bustszam = bustszam - 1;
        }

    }
    void build()
    {
        GameObject fall = Instantiate(fallPrefab, buildingspot.position, buildingspot.rotation);
        buildin = false;
    }
    void bustbuilding()
    {
        GameObject fall = Instantiate(bustPrefab, buildingspot.position, buildingspot.rotation);
        bustbuild = false;
    }

}