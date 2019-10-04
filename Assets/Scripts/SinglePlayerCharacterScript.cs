using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SinglePlayerCharacterScript : NetworkBehaviour {

    GameObject player2;
    public Camera cam;
    private bool isPlayer1 = false;
    MyMouseLook p1ml;
    MyMouseLook p2ml;
    // Use this for initialization
    void Start () {
		if(!GameObject.Find("Game Manager").GetComponent<ModeManager>().singlePlayer)
        {
            Destroy(this);
        }
        player2 = GameObject.Find("Player2");
        p2ml = player2.GetComponent<MyMouseLook>();
        p1ml = gameObject.GetComponent<MyMouseLook>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            if (isLocalPlayer)
            {
                Vector3 p2pos = player2.transform.position;
                float p2rot = p2ml.rotationX;
                Quaternion p2realrot = player2.transform.rotation;
                player2.transform.position = gameObject.transform.position;
                p2ml.rotationX = p1ml.rotationX;
                player2.transform.rotation = gameObject.transform.rotation;
                gameObject.transform.position = p2pos;
                p1ml.rotationX = p2rot;
                gameObject.transform.rotation = p2realrot;
                
                switchCameraCulling();

            }
        }
        
    }

    void switchCameraCulling()
    {
        if (isPlayer1)
        {
            cam.cullingMask = (1 << LayerMask.NameToLayer("PlayerTwo")) | (1 << LayerMask.NameToLayer("Default"));
        }
        else
        {
            cam.cullingMask = (1 << LayerMask.NameToLayer("PlayerOne")) | (1 << LayerMask.NameToLayer("Default"));
        }
        isPlayer1 = !isPlayer1;
    }
}
