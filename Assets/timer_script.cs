using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
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
       // slider.maxValue = Stuart.GetComponent<shooting>().reloadtime;
        slider.value = Stuart.GetComponent<shooting_script>().active.reloadtimebase;
        slider.maxValue = 4f;
    }
}
