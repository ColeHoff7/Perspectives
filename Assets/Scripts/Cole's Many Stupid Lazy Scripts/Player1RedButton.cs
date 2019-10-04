using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player1RedButton : NetworkBehaviour {

    public GameObject button;
    public bool pressed = false;
    public GameObject theCube;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "pickup" && !pressed)
        {
            button.transform.Translate(Vector3.down * .1f);
            pressed = true;
            CmdDrop();
            RpcDrop();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pickup" && pressed)
        {
            button.transform.Translate(Vector3.up * .1f);
            pressed = false;
        }
    }

    [Command]
    void CmdDrop()
    {
        theCube.GetComponent<Rigidbody>().useGravity = true;
        RpcDrop();
    }

    [ClientRpc]
    void RpcDrop()
    {
        theCube.GetComponent<Rigidbody>().useGravity = true;
    }
}
