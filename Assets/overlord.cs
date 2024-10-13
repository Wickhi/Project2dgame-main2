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
    public int Assaultphase;
    public bool activate;
    public bool Reconphaseactive;
    public GameObject ReconPrefab;
    public bool returned;
    public GameObject Recon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Assaultphase == 1)
        {
            //reconphaseStart
            ReconphaseStart(ReconPrefab, Mormakspawnpoint);
            if (Recon == null)
            {

            }
        }
    }
    void spawnenemy(GameObject enemy, Vector3 spawnpoint)
    {
        Instantiate(enemy, spawnpoint, gameObject.transform.rotation);

    }
    void Determineassaulttype(GameObject enemy, Vector3 spawnpoint)
    {

    }
    void ReconphaseStart(GameObject enemy, Vector3 spawnpoint)
    {
        Recon = Instantiate(enemy, spawnpoint, gameObject.transform.rotation);

    }
    void ReconphaseEnd(GameObject enemy, Vector3 spawnpoint)
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
