using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building_script : MonoBehaviour

{



    //Variables
    public int falszam = 3;
    public int bustszam = 1;
    public float cooldown = 0.5f;

    //Gameobjects
    public Transform buildingspot;
    public Transform player;
    public GameObject playerman;
    public Camera cam;

    public GameObject bust;
    public GameObject bustPrefab;
    public GameObject Hmg;
    public GameObject hmgPrefab;
    public GameObject fal;
    public GameObject fallPrefab;
    public GameObject fal2;

    //Workvariables
    public bool bpressed = false;
    public bool balra = false;
    public bool jobbra = false;
    public int whattobuild = 1;
    public bool mozoghat = true;
    public bool buildingtime = false;
    public bool hmgdeployed = false;
    public bool usinghmg = false;
    Vector2 mousepos;
    Vector3 mouseposition;
    public bool bustbuild = false;
    public bool buildin = false;
    public bool Canbuild = true;
    public float cooldownbase = 0.5f;
    public string falname = "fal";
    public bool selected;
    public bool deployed;
    public bool firebuttonpressed;
   






    // B.U.S.T. Bestday Utility Sentry Turret
    // Start is called before the first frame update
    void Start()
    {
        //Hmg = GameObject.Find("M3(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = player.position.z;
        // Hmg = GameObject.Find("M3(Clone)");



        //Rotate the object
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






        //Enter Building Mode
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
                selected = false;
                buildingtime = false;
            }
        }

        if (Canbuild == false)
        {
            cooldownbase -= Time.deltaTime;
            if (cooldownbase < 0)
            {
                cooldownbase = cooldown;
                Canbuild = true;
            }
        }




        //Building Type Selector
        if (buildingtime == true)
        {


            //Wallbuilding
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                whattobuild = 1;

            }


            //Bustbuilding
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                whattobuild = 2;

            }

            //Hmgbuilding
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                whattobuild = 3;

            }





            if (whattobuild == 1)
            {

                
                if (selected == true)
                {
                    fal.transform.position = mouseposition;
                    if (jobbra == true)
                    {
                        fal.transform.Rotate(0, 0, -0.5f);

                    }
                    if (balra == true)
                    {
                        fal.transform.Rotate(0, 0, 0.5f);
                    }
                    if (Input.GetButtonDown("Fire1"))
                    {
                        selected = false;

                    }
                }
            }
            if (falszam > 0)
            {
                if (Canbuild == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        fal1();
                        firebuttonpressed = true;
                    }
                }
            }

            if (whattobuild == 2)
            {
                if (bustszam > 0)
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
                        if (usinghmg == false)
                        {
                            Destroy(Hmg);
                            hmgdeployed = false;
                        }
                        
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
        fal.GetComponent<hitdetection>().playername = gameObject.name;
        falszam -= 1;
        fal.name = falname + " " + falszam.ToString();
        selected = true;


        //  buildin = false;
        //  mozoghat = false;



    }
    void bust1()
    {
        Vector3 busthely = cam.ScreenToWorldPoint(Input.mousePosition);
        busthely.z = player.rotation.z;
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
    