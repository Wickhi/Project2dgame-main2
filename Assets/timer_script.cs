using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    public Slider slider;
    public GameObject Stuart;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        weapon = Stuart.GetComponent<Weaponswitch_script>().activeweapon;
        // slider.maxValue = Stuart.GetComponent<shooting>().reloadtime;
        slider.value = weapon.GetComponent<löves>().reloadtimebase;
        slider.maxValue = weapon.GetComponent<löves>().reloadtimeBase;

    }
    public void cooldown()
    {
    }
}
