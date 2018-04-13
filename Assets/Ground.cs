using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ground : MonoBehaviour {
    public Image gameOverImage;
    bool death = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (death) {
            gameOverImage.gameObject.SetActive(true);
        }
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "annica" && !death) {
			Destroy(collision.gameObject);
			GetComponent<AudioSource>().Play();
			death = true;
		}
	}
}