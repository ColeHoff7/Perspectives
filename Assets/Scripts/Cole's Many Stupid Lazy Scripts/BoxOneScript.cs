using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOneScript : MonoBehaviour {

    public GameObject shape;
    public FloorMove floor;
    public bool triggered;

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == shape) triggered = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == shape)
        {
            triggered = false;
            floor.movedUp = false;
        }
    }
}
