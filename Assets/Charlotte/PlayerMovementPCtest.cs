using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovementPCtest : MonoBehaviour
{
	public float speed = 0.1f;
	Vector3 movement;
	Rigidbody playerRigidbody;
	public bool isGrounded;
	public float jumpableGroundNormalMaxAngle = 45f;
	public bool closeToJumpableGround;

	public Transform pcCamera;
	private bool inAdjust;
	private bool mouseMove;
	private Vector3 beginCharacterToMouse;
	private Vector3 currentCharacterToMouse;
	private Vector3 beginMousePosition;
	private Vector3 currentMousePosition;
	private Vector3 offset;

	//Animator anim;
	//int floorMask;
	//float camRayLength = 100f;

	void Awake() {
		//floorMask = LayerMask.GetMask ("Floor");
		//anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void Start() {
		inAdjust = false;
		mouseMove = false;
		isGrounded = false;
		offset = pcCamera.position - transform.position;
	}
		
	void LateUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);


		if (Input.GetMouseButtonDown (1)) {
			inAdjust = true;
			beginCharacterToMouse = pcCamera.position - transform.position;
			beginMousePosition = Input.mousePosition;
		}
			
		if (Input.GetMouseButtonUp (1)) {
			inAdjust = false;
		}

		if (Input.GetMouseButtonDown (0)) {
			mouseMove = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseMove = false;
		}


		if (inAdjust) {

			float distance = Mathf.Pow (beginCharacterToMouse.x, 2) + Mathf.Pow (beginCharacterToMouse.y, 2) + Mathf.Pow (beginCharacterToMouse.z, 2);
			distance = Mathf.Sqrt (distance);

			currentMousePosition = Input.mousePosition;
			float horizonShift = - (currentMousePosition - beginMousePosition).x * 0.01f;

			Vector3 tempCtoM;
			tempCtoM.x = beginCharacterToMouse.x * Mathf.Cos (horizonShift) - beginCharacterToMouse.z * Mathf.Sin(horizonShift);
			tempCtoM.z = beginCharacterToMouse.z * Mathf.Cos (horizonShift) + beginCharacterToMouse.x * Mathf.Sin(horizonShift);
			tempCtoM.y = beginCharacterToMouse.y;

			currentCharacterToMouse = tempCtoM;
			offset = currentCharacterToMouse;
			Quaternion newRotation = Quaternion.LookRotation (currentCharacterToMouse);
			newRotation.x = 0f;
			newRotation.z = 0f;
			transform.rotation = newRotation;

			if (inAdjust && mouseMove) {
				Move (0f, 1f);
			}

		}

//		if (CharacterCommon.CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0f, 0f, out closeToJumpableGround))
//			isGrounded = true;
//
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Debug.Log ("get space down");
			playerRigidbody.AddForce (new Vector3 (0f, 100f, 0f));
		}
			
//		anim.SetFloat ("Speed", Mathf.Abs(h + v));
//		anim.SetBool ("isWalking", true);
//		Turning ();
//		Animating (h, v);
	}

	void Move (float h, float v) {

		float faceDirection = Mathf.Acos(transform.rotation.y) * 2f;
//		Debug.Log ("cos theta" + Mathf.Cos(faceDirection));
//		Debug.Log ("theta" + faceDirection);
//		Debug.Log ("sin theta" + Mathf.Sin (faceDirection));

		float h2 = - v * Mathf.Sin (faceDirection) + h * Mathf.Cos (faceDirection);
		float v2 = v * Mathf.Cos (faceDirection) + h * Mathf.Sin (faceDirection);
//		Debug.Log(v);
		//Debug.Log("h:" + h2 + " v:" + v2);
		movement.Set (h2, 0f, v2);
		movement = movement.normalized * speed * Time.deltaTime;
		//playerRigidbody.MovePosition (transform.position + movement);
		transform.position += movement;

//		if (h != 0f || v != 0f)
//		anim.SetBool ("isWalking", true);
//		else
//			anim.SetBool ("isWalking", false);
	}

//	void Turning() {
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		RaycastHit floorHit;
//
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
//			Vector3 playerToMouse = - floorHit.point + transform.position;
//			playerToMouse.y = 0f;
//
//			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
//			playerRigidbody.MoveRotation (newRotation);
//		}
//	}

//	void Animating(float h, float v) {
//		bool walking = h != 0f || v != 0f;
//		anim.SetBool ("IsWalking", walking);
//	}
}
