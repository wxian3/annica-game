using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCollector : MonoBehaviour {

    public Image winningImage;
    int diamondCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (diamondCount == 4) {
            winningImage.gameObject.SetActive(true);
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "diamond") {
            diamondCount++;
        }
	}
}
