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
        slider.maxValue = 10f;
        slider.value = Stuart.GetComponent<playermovement>().sprint;

    }
}

