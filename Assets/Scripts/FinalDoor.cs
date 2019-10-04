using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class addForceExample : NetworkBehaviour {

    public float forceAmount = 1000f;
    private Rigidbody rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "player")
        {
            rg.AddForce(-transform.forward * forceAmount, ForceMode.Force);
            print("clicked");
        }
    }
}
