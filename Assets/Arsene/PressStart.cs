using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour {

	public GameObject pressImage;
	public GameObject annica;
	public GameObject button1;
	public GameObject button2;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			pressImage.SetActive(false);
			//annica.GetComponent<Animator> ().enabled = false;
			RectTransform rect = annica.GetComponent<RectTransform> ();
			rect.localScale = new Vector3 (1, 1, 1);
			rect.Translate(new Vector3(0,65,0));
			button1.SetActive (true);
			button2.SetActive (true);

		}
	}
}
