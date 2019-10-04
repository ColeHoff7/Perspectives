using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTwoScript : MonoBehaviour {

    public GameObject shape;
    public BoxOneScript box1;
    public FloorMove floor;
    public bool triggered;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == shape && box1.triggered) triggered = true;
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
