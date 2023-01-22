using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class megjelenés : MonoBehaviour
{
    public Image fos;
    public GameObject player;
    public bool mozoghat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Stuart");

        mozoghat = player.GetComponent<building>().mozoghat;
        if (mozoghat == false)
        {
            fos.enabled = true;

        }
        if (mozoghat == true)
        {
            fos.enabled = false;


        }
    }
}
