using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class pkay : MonoBehaviour
{
    public ParticleSystem prc;
    // Start is called before the first frame update
    void Start()
    {
        prc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, prc.main.duration);
    }
}
