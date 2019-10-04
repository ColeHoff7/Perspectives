using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalkway : MonoBehaviour {

    public bool moved = false;
    private Vector3 pos;
    private AudioSource aud;
    private bool playing = false;

    void Start()
    {
        pos = transform.position;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moved)
        {
            GetComponent<MeshRenderer>().enabled = true;
            transform.position = Vector3.Lerp(transform.position, pos + Vector3.back * 30, Time.deltaTime/3);
        }
        if (!moved)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime/3);
        }

        if (transform.position.z < pos.z - .1f && transform.position.z > (pos.z +- 29.6f))
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
