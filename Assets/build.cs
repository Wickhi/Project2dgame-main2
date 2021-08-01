using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    public GameObject bustPrefab;
    public Transform buildingspot;

    // Start is called before the first frame update
    void Start()
    {
        GameObject fall = Instantiate(bustPrefab, buildingspot.position, buildingspot.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
