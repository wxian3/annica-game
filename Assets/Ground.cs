using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ground : MonoBehaviour {
	bool death = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "annica" && !death) {
			Destroy(collision.gameObject);
			GetComponent<AudioSource>().Play();
			death = true;
		}
	}
}