using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hivemind : MonoBehaviour
{
    public int Targettingstuart;
    public int Targettinggeorge;
    public int Targettingjohn;
    public Dictionary<GameObject, int> playernumber;
    public overlord overlord;
    public List<GameObject> Players;
    public List<GameObject> targets;
    public List<int> integers;
    public List<int> integers2;

    public float refreshrate;
    public float refreshrateBase;
   
    // Start is called before the first frame update
    void Start()
    {
        Players = overlord.Players;
        integers = new List<int> { Targettingstuart, Targettinggeorge, Targettingjohn };
        playernumber = new Dictionary<GameObject, int>();
        integers2.AddRange(new int[Players.Count]);

        integers = integers2;
        integers2.Clear();
        integers2.AddRange(new int[Players.Count]);

        foreach (GameObject player in Players)
        {
            int y = Players.IndexOf(player);
            integers2.Clear();
            foreach (GameObject target in targets)
            {
                if (target == player)
                {
                    integers2[y]++;
                }

            }
            playernumber.Add(player, integers[y]);

        }
        targets.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (refreshrate > 0)
        {
            refreshrate -= Time.deltaTime;
        }
        if (refreshrate <= 0)
        {
            refreshrate = refreshrateBase;
            integers = integers2;
            integers2.Clear();
            integers2.AddRange(new int[Players.Count]);
            foreach (GameObject player in Players)
            {
                int y = Players.IndexOf(player);
                foreach (GameObject target in targets)
                {
                    if (target == player)
                    {
                        integers2[y]++;
                        foreach (int f in integers)
                        {
                           
                            Debug.Log(f);
                        }
                    }

                }
                playernumber[player] = integers[y];

            }
            targets.Clear();
        }
    }
}
