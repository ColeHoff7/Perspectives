using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedWalkway : MonoBehaviour {

    public bool moved = false;
    private Vector3 pos;
    private float scale;
    private AudioSource aud;
    private bool playing = false;

    void Start()
    {
        pos = transform.position;
        scale = transform.localScale.x;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moved)
        {
            transform.position = Vector3.Lerp(transform.position, pos + Vector3.left * 20, Time.deltaTime / 6);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale * 7, 1, 4), Time.deltaTime / 2);
        }
        if (!moved)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime / 6);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale, 1, 4), Time.deltaTime / 2);
        }

        if (transform.position.x < pos.x - .1f && transform.position.x > (pos.x + -19.6f))
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
