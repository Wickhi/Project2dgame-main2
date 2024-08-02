using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasz : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet1Prefab;
    public GameObject bullet2Prefab;
    public int mag;
    public float bulletForce = 20f;
    public float reloadTime;
    public bool isreloading = false;
    public bool burstmode = false;
    public double firerate;
    public int magazinebase;
    public int damage;
    public int NumberOfProjectiles = 20;
    public int bulletcount = 1;
    public float bursttime = 0.2f;
    public Quaternion casingrot;
    public Vector3 szar;
    public Transform player;
    public AudioClip lövés;
    public AudioSource audiscr;
    public float casingpoint;
    public float reloadtime = 4f;
    public float reloadtimebase = 4f;
    public Vector3 casingvalami;
    public float spreadangle;
    public float Casingforce;
    public float casingstart;
    public bool egérlent;
    public Transform Casingpoint;
    public string Name;
    public string Ammotype;
    public GameObject bulletcasing;


    public bool automatic;



    public IEnumerator Burst()
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
    public IEnumerator Buckshot()
    {
        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            Shoot();
            yield return new WaitForSeconds(0.001f);
            // mag = mag - 1;

        }
    }

    public void Shoot()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(player.rotation.eulerAngles.z + spreadangle, player.rotation.eulerAngles.z - spreadangle)));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        audiscr.PlayOneShot(lövés);
        Rigidbody2D rb_ammo = bullet.GetComponent<Rigidbody2D>();
        rb_ammo.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        bulletcount = bulletcount + 1;
        mag = mag - 1;


    }
    public void Casing()
    {
        GameObject ammocasing = Instantiate(bulletcasing, Casingpoint.position, Casingpoint.rotation);
        Rigidbody2D rb_casing = ammocasing.GetComponent<Rigidbody2D>();
        rb_casing.AddForce((Casingpoint.up + casingvalami) * Casingforce, ForceMode2D.Force);
        szar = Casingpoint.up;
    }
    public IEnumerator reload()
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
    public IEnumerator varakoztatas()
    {
        yield return new WaitForSeconds(60);

    }
}
