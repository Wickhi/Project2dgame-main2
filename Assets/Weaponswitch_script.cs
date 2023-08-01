using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponswitch_script : MonoBehaviour
{
    public int numberofweapons;
    public int currentweapon = 0;
    public GameObject[] weapons;
    public GameObject activeweapon;
    public Transform weaponpoint;


    // Start is called before the first frame update
    void Start()
    {
        numberofweapons = weapons.Length -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentweapon > numberofweapons)
        {
            currentweapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentweapon += 1;
            weaponswitch();
        }
 
    }

    void weaponswitch()
    {
        Destroy(activeweapon);
        activeweapon = Instantiate(weapons[currentweapon], weaponpoint.position, weaponpoint.rotation, weaponpoint);
    }
}
