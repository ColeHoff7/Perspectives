using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Win : NetworkBehaviour {

	void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScene");
        }
    }

}
