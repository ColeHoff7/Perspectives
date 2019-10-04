using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThudSound : MonoBehaviour {
    public AudioClip thud;
	void OnCollisionEnter(Collision col)
    {
        AudioSource.PlayClipAtPoint(thud, transform.position);
    }
}
