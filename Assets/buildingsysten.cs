using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingsysten : MonoBehaviour
{
    public bool isbuilding = true;
    public Camera cam;
    public int whattobuild = 2;
    public GameObject bust;
    public GameObject fal;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isbuilding = true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Vector3 building = cam.ScreenToWorldPoint(Input.mousePosition);
                building.z = player.position.z;
                if (whattobuild == 1)
                {
                    GameObject sentry = Instantiate(bust, building, Quaternion.Euler(new Vector3(0, 0, player.rotation.z)));

                }
                if (whattobuild == 2)
                {
                    GameObject newFal = Instantiate(fal);
                }

            }
        }

    }
}
