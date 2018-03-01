using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {
	int diamond_left;
	// Use this for initialization
	void Start () {
		diamond_left = 4;
	}

	public void Absorb() {
		diamond_left -= 1;
		if (diamond_left == 0) {
			Transform trans = GameObject.Find ("polySurface152").transform;
			RotateBridge (trans);
		}
	}

	void RotateBridge(Transform trans) {
		trans.RotateAround (trans.position, trans.up, 90);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
