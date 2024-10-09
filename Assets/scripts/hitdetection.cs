using UnityEngine;

public class hitdetection : MonoBehaviour
{
    public GameObject player;
    public string playername;
    public string wallname;
    public int falszam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find(playername);
    }

    void OnMouseDown()
    {
        if (player.GetComponent<building_script>().mozoghat == false && player.GetComponent<building_script>().selected == false)
        {
            Destroy(gameObject);
            player.GetComponent<building_script>().falszam += 1;
            player.GetComponent<building_script>().Canbuild = true;
        }
        // Destroy the gameObject after clicking on it
        if (player.GetComponent<building_script>().buildingtime == true)
        {
            player.GetComponent<building_script>().Canbuild = false;
            wallname = gameObject.name;
            player.GetComponent<building_script>().fal = gameObject;



        }



    }

}

