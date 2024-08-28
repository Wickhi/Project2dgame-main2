using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Weaponswitch_script : NetworkBehaviour
{
    public int numberofweapons;
    public int currentweapon = 0;
    public GameObject[] weapons;
    public GameObject activeweapon;
    public Transform weaponpoint;


    // Start is called before the first frame update
    void Start()
    {
        numberofweapons = weapons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
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
        if (activeweapon != null)
        {
            Destroy(activeweapon);

        }
        activeweapon = Instantiate(weapons[currentweapon], weaponpoint.position, weaponpoint.rotation, weaponpoint);
        activeweapon.GetComponent<NetworkObject>().Spawn(true);

    }
}
