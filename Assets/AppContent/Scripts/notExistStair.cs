using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notExistStair : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision info) {
		GetComponent<AudioSource>().Play();
		GetComponent<Collider>().enabled = false;
		GetComponent<Renderer>().enabled = false;
	}
}
