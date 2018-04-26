using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nrt_floor : MonoBehaviour {

	public TearManager tear_manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("something");
		if (collision.gameObject.name == "Mask's tear(Clone)") {
			tear_manager.less_tears ();
			Destroy (collision.gameObject);
		}
	}
}
