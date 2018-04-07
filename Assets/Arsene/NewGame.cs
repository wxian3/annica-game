using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

	public void StartNewGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene");
	}
}
