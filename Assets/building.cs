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
    Vector2 mousepos;
    Vector3 szarpos;
    public Camera cam;
    public Transform player;
    public bool mozoghat = true;
    public int whattobuild = 0;
    public bool buildingtime = false;
    public bool bpressed = false;
    public GameObject fal;
    public bool balra = false;
    public bool jobbra = false;
    public GameObject bust;
    public GameObject Hmg;
    public GameObject hmgPrefab;
    public bool hmgdeployed = false;
    public bool usinghmg = false;

    // B.U.S.T. Bestday Utility Sentry Turret
    // Start is called before the first frame update
    void Start()
    {
        falszam = 100;
        if (Input.GetKeyDown(KeyCode.Z))
        {

            buildin = true;

        }
        if (buildin == true && falszam > 0)
        {
            fal1();
            falszam = falszam - 1;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            bustbuild = true;

        }
        if (bustbuild == true && bustszam > 0)
        {
            bust1();
            bustszam = bustszam - 1;
        }
        Hmg = GameObject.Find("M3Hmg");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {

            balra = true;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            jobbra = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            balra = false;

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            jobbra = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!bpressed)
            {
                bpressed = true;
                mozoghat = false;
                buildingtime = true;
            }
            else
            {
                bpressed = false;
                mozoghat = true;
                buildingtime = false;
            }
        }

        if (buildingtime == true)
        {

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                whattobuild = 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                whattobuild = 2;

            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                whattobuild = 3;

            }
            if (whattobuild == 1)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    fal1();
                }
                if (jobbra == true)
                {
                    fal.transform.Rotate(0, 0, -1);

                }
                if (balra == true)
                {
                    fal.transform.Rotate(0, 0, 1);
                }
            }
            if (whattobuild == 2)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    bust1();

                }
                if (jobbra == true)
                {
                    bust.transform.Rotate(0, 0, -1);

                }
                if (balra == true)
                {
                    bust.transform.Rotate(0, 0, 1);
                }
            }
            if (whattobuild == 3)
            {
                
   
                if (Input.GetButtonDown("Fire1"))
                {
                    if (!hmgdeployed)
                    {
                        mgbuild();
                        hmgdeployed = true;
                    }
                    else
                    {
                        Destroy(Hmg);
                        hmgdeployed = false;
                    }
                }

                    

                
                if (jobbra == true)
                {
                    Hmg.transform.Rotate(0, 0, -0.5f);

                }
                if (balra == true)
                {
                    Hmg.transform.Rotate(0, 0, 0.5f);
                }
            }
            if(hmgdeployed == true)
            {
                usinghmg = Hmg.GetComponent<collidee>().usinghmg;


            }
        }

    }
    void fal1()
    {
        Vector3 busthely = cam.ScreenToWorldPoint(Input.mousePosition);
        busthely.z = player.position.z;
        fal = Instantiate(fallPrefab, busthely, Quaternion.Euler(new Vector3(0, 0, 0)));
        //  buildin = false;
        //  mozoghat = false;



    }
    void bust1()
    {
        Vector3 busthely = cam.ScreenToWorldPoint(Input.mousePosition);
        busthely.z = player.position.z;
        bust = Instantiate(bustPrefab, busthely, Quaternion.Euler(new Vector3(0, 0, 0)));
        //  bustbuild = false;
        // mozoghat = false;
    }
    void mgbuild()
    {
        Vector3 busthely = cam.ScreenToWorldPoint(Input.mousePosition);
        busthely.z = player.position.z;
        Hmg = Instantiate(hmgPrefab, busthely, Quaternion.Euler(new Vector3(0, 0, 0)));
        //  bustbuild = false;
        // mozoghat = false;
    }
    void buildtime()
    {
        mozoghat = false;
        buildingtime = true;

    }
}
    