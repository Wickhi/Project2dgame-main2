using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class neme : MonoBehaviour
{
    public AudioClip lövés;
    public AudioSource audiscr;
    // Start is called before the first frame update
    void Start()
    {
        lövés = Resources.Load<AudioClip>("lövés");
        audiscr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audiscr.PlayOneShot(lövés);
    }
}
