using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using JetBrains.Annotations;

public class löves : NetworkBehaviour
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
    public GameObject trailPrefab;
    public GameObject bulletPrefab;
    public GameObject bullet1Prefab;
    public GameObject bullet2Prefab;
    public Transform Casingpoint;
    public GameObject bulletcasing;
    public string playername;
    public GameObject cam;
    public GameObject magazin;
    public GameObject blood;



    //CASING STUFF
    public float Casingforce;
    public float casingpoint;
    public float casingstart;
    public Vector3 casingVariability;
    public Quaternion casingrot;

    //MAG STUFF
    public float Magforce;
    public float Magpoint;
    public float Magstart;
    public Vector3 MagVariability;
    public Quaternion Magrot;
    public int fullammobase;
    public int fullammo;
    public int reserveammo;

    //WEAPONFUNCION
    public int firemode = 1;
    public bool fire;
    public int bulletcount;
    public bool isreloading = false;
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
    public bool canfire;
    public LayerMask layrm;



    // public int One = 1;









    void Start()
    {
        mag = magazinebase;
        fullammo = fullammobase;
        reserveammo = fullammo - mag;
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

        Magforce = Random.Range(-300, 300);
        Magstart = Random.Range(-0.25f, 0.25f);
        MagVariability = new Vector3(Magstart, Magstart, 0);




        if (isreloading == true)
        {
            reloadtime = reloadtime - Time.deltaTime;
            reloadtimebase = reloadtimebase + Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.R) && isreloading == false)
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
        if (Input.GetKeyDown(KeyCode.V))
        {
            firemode = firemode + 1;
        }
        if (firemode == numberoffiremodes)
        {
            firemode = firemode - 4;
        }








        if (isreloading == false && mag > 0)
        {
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
                            canfire = true;
                            

                        }
                        if (canfire == true)
                        {
                            Shoot();
                            Casing();
                            semiautofire = semiautofirebase;
                            canfire = false;
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
                        Debug.Log("az egészbe");

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
                        canfire = true;

                        //  mag = mag - 1;

                    }
                    if (canfire == true)
                    {
                        canfire = false;
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

        audiscr.PlayOneShot(lövés);
        var rand = Random.Range(-spreadangle / 2, spreadangle / 2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis(rand, Vector3.forward) * transform.up, Mathf.Infinity, layrm);
        GameObject bullet = Instantiate(trailPrefab, firePoint.transform.position, Quaternion.Euler(Quaternion.AngleAxis(rand, Vector3.forward) * firePoint.transform.up));
        bullet.GetComponent<buuletra>().settargerpos(hit.point);
        //Debug.DrawRay(transform.position, Vector2.Distance(transform.position, hit.point) *  (Quaternion.AngleAxis(rand, Vector3.forward) * transform.up),  Color.yellow, 0.2f);
        // (Quaternion.AngleAxis(rand, Vector3.forward) * transform.up)
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Enemybodypart") == true)
            {
                GameObject bloody = Instantiate(blood, hit.point, hit.collider.gameObject.transform.rotation);

            }

            //Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
        }
        bulletcount = bulletcount + 1;
        mag--;
        fullammo--;
        reserveammo = fullammo - mag;


    }
    void OldShoot()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(transform.rotation.eulerAngles.z + spreadangle, transform.rotation.eulerAngles.z - spreadangle)));
        GameObject bullet = Instantiate(trailPrefab, firePoint.position, rotation);
        bullet.GetComponent<NetworkObject>().Spawn(true);

        audiscr.PlayOneShot(lövés);
        Rigidbody2D rb_ammo = bullet.GetComponent<Rigidbody2D>();
        rb_ammo.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        bulletcount = bulletcount + 1;
        mag--;
        fullammobase--;
        reserveammo = fullammo - mag;



    }
    void Casing()
    {
        GameObject ammocasing = Instantiate(bulletcasing, Casingpoint.position, Casingpoint.rotation);
        ammocasing.GetComponent<NetworkObject>().Spawn(true);
        Rigidbody2D rb_casing = ammocasing.GetComponent<Rigidbody2D>();
        rb_casing.AddForce((Casingpoint.up + casingVariability) * Casingforce, ForceMode2D.Force);
    }
    void firing()
    {

        fire = false;

    }
    IEnumerator reload()
    {
        egérlent = false;
        isreloading = true;
        Debug.Log("reloading..");
        GameObject magazine = Instantiate(magazin, Casingpoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        magazine.GetComponent<NetworkObject>().Spawn(true);

        Rigidbody2D rb_magazine = magazine.GetComponent<Rigidbody2D>();
        rb_magazine.AddForce((Casingpoint.up + MagVariability) * Magforce, ForceMode2D.Force);
        yield return new WaitForSeconds(reloadtime);
        if(fullammo > magazinebase)
        {
            mag = magazinebase;
            reserveammo = fullammo - mag;
        }
        if (magazinebase > fullammo || magazinebase == fullammo)
        {
            mag = fullammo;
        }
        reserveammo = fullammo - mag;


        isreloading = false;
        reloadtimebase = 0f;
        reloadtime = reloadtimeBase;
        
    }
    IEnumerator varakoztatas()
    {
        yield return new WaitForSeconds(60);

    }

}