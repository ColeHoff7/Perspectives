using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    public GameObject door;
    public GameObject button;
    public bool pressed = false;


	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "pickup" && !pressed)
        {
            button.transform.Translate(Vector3.down * .1f);
            pressed = true;
            door.GetComponent<OpenDoor>().open = true;

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pickup" && pressed)
        {
            button.transform.Translate(Vector3.up * .1f);
            pressed = false;
            door.GetComponent<OpenDoor>().open = false;
        }
    }
}
