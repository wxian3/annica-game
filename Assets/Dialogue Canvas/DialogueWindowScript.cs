using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWindowScript : MonoBehaviour {

	public GameObject right;
	public GameObject left;
	public GameObject back;
	public GameObject canvas;
	RectTransform canvRect;
	public GameObject text;
	// Use this for initialization
	void Start () {
		canvRect = canvas.GetComponent<RectTransform> ();
		Debug.Log (canvRect.rect.width);
	}
	
	// Update is called once per frame
	void Update () {
		if (right.transform.position.x < canvRect.rect.width - 17) {
			right.transform.Translate (Vector3.right * 15);
			left.transform.Translate (Vector3.left * 15);
			back.transform.localScale += new Vector3 (0.84F, 0, 0); 
		} else {
			text.SetActive (true);
		}
	}
}
