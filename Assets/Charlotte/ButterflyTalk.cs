using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider),typeof(Animation))]
public class ButterflyTalk : MonoBehaviour {

	public GameObject player;
	Animation anim;
	// Use this for initialization

	void Awake() {
		//player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animation>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("111");

	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			Debug.Log ("near butterfly!");
			foreach (AnimationState state in anim) {
				state.speed = 0F;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			Debug.Log ("leave butterfly!");
			foreach (AnimationState state in anim) {
				state.speed = 1F;
			}
		}
	}

//	void OnCollisionEnter(Collision collision){
//		Debug.Log ("near butterfly");
//		foreach (ContactPoint contact in collision.contacts) 
//		{
//			if (collision.impulse.magnitude > 0.25f)
//			{
//				Debug.Log ("talk to butterfly");
//				//EventManager.TriggerEvent<MinionFootstepEvent, Vector3> (contact.point);
//				//EventManager.TriggerEvent<AudioEventManager.BoxAudioEvent, Vector3> (contact.point);
//				//Debug.Log("BombBounceEvent");
//			}
//
//		}
//	}
}
