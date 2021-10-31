using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        //baseangle < angle4 && angle4 >= 90;
        //angle3 = angle4 - baseangle;
        //angle3 = angle3 - change;
        /////////////b/aseangle = baseangle - change;
    }
}
