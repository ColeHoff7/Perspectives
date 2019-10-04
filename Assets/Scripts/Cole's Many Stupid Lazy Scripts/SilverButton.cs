using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverButton : MonoBehaviour {

    public ExtendedWalkway walkway;
    public GameObject silverCube;
    public GameObject button;
    public bool pressed = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == silverCube && !pressed)
        {
            button.transform.Translate(Vector3.down * .1f);
            pressed = true;
            walkway.moved = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == silverCube && pressed)
        {
            button.transform.Translate(Vector3.up * .1f);
            pressed = false;
            walkway.moved = false;
        }
    }
}
