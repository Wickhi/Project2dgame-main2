using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidee : MonoBehaviour
{
    public bool usinghmg = false;
    public bool bentvan = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
