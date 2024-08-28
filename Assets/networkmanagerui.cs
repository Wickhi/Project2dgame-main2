using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class networkmanagerui : MonoBehaviour
{
    [SerializeField] private Button server;
    [SerializeField] private Button host;
    [SerializeField] private Button client;

    // Start is called before the first frame update
    private void Awake()
    {
        server.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            disablebuttons();

        });
        host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            disablebuttons();

        });
        client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            disablebuttons();
        });
    }
    void disablebuttons()
    {
        server.gameObject.SetActive(false);
        host.gameObject.SetActive(false);

        client.gameObject.SetActive(false);

    }
}
