using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour {
    public Vector3 pos;
	
	void Start()
    {
        pos = transform.position;
    }
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -45)
        {
            transform.position = pos;
        }
	}
}
