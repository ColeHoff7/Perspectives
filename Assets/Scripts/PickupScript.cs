using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PickupScript : NetworkBehaviour {

    public bool canHold = true;
    private Vector3 holder;    // Matt: these shouldn't be public, need to be set by code
    private GameObject item;    // see above
    public float speed = 10.0f;
    public Transform cameraPos;

    void OnConnectedToServer() {
        //Debug.Log("Player ID is " + Network.player.ToString());
    }

	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold){

                CmdLetGo(item.name);
                Throw(cameraPos.forward);
                canHold = true;
                item = null;

            
            } else {
                if(canPickUp()){
                    CmdPickup(item.name);
                    canHold = false;
                }

            }
        }//mause If
        
        if(Input.GetMouseButtonDown(1))
        {
            if (!canHold) {
                CmdLetGo(item.name);
                Drop();
                canHold = true;
                item = null;
            }
        }


        if(!canHold)
            CmdUpdateCube(item.name, cameraPos.position, cameraPos.forward, cameraPos.up);
    }

    bool canPickUp()
    {
        RaycastHit hitInfo;
        Physics.Raycast(cameraPos.position, cameraPos.forward, out hitInfo, 3.0f);
        GameObject objecthit;
        if(hitInfo.collider != null)
        {
            objecthit = hitInfo.collider.gameObject;
            Debug.DrawLine(cameraPos.position, hitInfo.point, Color.white, 10.0f);
            if (objecthit.tag == "pickup")
            {
                item = objecthit;
                if(item.GetComponent<PickUpable>().pickedUp == false)
                    return true;
                else
                    return false;
            }
            else
            {
                item = null;
                return false;
            }
        }
        else
        {
            item = null;
            return false;
        }
    }

    [Command]
    void CmdUpdateCube(string name, Vector3 position, Vector3 forward, Vector3 up) {
        // item.transform.localRotation = cameraPos.rotation;
        //We re-position the ball on our guide object 
        item = GameObject.Find(name);
        if(item != null){
            item.transform.position = position + (forward*2);
            item.transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

    [Command]
    void CmdPickup(string name){
        RpcPickUp(name);
    }

    [ClientRpc]
    void RpcPickUp(string name) {

        GameObject.Find(name).GetComponent<PickUpable>().pickedUp = true;
        GameObject.Find(name).GetComponent<Rigidbody>().useGravity = false;
    }

    [Command]
    void CmdLetGo(string name){
        RpcLetGo(name);
    }

    [ClientRpc]
    void RpcLetGo(string name) {

        GameObject.Find(name).GetComponent<PickUpable>().pickedUp = false;
        GameObject.Find(name).GetComponent<Rigidbody>().useGravity = true;
    }

    void Drop()
    {

        //Set our Gravity to true again.
        item.GetComponent<Rigidbody>().useGravity = true;
        

    }

    void Throw(Vector3 forward)
    {
        if (!item)
            return;

        //Set our Gravity to true again.
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().velocity = forward * speed;

    }
}

