using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour {

    public GameObject focus;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.right / 2);
        transform.LookAt(focus.transform.position);
    }
}
