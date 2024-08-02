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
    public void Activatetelekomkötögetõ()
    {
        
        Camera.GetComponent<Telekomkötögetõ>().enabled = true;
        Camera.GetComponent<Telekomkötögetõ_összekötõ>().enabled = true;
    }
    public void Acticatepasswordguesser()
    {

        Camera.GetComponent<passwordguesser>().enabled = true; 
    }
}
