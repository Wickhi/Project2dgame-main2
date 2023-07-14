using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidee : MonoBehaviour
{
    public bool usinghmg = false;
    public bool bentvan = false;
    public GameObject Hmg;
    public GameObject Stuart;
    public Transform hmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Stuart = GameObject.Find("Stuart");

        if (bentvan == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!usinghmg)
                {
                    usinghmg = true;

                }
                else
                {
                    usinghmg = false;
                }
            }
        }
        if (usinghmg == false)
        {
            Hmg.GetComponent<hmg>().enabled = false;
            Hmg.GetComponent<shooting_script>().enabled = false;
            Stuart.transform.SetParent(null);

        }
        if (usinghmg == true)
        {
            Hmg.GetComponent<hmg>().enabled = true;
            Hmg.GetComponent<shooting_script>().enabled = true;
            Stuart.transform.SetParent(hmg);

        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {

        bentvan = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        bentvan = false;
    }
}
