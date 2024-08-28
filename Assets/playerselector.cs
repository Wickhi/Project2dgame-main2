using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class playerselector : MonoBehaviour {
    public Camera cam;
    public Button stuart;
    public Button george;

    public Button john;
    public GameObject Stuart;
    public GameObject George;
    public GameObject John;
    public GameObject NetworkmanagerObject;
    public NetworkManager nm;
    public GameObject Cam;

    // Start is called before the first frame update
    void Start()
    {
        nm = NetworkmanagerObject.GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stuart.onClick.AddListener(() =>
        {
            Stuart.GetComponent<NetworkObject>().RemoveOwnership();

            Stuart.GetComponent<NetworkObject>().ChangeOwnership(nm.LocalClientId);
            Stuart.GetComponent<playermovement_orgia_script>().enabled = true;

            cam.GetComponent<follow_script>().Stuart = Stuart;
            disablebuttons();

        });
        john.onClick.AddListener(() =>
        {
            John.GetComponent<NetworkObject>().RemoveOwnership();

            John.GetComponent<NetworkObject>().ChangeOwnership(nm.LocalClientId);
            John.GetComponent<playermovement_orgia_script>().enabled = true;
            cam.GetComponent<follow_script>().Stuart = John;
            disablebuttons();


        });
        george.onClick.AddListener(() =>
        {
            George.GetComponent<NetworkObject>().RemoveOwnership();
            George.GetComponent<NetworkObject>().ChangeOwnership(nm.LocalClientId);
            George.GetComponent<playermovement_orgia_script>().enabled = true;

            cam.GetComponent<follow_script>().Stuart = George;
            disablebuttons();
        });
    }
    void disablebuttons()
    {
        stuart.gameObject.SetActive(false);
        john.gameObject.SetActive(false);

        george.gameObject.SetActive(false);

    }
}
