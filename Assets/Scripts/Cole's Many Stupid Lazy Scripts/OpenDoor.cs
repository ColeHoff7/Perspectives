using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public bool open = false;
    private AudioSource aud;
    private Vector3 pos;
    private bool playing = false;

    void Start()
    {
        pos = transform.position;
        aud = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
		if(open)
        {
            transform.position = Vector3.Lerp(transform.position, pos+Vector3.up*3, Time.deltaTime);
        }
        if(!open)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        }

        if(transform.position.y > pos.y+.1f && transform.position.y < (pos.y + 2.6f))
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
