using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	AudioSource coinSound;
	//public AudioClip coinClip;
	//public GameObject coinModel;
	private Shader shader;
	public Renderer rend;
	bool boxHit = false;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		//coinModel.SetActive (false);
		coinSound = GetComponent<AudioSource> ();
		if (coinSound != null) {
			//Debug.Log ("get diamond sound");
		}
		shader = Shader.Find ("02 - Default");
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (15, 0, 45) * Time.deltaTime);
	}

	void OnCollisionEnter(Collision info) {
		if (info.gameObject.name == "annica" && boxHit == false) {
			//Debug.Log ("box is hit");
			//coinSound.clip = coinClip;
			//coinSound.Play ();
			//coinModel.SetActive (true);
			//Destroy (coinModel, 1.5f);

			//Color blackColor = new Color (0, 0, 0, 1.0f);
			//gameObject.GetComponent<Renderer> ().material.color = blackColor;

			GetComponent<AudioSource>().Play();
			//Destroy(this.gameObject);
			boxHit = true;
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;

		}
		//GameObject.Find ("Game").GetComponent<game>().Absorb ();
	}
}