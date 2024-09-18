using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconscript : MonoBehaviour
{
    public Image icon;
    public GameObject stuart;
    public GameObject weapon;
    public int firemode;
    public Sprite semiautofireicon;
    public Sprite burstfireicon;
    public Sprite autofireicon;
    public Sprite buckshotfireicon;
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
                firemode = weapon.GetComponent<löves>().firemode;

            }

        }


        if (firemode == 1)
        {
            icon.sprite = semiautofireicon;

        }
        if (firemode == 2)
        {
            icon.sprite = burstfireicon;
        }
        if (firemode == 3)
        {
            icon.sprite = autofireicon;
        }
        if (firemode == 4)
        {
            icon.sprite = buckshotfireicon;
        }
        
    }
    public void Setplayer(GameObject Stuart2)
    {
        stuart = Stuart2;

    }
}
