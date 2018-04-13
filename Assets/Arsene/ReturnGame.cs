using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGame : MonoBehaviour {


	public void ReturnToMain() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("StartScene");
	}
		

}
