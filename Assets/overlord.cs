using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class overlord : MonoBehaviour
{
    public GameObject Mormak;
    public int NumberOfMormaks;
    public int MormakSpawncap;
    public Vector3 Mormakspawnpoint;
    public string Difficulty;
    public string DifficultyName;
    public int Difficultylevel;
    public int Assaultlevel;
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
    void Determineassaulttype()
    {

    }
    void Reconphase()
    {

    }
    void Buildphase()
    {
        
    }
    void Attritionphase()
    {

    }
    void Minibossphase()
    {

    }
    void Retreat()
    {

    }


    //Custom assault types
    void Swarmtype()
    { 
    }
}
