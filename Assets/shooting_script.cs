using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class shooting_script : MonoBehaviour
{
    public int firemode = 1;
    public float cooldown = 1;
    public bool iscooldown;
    public float cooldownTimer;
    public AudioClip lövés;
    public AudioSource audiscr;
    public double autofire;
    public Transform Casingpoint;
    public Vector3 valami;
    public float spreadangle;
    //  public Quaternion degrees;
    //public Quaternion degrees2;
    public Slider slider;
    public weapon active;
    public float Casingforce;
    public float casingstart;
    public weapon[] weapons;
    weapon Scar_H = new weapon();
    weapon Vector = new weapon();

    public int currentWeaponIndex;


    void Start()
    {


        Scar_H.Name = "Scar-H";
        Scar_H.Ammotype = "7.62*51";
        Scar_H.magazinebase = 20;
        Scar_H.damage = 40;
        Scar_H.firerate = 0.1f;


        Vector.Name = "Vector";
        Vector.Ammotype = "12.7*99mm";
        Vector.magazinebase = 100;
        Vector.damage = 20;
        Vector.firerate = 0.05f;

        weapons = new weapon[] { Vector, Scar_H};

        //   active.name = weapons[1].name;

    }



    // Update is called once per frame
    void Update()
    {

        active = weapons[currentWeaponIndex];

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWeapon(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SwitchWeapon(2);
        // Add more conditions for additional weapons if needed

        // Call the Fire method of the active weapon
        if (Input.GetKeyDown(KeyCode.Space))
            active.Shoot();


        if (active.isreloading == true)
        {
            active.reloadtime = active.reloadtime - Time.deltaTime;
            active.reloadtimebase = active.reloadtimebase + Time.deltaTime;

        }
        if (active.mag <= 0)
        {
            StartCoroutine(active.reload());

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
                active.Shoot();
                active.Casing();

            }
        }
        if (firemode == 2)
        {
            if (Input.GetButtonDown("Fire1") && cooldownTimer == 0)
            {

                StartCoroutine(active.Burst());
               
                cooldownTimer = cooldown;

            }
        }
        if (firemode == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                active.egérlent = true;
                // Debug.Log("faszom");

            }
            if (Input.GetMouseButtonUp(0))
            {
                active.egérlent = false;
                //   Debug.Log("az egészbe");

            }
            if (active.egérlent == true && autofire == 0)
            {
                active.Shoot();
                active.Casing();
                autofire = active.firerate;

            }
        }

        if (firemode == 4)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(active.Buckshot());
                active.Casing();

                //  mag = mag - 1;

            }
        }




    }

    void SwitchWeapon(int currentweaponindex)
    {
        if (currentWeaponIndex >= 0 && currentWeaponIndex < 3)
        {
            // Assign the selected weapon as the active weapon
            active = weapons[currentWeaponIndex];

            // Log the current weapon's statistics
            Debug.Log("Current Weapon: " + active.Name);
            Debug.Log("Damage: " + active.damage);
            Debug.Log("Fire Rate: " + active.firerate);
            Debug.Log("Reload Time: " + active.reloadTime);
        }
    }


}






