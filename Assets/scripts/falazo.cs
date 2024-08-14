using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falazo : MonoBehaviour
{
    public Collider2D fal;
    public Collider2D stuart;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stuart.IsTouching(fal) == true)
        {
            Debug.Log("fasz");
            
        }
    }
}
