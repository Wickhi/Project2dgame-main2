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
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weapon = stuart.GetComponent<Weaponswitch_script>().activeweapon;
        ammo = weapon.GetComponent<löves>().mag;

        text.text = ammo.ToString(); 
    }
}
