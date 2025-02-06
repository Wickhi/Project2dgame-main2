using System.Collections.Generic;
using UnityEngine;

public class overlord : MonoBehaviour
{
    public PathfindingOptimized PT;
    PathfindingData PD;
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
    public List<AudioClip> sounds;
    public Hivemind hivemind;
    public bool reconstruckdictionary;

    //reconstruct variables for reconstructdictionaryoverlord method
    public List<Vector2> cellsKeys;
    public List<Cell2> cellsValue;
    public List<Cell2> objectCellKeys;
    public List<GameObject> objectCellValue;
    public List<GameObject> objectCell2Keys;
    public List<Cell2> objectCell2Value;
    public List<Cell2> celltocellKeys;
    public List<cell3> celltocellValue;
    public List<Vector2> cells2Keys;
    public List<GameObject> cells2Value;

    // Dictionaries to be reconstructed
    public Dictionary<Vector2, Cell2> cells;
    public Dictionary<Cell2, GameObject> objectCell;
    public Dictionary<GameObject, Cell2> objectCell2;
    public Dictionary<Cell2, cell3> celltocell;
    public Dictionary<Vector2, GameObject> cells2;

    // Start is called before the first frame update
    void Start()
    {
        cellsKeys = new List<Vector2>();
        cellsValue = new List<Cell2>();
        objectCellKeys = new List<Cell2>();
        objectCellValue = new List<GameObject>();
        objectCell2Keys = new List<GameObject>();
        objectCell2Value = new List<Cell2>();
        celltocellKeys = new List<Cell2>();
        celltocellValue = new List<cell3>();
        cells2Keys = new List<Vector2>();
        cells2Value = new List<GameObject>();
        cellsKeys = PT.cellsKeys;
        cellsValue = PT.cellsValue;
        objectCellKeys = PT.objectCellKeys;
        objectCellValue = PT.objectCellValue;
        objectCell2Keys = PT.objectCell2Keys;
        objectCell2Value = PT.objectCell2Value;
        celltocellKeys = PT.celltocellKeys;
        celltocellValue = PT.celltocellValue;
        cells2Keys = PT.cells2Keys;
        cells2Value = PT.cells2Value;
        reconstruckdictionaryoverlord();

    }

    // Update is called once per frame
    void Update()
    {
        if (reconstruckdictionary == true)
        {
            reconstruckdictionary = false;
            reconstruckdictionaryoverlord();
        }
        if (activate == true)
        {
            Buildphase(Mormak, MormakSpawncap, Mormakspawnpoint, 0.15f);
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
        zombiescript.pt = this;
        zombiescript.pt2 = PT;
        zombiescript.players = Players;
        zombiescript.hivemind = hivemind;
        zombiescript.enemyhealtsystem.overlord = this;
        //zombiescript.player = player;
        //int szam = Random.Range(0, sounds.Count);
        //Debug.Log(szam);
        //zombiescript.attacksound = sounds[szam];
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
    void Attritionphase(GameObject enemy, int Spawncap, Vector3 spawnpoint, float MormakTimer)
    {
        if (NumberOfMormaks < MormakSpawncap)
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
    public void reconstruckdictionaryoverlord()
    {
        cells = new Dictionary<Vector2, Cell2>();
        objectCell = new Dictionary<Cell2, GameObject>();
        objectCell2 = new Dictionary<GameObject, Cell2>();
        celltocell = new Dictionary<Cell2, cell3>();
        cells2 = new Dictionary<Vector2, GameObject>();

        foreach (Cell2 c in cellsValue)
        {
            Debug.Log(c.position);
        }
        // Populate the cells dictionary
        for (int i = 0; i < cellsKeys.Count + 0; i++)
        {
            cells.Add(cellsKeys[i], cellsValue[i]);
            
        }

        // Populate the objectCell dictionary
        for (int i = 0; i < objectCellKeys.Count + 0; i++)
        {
            objectCell.Add(objectCellKeys[i], objectCellValue[i]);
        }

        // Populate the objectCell2 dictionary
        for (int i = 0; i < objectCell2Keys.Count; i++)
        {
            objectCell2.Add(objectCell2Keys[i], objectCell2Value[i]);
        }

        // Populate the celltocell dictionary
        for (int i = 0; i < celltocellKeys.Count; i++)
        {
            celltocell.Add(celltocellKeys[i], celltocellValue[i]);
        }

        // Populate the cells2 dictionary
        for (int i = 0; i < cells2Keys.Count; i++)
        {
            cells2.Add(cells2Keys[i], cells2Value[i]);
        }
    }
}


