using UnityEngine;

public class dronedeploy : MonoBehaviour
{
    public GameObject Drone;
    public Transform buildingspot;
    public int numberofdrones;
    public bool deployed;
    public follow_script follow;
    public float rechargetime;
    public bool recharge;

    public float rechargetimeBase;
    public int NumberOfDronesbase;
    // make drone recahrge
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numberofdrones < NumberOfDronesbase)
        {
            if (recharge == false)
            {
                rechargetime = rechargetimeBase;
                recharge = true;

            }
        }

        if (rechargetime > 0)
        {
            rechargetime -= Time.deltaTime;
        }
        if (rechargetime < 0 || rechargetime == 0)
        {
            if (recharge == true)
            {
                numberofdrones++;
                if (numberofdrones == NumberOfDronesbase)
                {
                    recharge = false;
                }
            }

        }
        if (deployed == false)
        {
            if (numberofdrones > 0)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GameObject droe = Instantiate(Drone, buildingspot.position, gameObject.transform.rotation);
                    droe.GetComponent<drobe>().player = gameObject;
                    droe.GetComponent<drobe>().dronedeploy = this;
                    droe.GetComponent<drobe>().follow = follow;

                    deployed = true;
                    numberofdrones--;
                }

            }
        }
    }
}
