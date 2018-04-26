using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nrt_basket : MonoBehaviour {

	// Use this for initialization

	private bool cry;

	void Start () {
		cry = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("something");
		if (collision.gameObject.name == "Mask's tear(Clone)" && !cry) {
			//tear_manager.less_tears ();
			Destroy (collision.gameObject);
		}
	}

	public void stop_cry(){
		cry = false;
	}

}
