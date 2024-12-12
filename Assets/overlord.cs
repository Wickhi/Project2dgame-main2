using System.Collections.Generic;
using UnityEngine;

public class overlord : MonoBehaviour
{
    public PathfindingOptimized PT;
    public List<GameObject> Players;
    public GameObject Mormak;
    public int NumberOfMormaks;
    public int MormakSpawncap;
    public Vector3 Mormakspawnpoint;
    public string Difficulty;
    public string DifficultyName;
    public int Difficultylevel;
    public int Assaultphase;
    public int CustomAssaultphase;
    public GameObject player;
    public bool activate;
    public bool Reconphaseactive;
    public GameObject ReconPrefab;
    public bool reconreturned;
    public GameObject Recon;
    public List<GameObject> Targets;
    public List<GameObject> Spawnpoints;
    public List<Vector2> Sentryonmap;
    private float Mormaktimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            Buildphase(Mormak, MormakSpawncap, Mormakspawnpoint, 0.2f);
        }
        if (Assaultphase == 1)
        {
            //reconphaseStart
            if (Reconphaseactive == true)
            {
                ReconphaseStart(ReconPrefab, Mormakspawnpoint);
                Reconphaseactive = false;
            }

            if (reconreturned == true)
            {
                //Increase Difficulty
                Assaultphase++;
            }
            if (Recon == null && reconreturned == false)
            {
                Assaultphase++;
            }

        }
        if (Assaultphase == 2)
        {
            Buildphase(Mormak, MormakSpawncap, Mormakspawnpoint, 0.2f);


        }
    }
    void Spawnenemy(GameObject enemy, Vector3 spawnpoint)
    {
        var enem =Instantiate(enemy, spawnpoint, gameObject.transform.rotation);
        var zombiescript = enem.GetComponent<zombie>();
        zombiescript.pt = PT;
        zombiescript.players = Players;
        zombiescript.player = player;
    }
    void SpawnSentryBuster(GameObject enemy, Vector3 spawnpoint)
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
    void Buildphase(GameObject enemy, int Spawncap, Vector3 spawnpoint, float MormakTimer)
    {
        if (NumberOfMormaks < Spawncap)
        {

            if (Mormaktimer <= 0)
            {
                Spawnenemy(enemy, spawnpoint);
                NumberOfMormaks++;
                Mormaktimer = MormakTimer;
            }
            else
            {
                Mormaktimer -= Time.deltaTime;

            }

        }
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
