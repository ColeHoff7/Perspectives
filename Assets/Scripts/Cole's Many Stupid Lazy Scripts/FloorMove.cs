using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour {
    public bool movedUp = false;
    private Vector3 pos;
    private AudioSource aud;
    private bool playing = false;
    void Start ()
    {
        pos = transform.position;
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (movedUp)
        {
            transform.position = Vector3.Lerp(transform.position, pos + Vector3.up * 10, Time.deltaTime);
        }
        if (!movedUp)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }

        if (transform.position.y > pos.y + .1f && transform.position.y < (pos.y + 9.6f))
        {
            if (!playing)
            {
                aud.Play();
                playing = true;
            }
        }
        else
        {
            aud.Stop();
            playing = false;
        }
    }


}
