using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public GameObject pauseScreen;
	public bool playing;

	// Use this for initialization
	void Start () {
		playing = true;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			Time.timeScale = 0;
			pauseScreen.SetActive(true);
//			playing = !playing;
		}
	}

	public void ResumeGame() {
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
	}
}
