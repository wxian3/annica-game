using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCollector : MonoBehaviour {

	public Image winningImage;
	int diamondCount = 0;
	public Bridge bridge;
	public Boat boat;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (diamondCount == 7) {
			//System.Threading.Thread.Sleep(1000); 
			winningImage.gameObject.SetActive(true);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "diamond") {
			diamondCount++;
			if (collision.gameObject.name == "Cube") {
				bridge = GameObject.Find ("bridge").GetComponent <Bridge> ();
				bridge.Rotate ();
			}
		}

		if (collision.gameObject.name == "boatBody") {
			boat = GameObject.Find ("boat").GetComponent <Boat> ();
			boat.Move ();
		}
	}
}
