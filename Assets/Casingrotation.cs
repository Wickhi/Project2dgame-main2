using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casingrotation : MonoBehaviour
{
    public float casingrotation;
    public float casingrotationspeed;
    public Vector3 casingrotation2;
    // Start is called before the first frame update
    void Start()
    {
        casingrotation = Random.Range(1, 361);
        casingrotationspeed = Random.Range(1, 5);
        casingrotation2 = new Vector3(0, 0, casingrotation);
        Quaternion rotation = Quaternion.Euler(casingrotation2);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, casingrotation);

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(casingrotation2);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, casingrotation);
    }
}
