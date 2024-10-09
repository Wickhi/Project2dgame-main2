using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class overlord : MonoBehaviour
{
    public GameObject Mormak;
    public int NumberOfMormaks;
    public int MormakSpawncap;
    public Vector3 Mormakspawnpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnenemy(GameObject enemy, Vector3 spawnpoint)
    {
        Instantiate(enemy, spawnpoint, gameObject.transform.rotation);

    }
    void determineassaulttype()
    {
        
    }
    void determineassaulttype()
    {

    }
}
