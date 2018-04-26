using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDisappear : MonoBehaviour {

	public TearManager tear_manager;

	void Start () {
		//tear_manager.more_tears ();
	}

	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 11) {
			//tear_manager.less_tears ();
			Destroy (this.gameObject);
		}
	}
}
