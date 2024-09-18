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
    public timer2 tm2;
    public Imagefiller imagefiller;
    public timer tm;
    public iconscript iconscript;
    public textszar txt;
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
            tm2.Setplayer(Stuart);
            tm.Setplayer(Stuart);
            iconscript.Setplayer(Stuart);
            txt.Setplayer(Stuart);

            imagefiller.Setplayer(Stuart);


            disablebuttons();
        });
        john.onClick.AddListener(() =>
        {
            John.GetComponent<NetworkObject>().RemoveOwnership();

            John.GetComponent<NetworkObject>().ChangeOwnership(nm.LocalClientId);
            John.GetComponent<playermovement_orgia_script>().enabled = true;
            cam.GetComponent<follow_script>().Stuart = John;
            tm2.Setplayer(John);
            tm.Setplayer(John);
            iconscript.Setplayer(John);
            txt.Setplayer(John);

            imagefiller.Setplayer(John);

            disablebuttons();


        });
        george.onClick.AddListener(() =>
        {
            George.GetComponent<NetworkObject>().RemoveOwnership();
            George.GetComponent<NetworkObject>().ChangeOwnership(nm.LocalClientId);
            George.GetComponent<playermovement_orgia_script>().enabled = true;

            cam.GetComponent<follow_script>().Stuart = George;
            tm2.Setplayer(George);
            tm.Setplayer(George);
            iconscript.Setplayer(George);
            txt.Setplayer(George);

            imagefiller.Setplayer(George);

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
