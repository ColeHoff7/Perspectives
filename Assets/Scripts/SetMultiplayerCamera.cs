using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetMultiplayerCamera : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = GetComponent<Camera>();
        if (!isLocalPlayer)
        {
            cam.enabled = false;
            return;
        }
    }
}
