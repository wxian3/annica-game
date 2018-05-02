using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	public bool rotating = false;

	// Use this for initialization
	void Start () {
	}
		
	public void Rotate() {
		rotating = true;
		GetComponent<AudioSource>().Play();
	}
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			rotating = true;
//			GetComponent<AudioSource>().Play();
//		}
		if (rotating) {
			Vector3 rotate_to = new Vector3 (0, 90, 0);
			Vector3 transform_to = new Vector3 (-6, 2.4f, 19);
			if (Vector3.Distance (transform.eulerAngles, rotate_to) > 0.01f) {
				transform.position = Vector3.Lerp (transform.position, transform_to, Time.deltaTime);
				transform.eulerAngles = Vector3.Lerp (transform.rotation.eulerAngles, rotate_to, Time.deltaTime );
			} else {
				transform.eulerAngles = rotate_to;
				transform.position = transform_to;
				rotating = false;
			}
		}
		//Debug.Log (transform.position);
	}
}
