using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {
	public GameObject start;
	public GameObject player;
	public GameObject camera;
	public GameObject ui;

	public void StartNewGame() {
		ui.GetComponent<PauseGame> ().enabled = true;
		start.SetActive (false);
		player.GetComponent<PlayerMovementKey> ().enabled = true;
		camera.GetComponent<CameraFollow> ().enabled = true;
	}
		

}
