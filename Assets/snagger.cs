using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snagger : MonoBehaviour
{
    public Transform kéz;
    public Transform enemy;
    public bool megfogva = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {



        if (megfogva == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                enemy.position = kéz.position;
                enemy.GetComponent<BoxCollider2D>().enabled = false;

            }

        }
        if (megfogva == false)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {

                enemy.GetComponent<BoxCollider2D>().enabled = true;

            }

        }
    }




    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("barom");

        if (collider.gameObject.tag == "Player")
        {
            megfogva = true;
            Debug.Log("barom");
        }




    }
    void OnTriggerExit2D(Collider2D collider)
    {
        megfogva = false;

        if (collider.gameObject.tag == "Player")
        {
            megfogva = false;

        }



    }


}


