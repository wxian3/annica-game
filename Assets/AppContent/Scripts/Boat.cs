using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {
	public bool moving = false;
	public GameObject annica;
	// Use this for initialization
	void Start () {
	}

	public void Move () {
		// Debug.Log ("move");
		// Rotate 90 degree first
		moving = true;
	}

	// Update is called once per frame
	void Update () {
		if (moving) {
			transform.position = new Vector3(transform.position.x, transform.position.y, annica.transform.position.z);
		}
	}
}
