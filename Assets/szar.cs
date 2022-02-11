using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class szar : MonoBehaviour
{
    public float szám = 0;
    public float szám2 = 0.25f;
    public bool egérlent;
    public bool egérlent2;
    public bool mozgás = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            egérlent = true;



        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            egérlent = false;
            mozgás = true;


        }
        if (egérlent == true)
        {
            szám = szám + szám2;
            transform.rotation = Quaternion.Euler(0, 0, szám);
            mozgás = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            egérlent2 = true;
   


        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            egérlent2 = false;
            mozgás = true;
            

        }
        if (egérlent2 == true)
        {
            szám = szám - szám2;
            transform.rotation = Quaternion.Euler(0, 0, szám);
            mozgás = false;

        }
    }
}
