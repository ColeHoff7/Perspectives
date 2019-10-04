using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {
    public AudioClip deathSound;
	void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        col.gameObject.transform.position = Vector3.zero;
    }
}
