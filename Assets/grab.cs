using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public Transform enemy;
    public GameObject enemy2;
    public Transform kéz;
    public Transform Stuarthát;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        enemy.position = kéz.position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(enemy2);
        }
    }
}
