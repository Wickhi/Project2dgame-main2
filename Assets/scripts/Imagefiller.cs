using UnityEngine;
using UnityEngine.UI;


public class Imagefiller : MonoBehaviour
{
    public Image reload;
    public GameObject stuart;
    public GameObject weapon;
    public float fillpercentage;
    public float fillpercentage2;

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

                fillpercentage2 = (float)weapon.GetComponent<löves>().mag / (float)weapon.GetComponent<löves>().magazinebase;
                fillpercentage = weapon.GetComponent<löves>().reloadtime / weapon.GetComponent<löves>().reloadtimeBase;
                if (weapon.GetComponent<löves>().isreloading == true)
                {
                    reload.fillAmount = 1 - fillpercentage;

                }
                if (weapon.GetComponent<löves>().isreloading == false)
                {
                    reload.fillAmount = fillpercentage2;
                }

            }


        }





    }
    public void Setplayer(GameObject Stuart2)
    {
        stuart = Stuart2;

    }
}
