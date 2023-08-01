using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class löves : MonoBehaviour
{
    //FIREMODES
    public bool semiauto;
    public bool fullauto;
    public bool burst;
    public bool buckshot;


    //WEAPON MODES
    public int mag;
    public int magazinebase;
    public float reloadtime;
    public float reloadtimeBase = 4f;

    public double Roundperminute = 600f;
    public float bursttime = 0.2f;
    public float bulletForce = 20f;
    public int NumberOfProjectiles = 20;
    public double semiautofirebase;
    public float Burstcooldown = 1;
    public float spreadangle;
    public AudioClip lövés;
    public AudioSource audiscr;


    //OBJECTS
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet1Prefab;
    public GameObject bullet2Prefab;
    public Transform Casingpoint;
    public GameObject bulletcasing;
    public string playername;
    public GameObject cam;


    //CASING STUFF
    public float Casingforce;
    public float casingpoint;
    public float casingstart;
    public Vector3 casingVariability;
    public Quaternion casingrot;


    //weaponfunction
    public int firemode = 1;
    public int bulletcount;
    private bool isreloading = false;
    public double firerate;
    public bool burstmode = false;
    public float BurstcooldownTimer;
    public bool isBurstcooldown;
    public Slider slider;
    public bool egérlent;
    public double autofire;
    public double semiautofire;
    public bool semiautofirecooldown;
    public int numberoffiremodes = 5;
    public float reloadtimebase;




    // public int One = 1;









    void Start()
    {
        mag = magazinebase;
        firerate = 60 / Roundperminute;
        reloadtime = reloadtimeBase;
        cam = GameObject.Find("Main Camera");
        audiscr = cam.GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        Casingforce = Random.Range(300, 1000);
        casingstart = Random.Range(-0.25f, 0.25f);
        casingVariability = new Vector3(casingstart, casingstart, 0);




        if (isreloading == true)
        {
            reloadtime = reloadtime - Time.deltaTime;
            reloadtimebase = reloadtimebase + Time.deltaTime;

        }
        if (mag <= 0)
        {
            StartCoroutine(reload());

            return;
        }
        if (BurstcooldownTimer > 0)
        {
            BurstcooldownTimer -= Time.deltaTime;
        }
        if (BurstcooldownTimer < 0)
        {
            BurstcooldownTimer = 0;
        }
        if (autofire < 0)
        {
            autofire = 0;
        }
        if (autofire > 0)
        {
            autofire -= Time.deltaTime;
        }
        if (semiautofire < 0)
        {
            semiautofire = 0;
        }
        if (semiautofire > 0)
        {
            semiautofire -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            firemode = firemode + 1;
        }
        if (firemode == numberoffiremodes)
        {
            firemode = firemode - 4;
        }
        if (firemode == 1)
        {
            if (semiauto == true)
            {
                if (semiautofirecooldown == true)
                {

                }
                if (semiautofire == 0)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Shoot();
                        Casing();
                        semiautofire = semiautofirebase;

                    }
                }

            }
            else
            {
                firemode = firemode + 1;
            }
        }
        if (firemode == 2)
        {
            if (burst == true)
            {
                if (Input.GetButtonDown("Fire1") && BurstcooldownTimer == 0)
                {

                    StartCoroutine(Burst());

                    BurstcooldownTimer = Burstcooldown;

                }
            }
            else
            {
                firemode = firemode + 1;
            }
        }
        if (firemode == 3)
        {
            if (fullauto == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    egérlent = true;
                    // Debug.Log("faszom");

                }
                if (Input.GetMouseButtonUp(0))
                {
                    egérlent = false;
                    //   Debug.Log("az egészbe");

                }
                if (egérlent == true && autofire == 0)
                {
                    Shoot();
                    Casing();
                    autofire = firerate;

                }
                
            }
            else
            {
                firemode = firemode + 1; 
            }
        }

        if (firemode == 4)
        {
            if (buckshot == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    StartCoroutine(Buckshot());
                    Casing();

                    //  mag = mag - 1;

                }
            }
            else
            {
                firemode = firemode + 1;
            }
        }




    }
    IEnumerator Burst()
    {
        Shoot();
        Casing();
        yield return new WaitForSeconds(bursttime);
        Shoot();
        Casing();
        yield return new WaitForSeconds(bursttime);
        Shoot();
        Casing();
        yield return new WaitForSeconds(bursttime);
    }
    IEnumerator Buckshot()
    {
        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            Shoot();
            yield return new WaitForSeconds(0.001f);
            // mag = mag - 1;

        }
    }
    void Shoot()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(transform.rotation.eulerAngles.z + spreadangle, transform.rotation.eulerAngles.z - spreadangle)));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        audiscr.PlayOneShot(lövés);
        Rigidbody2D rb_ammo = bullet.GetComponent<Rigidbody2D>();
        rb_ammo.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        bulletcount = bulletcount + 1;
        mag = mag - 1;


    }
    void Casing()
    {
        GameObject ammocasing = Instantiate(bulletcasing, Casingpoint.position, Casingpoint.rotation);
        Rigidbody2D rb_casing = ammocasing.GetComponent<Rigidbody2D>();
        rb_casing.AddForce((Casingpoint.up + casingVariability) * Casingforce, ForceMode2D.Force);
    }
    IEnumerator reload()
    {
        egérlent = false;
        isreloading = true;
        Debug.Log("reloading..");
        yield return new WaitForSeconds(reloadtime);
        mag = magazinebase;
        isreloading = false;
        reloadtimebase = 0f;
        reloadtime = reloadtimeBase;
    }
    IEnumerator varakoztatas()
    {
        yield return new WaitForSeconds(60);

    }

}