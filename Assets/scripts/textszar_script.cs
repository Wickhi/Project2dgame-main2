using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textszar : MonoBehaviour
{
    public string MyText;
    public GameObject stuart;
    public GameObject weapon;
    public TextMeshProUGUI text;
    public int ammo;
    public int reserve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stuart != null)
        {
            if (stuart.GetComponent<Weaponswitch_script>().activeweapon != null)
            {
                weapon = stuart.GetComponent<Weaponswitch_script>().activeweapon;
            }
            if (weapon != null && weapon != stuart)
            {

                ammo = weapon.GetComponent<löves>().mag;
                reserve = weapon.GetComponent<löves>().reserveammo;

                text.text = ammo.ToString() + "/" + reserve.ToString();

            }

        }



    }
    public void Setplayer(GameObject Stuart2)
    {
        stuart = Stuart2;

    }
}
