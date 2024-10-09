using UnityEngine;

public class characterswitch_john : MonoBehaviour
{
    public GameObject Stuart;
    public GameObject cam;
    public int playerszam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerszam = cam.GetComponent<follow_script>().playervalue;
        if (playerszam == 3)
        {
            Stuart.GetComponent<playermovement>().enabled = true;
            Stuart.GetComponent<shooting_script>().enabled = true;
            Stuart.GetComponent<building_script>().enabled = true;
            Stuart.GetComponent<grenadethrow_script>().enabled = true;
            Stuart.GetComponent<car>().enabled = true;

        }
        else
        {
            Stuart.GetComponent<playermovement>().enabled = false;
            Stuart.GetComponent<shooting_script>().enabled = false;
            Stuart.GetComponent<building_script>().enabled = false;
            Stuart.GetComponent<grenadethrow_script>().enabled = false;
            Stuart.GetComponent<car>().enabled = false;
        }
    }
}
