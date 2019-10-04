using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSlider : MonoBehaviour {

	private bool dragging = false;
	
	public float sensitivity = .4f;
    private Vector3 offset;
    private Vector3 reference;
    private Vector3 rotation = Vector3.zero;

	void OnMouseDown() {
		Debug.Log("Help Me");
		reference = Input.mousePosition;
		dragging = true;
	}

	void OnMouseUp() {
		dragging = false;
	}


	void Update() {

		if (dragging) {

			offset = (Input.mousePosition - reference);

	        transform.RotateAround(Vector3.up, -(offset.x) * sensitivity * .25f);

	        transform.Rotate(Vector3.right, (offset.y) * sensitivity*10);
	             
	        reference = Input.mousePosition;

    	}
	}
}
