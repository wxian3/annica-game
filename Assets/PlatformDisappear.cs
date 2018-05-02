using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisappear : MonoBehaviour {

    private bool disappear;

	// Use this for initialization
	void Start () {
        //originalScale = transform.localScale;
	}
	
	// Update is called once per frame
    void Update () {
        if (disappear) 
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.a -= 0.03f;
            gameObject.GetComponent<Renderer>().material.color = c;
            if (c.a <= 0.01f) {
                gameObject.SetActive(false);
                disappear = false;
                Invoke("Reappear", 2.0f);
            }
        } else {
           Color c = gameObject.GetComponent<Renderer>().material.color;
           if (c.a <= 0.99f) {
                c.a += 0.03f;
                gameObject.GetComponent<Renderer>().material.color = c;
            }
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "annica")
        {
            //Debug.Log("disappear = true");
            disappear = true;
        }
	}

    private void Reappear() {
        gameObject.SetActive(true);
    }
}
