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
        if (Stuart != null)
        {
            if (Stuart.GetComponent<Weaponswitch_script>().activeweapon != null)
            {
                weapon = Stuart.GetComponent<Weaponswitch_script>().activeweapon;

            }
            if (weapon != null && weapon != Stuart)
            {

                slider.value = weapon.GetComponent<löves>().reloadtimebase;
                slider.maxValue = weapon.GetComponent<löves>().reloadtimeBase;

            }

        }

    }
    public void cooldown()
    {
    }
    public void Setplayer(GameObject Stuart2)
    {
        Stuart = Stuart2;

    }
}
