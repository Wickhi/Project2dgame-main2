using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractions : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activatetelekomk�t�get�()
    {
        
        Camera.GetComponent<Telekomk�t�get�>().enabled = true;
        Camera.GetComponent<Telekomk�t�get�_�sszek�t�>().enabled = true;
    }
    public void Acticatepasswordguesser()
    {

        Camera.GetComponent<passwordguesser>().enabled = true; 
    }
}
