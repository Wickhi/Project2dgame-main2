using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Weaponswitch_script : NetworkBehaviour
{
    public int numberofweapons;
    public int currentweapon = 0;
    public GameObject[] weapons;
    public GameObject weapon;

    public GameObject activeweapon;
    public Transform weaponpoint;
    public Transform player;
    public bool Spawned;


    // Start is called before the first frame update
    void Start()
    {
        numberofweapons = weapons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentweapon += 1;
            if (currentweapon == numberofweapons)
            {
                currentweapon = -1;
            }
            weaponswitchServerRpc();
        }

    }

    [ServerRpc]
    public void weaponswitchServerRpc() 
    {

        //Serverrpc fog kelleni
        if (Spawned == true)
        {
            //activeweapon.GetComponent<NetworkObject>().Despawn(true);
            if(activeweapon != null)
            {
                Destroy(activeweapon);

            }
            Spawned = false;
            //activeweapon.GetComponent<NetworkObject>().Spawn(false);


        }
        //if (currentweapon! > weapons.Length)
        //{
        if (currentweapon != -1)
        {
            activeweapon = Instantiate(weapons[currentweapon], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            activeweapon.GetComponent<NetworkObject>().Spawn(true);
            activeweapon.GetComponent<NetworkObject>().TrySetParent(weaponpoint);
        }
        Spawned = true;

        //}
        //activeweapon.GetComponent<NetworkObject>().TrySetParent(player);

    }
    public void weaponswitch()
    {

        activeweapon = Instantiate(weapon, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        activeweapon.GetComponent<NetworkObject>().Spawn(true);



    }
}
