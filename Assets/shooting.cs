using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.Audio;
using UnityEngine;

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



    void Start()
    {
        mag = 30;
    }



    // Update is called once per frame
    void Update()
    {

        if (isreloading)
        {
            return;
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
        if (firemode == 4)
        {
            firemode = firemode - 3;
        }
        if (firemode == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                mag = mag - 1;
            }
        }
        if (firemode == 2)
        {
            if (Input.GetButtonDown("Fire1") && cooldownTimer == 0)
            {

                StartCoroutine(Burst());
                mag = mag - 3;
                cooldownTimer = cooldown;

            }
        }
        if (firemode == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                egérlent = true;
                Debug.Log("faszom");

            }
            if (Input.GetMouseButtonUp(0))
            {
                egérlent = false;
                Debug.Log("az egészbe");

            }
            if (egérlent == true && autofire == 0)
            {
                Shoot();
                autofire = firerate;

            }



        }
        
    }
    IEnumerator Burst()
    {
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        yield return new WaitForSeconds(0.2f);
    }


    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        audiscr.PlayOneShot(lövés);
    }
    IEnumerator reload()
    {
        isreloading = true;
        Debug.Log("reloading..");
        yield return new WaitForSeconds(4f);
        mag = 30;
        isreloading = false;
    }
    IEnumerator varakoztatas()
    {
        yield return new WaitForSeconds(1f);

    }
    
}
