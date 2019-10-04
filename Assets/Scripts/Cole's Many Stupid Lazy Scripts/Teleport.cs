using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform teleportLocation;
	
    void OnTriggerEnter(Collider col)
    {
        col.gameObject.transform.position = teleportLocation.position;
        col.gameObject.transform.rotation = teleportLocation.rotation;
    }
}
