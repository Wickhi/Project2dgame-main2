using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet1Prefab;
    public GameObject bullet2Prefab;
    public int mag = 30;
    public float bulletForce = 20f;
    public float reloadTime = 1f;
    public int One = 1;
    private bool isreloading = false;
    public bool burstmode = false;
    public int firemode = 1;
    public float cooldown = 1;
    public bool iscooldown;
    public float cooldownTimer;
    public AudioClip lövés;
    public AudioSource audiscr;
    public bool egérlent;
    public double autofire;
    public double firerate = 0.1;
    public Transform Casingpoint;
    public GameObject bulletcasing;
    public float Casingforce;
    public float bursttime = 0.2f;
    public float casingpoint;
    public float casingstart;
    public Vector3 valami;
    public float spreadangle;
    public Quaternion casingrot;
    public Vector3 szar;
    public Transform player;
    //  public Quaternion degrees;
    //public Quaternion degrees2;
    public int NumberOfProjectiles = 20;
    public int bulletcount;
    public Slider slider;
    public float reloadtime = 4f;
    public float reloadtimebase = 4f;
    public int magazinebase;



    void Start()
    {
        magazinebase = mag;
    }



    // Update is called once per frame
    void Update()
    {
        Casingforce = Random.Range(300, 1000);
        casingstart = Random.Range(-0.25f, 0.25f);
        valami = new Vector3(casingstart, casingstart, 0);
        


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
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
        }
        if (autofire < 0)
        {
            autofire = 0;
        }
        if (autofire > 0)
        {
            autofire -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            firemode = firemode + 1;
        }
        if (firemode == 5)
        {
            firemode = firemode - 4;
        }
        if (firemode == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                Casing();

            }
        }
        if (firemode == 2)
        {
            if (Input.GetButtonDown("Fire1") && cooldownTimer == 0)
            {

                StartCoroutine(Burst());
               
                cooldownTimer = cooldown;

            }
        }
        if (firemode == 3)
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

        if (firemode == 4)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Buckshot());
                Casing();

                //  mag = mag - 1;

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
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(player.rotation.eulerAngles.z + spreadangle, player.rotation.eulerAngles.z - spreadangle)));
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
        rb_casing.AddForce((Casingpoint.up + valami) * Casingforce, ForceMode2D.Force);
        szar = Casingpoint.up;
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
        reloadtime = 4f;
    }
    IEnumerator varakoztatas()
    {
        yield return new WaitForSeconds(60);

    }
    
}
