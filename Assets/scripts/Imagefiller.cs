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

                fillpercentage2 = (float)weapon.GetComponent<l�ves>().mag / (float)weapon.GetComponent<l�ves>().magazinebase;
                fillpercentage = weapon.GetComponent<l�ves>().reloadtime / weapon.GetComponent<l�ves>().reloadtimeBase;
                if (weapon.GetComponent<l�ves>().isreloading == true)
                {
                    reload.fillAmount = 1 - fillpercentage;

                }
                if (weapon.GetComponent<l�ves>().isreloading == false)
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
