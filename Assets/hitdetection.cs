using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitdetection : MonoBehaviour
{
    public GameObject player;
    public string playername;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find(playername);
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        if (player.GetComponent<building_script>().mozoghat == false)
        {
            Destroy(gameObject);
            player.GetComponent<building_script>().falszam += 1;
        }
            

    }

}

