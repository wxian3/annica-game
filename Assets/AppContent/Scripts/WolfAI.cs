using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent), typeof(AudioSource))]

public class WolfAI : MonoBehaviour {
	public GameObject[] waypoints;
	public float minDist = 0.4f;

	private NavMeshAgent agent;
	private Animator anim;

	private int currWaypoint = -1;
	private float timer = 0.0f;
	private float sitTime = 7.0f;
	private float idleTime = 13.0f;

	public Image gameOverImage;
    bool death = false;

	public enum AIState {
		Patrol,
		Sit,
		Idle,
		Angry
	};

	public AIState aiState;
	private float maxLookaheadTime = 2f;

	public GameObject player;
	public float minPDist = 10f;

	AudioSource audio;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		if (agent == null)
			Debug.Log("NavMeshAgent agent could not be found");

		anim = GetComponent<Animator>();

		if (anim == null)
			Debug.Log("Animator could not be found");
		
		audio = GetComponent<AudioSource> ();

		anim.SetBool("satisfied", false);
		aiState = AIState.Idle;
	}

	// Update is called once per frame
	void Update () {

		if (death) {
        	System.Threading.Thread.Sleep(500); 
            gameOverImage.gameObject.SetActive(true);
        }

		var dist = Vector3.Distance(this.transform.position, player.transform.position);
		if (dist < minPDist) {

			aiState = AIState.Angry;
			anim.SetBool("playerSeen", true);
			agent.Stop ();
			audio.Play ();
			this.transform.LookAt (player.transform);
		}

		switch (aiState) {
		case AIState.Patrol:
			if (agent.remainingDistance < minDist) {
				aiState = AIState.Sit;
				sit ();
			}
			break;
		case AIState.Sit:
			if (timer >= sitTime) {
				anim.SetBool("satisfied", false);
				aiState = AIState.Patrol;
				setNextWaypoint ();
			} else {
				timer += Time.deltaTime;
			}
			break;
		case AIState.Idle:
			if (timer >= idleTime) {
				anim.SetTrigger ("start");
				aiState = AIState.Patrol;
				setNextWaypoint ();
			} else {
				timer += Time.deltaTime;
			}
			break;
		case AIState.Angry:
			if (dist >= minPDist) {
				anim.SetBool ("playerSeen", false);
				aiState = AIState.Patrol;
				anim.SetBool("satisfied", false);
				agent.Resume ();
			} 
			break;
		}
	}

	void sit() {
		anim.SetBool("satisfied", true);
		timer = 0;
	}

	void setNextWaypoint() {
		currWaypoint = (currWaypoint + 1) % waypoints.Length;
		SetDestination ();
	}

	void SetDestination () {
		if (waypoints.Length == 0)
			Debug.Log ("No waypoints found");
		else {
			agent.SetDestination (waypoints [currWaypoint].transform.position);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "annica" && !death) {
			//Destroy(collision.gameObject);
			//GetComponent<AudioSource>().Play();
			death = true;
			Debug.Log("die of meeting wolf.");
		}
	}
}
