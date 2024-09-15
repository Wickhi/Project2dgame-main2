using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class zombieattackcomplementer : MonoBehaviour
{
    public zombie zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("fasz");
        //zombie.activepathfinding = false;
        //zombie.path.Clear();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //zombie.activepathfinding = true;
    }
}
