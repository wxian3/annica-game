using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void MoveToMushroom()
//	{
//		transform.LookAt(targetPosition);
//		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//		if (transform.position == targetPosition)
//			isMoving = false;
//		anim.Play("Quieto");
//		Debug.DrawLine(transform.position, targetPosition, Color.red);
//	}
}
