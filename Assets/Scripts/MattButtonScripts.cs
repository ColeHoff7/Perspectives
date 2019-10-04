using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattButtonScripts : MonoBehaviour {

	public string name;

	public static float launchSpeed = 25.0f;

	public Transform cannon;

	public GameObject bombPrefab;

	private static GameObject currentBomb;

	void OnMouseDown() {

		switch(name) {
			case "Bomb":
			bomb();
			break;
			case "Ignite":
			ignite();
			break;
			case "Launch":
			launch();
			break;
		}
	}

	private void bomb() {
		if(currentBomb == null)
			currentBomb = Instantiate(bombPrefab, cannon.position + Vector3.up, Quaternion.identity);
	}

	IEnumerator giveUpBall()
    {
    	yield return new WaitForSeconds(3);
    	
    	currentBomb = null;
    }

	private void ignite() {
		if(currentBomb != null)
			currentBomb.GetComponent<Bomb>().ignite();
		StartCoroutine(giveUpBall());
	}

	private void launch() {

		currentBomb.GetComponent<Rigidbody>().velocity = cannon.forward * launchSpeed;
	}
}
