using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnGame : MonoBehaviour {


	public void ReturnToMain() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("StartScene", LoadSceneMode.Single);
	}
}
