using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxThreeScript : MonoBehaviour {
    public GameObject shape;
    public BoxOneScript box1;
    public BoxTwoScript box2;
    public FloorMove floor;
    public bool triggered;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == shape && box1.triggered && box2.triggered)
        {
            triggered = true;
            floor.movedUp = true;
        }
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
