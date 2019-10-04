using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ModeManager : NetworkBehaviour
{

    public bool singlePlayer = false;
    public bool multiPlayer = false;
    public GameObject charPrefab;
    private GameObject menu;
    private GameObject camera;

    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("Main Menu");
        camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SinglePlayer()
    {
        Debug.Log("Starting Single Player");
        singlePlayer = true;
        menu.SetActive(false);
        NetworkManager nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        menu.SetActive(false);
        //GameObject.Destroy(camera);
        nm.StartHost();
        GameObject secondPlayer = Instantiate(nm.playerPrefab);
        secondPlayer.name = "Player2";
    }

    public void Multiplayer()
    {
        Debug.Log("Starting Multi Player");
        multiPlayer = true;
        NetworkManagerHUD nmHud = (NetworkManagerHUD) GameObject.Find("NetworkManager").GetComponent("NetworkManagerHUD");
        nmHud.showGUI = true;
        //GameObject.Destroy(camera);
        menu.SetActive(false);
    }
}
