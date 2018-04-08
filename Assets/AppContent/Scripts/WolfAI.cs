using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class WolfAI : MonoBehaviour {
	public GameObject[] waypoints;
	public float minDist = 0.4f;

	private NavMeshAgent agent;
	private Animator anim;

	private int currWaypoint = -1;
	public float timmer = 0.0f;
	private float sitTime = 7.0f;
	public float idleTime = 13.0f;

	public enum AIState {
		Patrol,
		Sit,
		Idle
	};

	public AIState aiState;
	public float maxLookaheadTime = 2f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		if (agent == null)
			Debug.Log("NavMeshAgent agent could not be found");

		anim = GetComponent<Animator>();

		if (anim == null)
			Debug.Log("Animator could not be found");
		anim.SetBool("satisfied", false);
		aiState = AIState.Idle;
	}

	// Update is called once per frame
	void Update () {
		switch (aiState) {
		case AIState.Patrol:
			if (agent.remainingDistance < minDist) {
				aiState = AIState.Sit;
				sit ();
			}
			break;
		case AIState.Sit:
			if (timmer >= sitTime) {
				anim.SetBool("satisfied", false);
				aiState = AIState.Patrol;
				setNextWaypoint ();
			} else {
				timmer += Time.deltaTime;
			}
			break;
		case AIState.Idle:
			if (timmer >= idleTime) {
				anim.SetTrigger ("start");
				aiState = AIState.Patrol;
				setNextWaypoint ();
			} else {
				timmer += Time.deltaTime;
			}
			break;
		}
	}

	void sit() {
		anim.SetBool("satisfied", true);
		timmer = 0;
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
}
