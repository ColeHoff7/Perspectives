using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeCameraCulling : NetworkBehaviour {
    private bool player1 = true;
    public Camera cam;
    int mask;

    void Start()
    {
        if(!isLocalPlayer) {
            cam.enabled = false; // turn off the camera if it isn't on the local player
            return;   
        }else {
            cam.enabled = true;
        }

        mask = cam.cullingMask; 

        if(GameObject.FindGameObjectsWithTag("Player").Length > 1) // I am the second player
            cam.cullingMask = (1 << LayerMask.NameToLayer("PlayerTwo")) | (1 << LayerMask.NameToLayer("Default"));
        
        cam.GetComponent<AudioListener>().enabled = true; // turn on audio listenr for local only
    }
    
    

}
