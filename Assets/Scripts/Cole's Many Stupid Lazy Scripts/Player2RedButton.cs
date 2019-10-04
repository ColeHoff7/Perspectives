using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2RedButton : MonoBehaviour {

    public MoveWalkway walkway;
    public GameObject button;
    public bool pressed = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "pickup" && !pressed)
        {
            button.transform.Translate(Vector3.down * .1f);
            pressed = true;
            walkway.moved = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pickup" && pressed)
        {
            button.transform.Translate(Vector3.up * .1f);
            pressed = false;
            walkway.moved = false;
        }
    }
}
