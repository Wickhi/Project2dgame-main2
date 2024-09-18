using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer2 : MonoBehaviour
{
    public Slider slider;
    public GameObject Stuart;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cooldown();
    }
    public void cooldown()
    {
        if(Stuart != null)
        {
            slider.maxValue = Stuart.GetComponent<playermovement_orgia_script>().maxstamina;
            slider.minValue = 0;
            //slider.minValue = Stuart.GetComponent<playermovement_orgia_script>().maxstamina / 10 * -1;
            slider.value = Stuart.GetComponent<playermovement_orgia_script>().stamina;


        }

    }
    public void Setplayer(GameObject Stuart2)
    {
        Stuart = Stuart2;

    }
}

