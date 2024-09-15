using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teszt2 : MonoBehaviour
{
    public GameObject player;
    public Vector3 lookDir;
    public float change;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDir = new Vector3(player.transform.position.x, player.transform.position.y, 0) - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        var mouse = new Vector3(0f, 0f, angle);
        Quaternion rotation = Quaternion.Euler(mouse);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, change);
    }
}
