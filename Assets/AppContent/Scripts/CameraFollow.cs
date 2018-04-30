using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {

	public GameObject Annica;
	public float smoothing = 5f;
	public float maxSpeed = 5f;        //max speed camera can move
	//int floorMask;
	//float camRayLength = 100f;

	private bool inAdjust;
	private bool rinAdjust;
	private Vector3 beginCharacterToMouse;
	private Vector3 currentCharacterToMouse;
	private Vector3 beginMousePosition;
	private Vector3 currentMousePosition;
	private Vector3 offset;
	//public Vector3 beginFlootHit;
	//public Vector3 currentFlootHit;
	private Transform target;
	private Camera pcCamera;
	private float sensitivity;


	void Awake() {
		pcCamera = GetComponent<Camera> ();
		if (pcCamera != null) {
			Debug.Log ("get pc camera!");
		}
		target = Annica.transform;
		sensitivity = Annica.GetComponent<PlayerMovementPCtest>().sensitivity;
		//floorMask = LayerMask.GetMask ("Floor");
	}

	void Start() {
		//inAdjust = false;
		//rinAdjust = false;
		inAdjust = true;
		beginCharacterToMouse = transform.position - target.position;
		beginMousePosition = Input.mousePosition;
		offset = transform.position - target.position;
	}

	void FixedUpdate() {

		Vector3 targetCamPos = offset + target.position;

		// if (Input.GetMouseButtonDown (0)) {
		// 	inAdjust = true;

		// 	if (rinAdjust != true) {
		// 		beginCharacterToMouse = transform.position - target.position;
		// 		beginMousePosition = Input.mousePosition;
		// 	}
		// }


		// if (Input.GetMouseButtonUp (0)) {
		// 	inAdjust = false;
		// }


		// if (Input.GetMouseButtonDown (1)) {
		// 	rinAdjust = true;

		// 	if (inAdjust != true) {
		// 		beginCharacterToMouse = transform.position - target.position;
		// 		beginMousePosition = Input.mousePosition;
		// 	}
		// }


		// if (Input.GetMouseButtonUp (1)) {
		// 	rinAdjust = false;
		// }
			
		if (inAdjust || rinAdjust) {

			float distance = Mathf.Pow (beginCharacterToMouse.x, 2) + Mathf.Pow (beginCharacterToMouse.y, 2) + Mathf.Pow (beginCharacterToMouse.z, 2);
			distance = Mathf.Sqrt (distance);

			currentMousePosition = Input.mousePosition;
			float horizonShift = - (currentMousePosition - beginMousePosition).x * sensitivity;

			Vector3 tempCtoM;
			tempCtoM.x = beginCharacterToMouse.x * Mathf.Cos (horizonShift) - beginCharacterToMouse.z * Mathf.Sin(horizonShift);
			tempCtoM.z = beginCharacterToMouse.z * Mathf.Cos (horizonShift) + beginCharacterToMouse.x * Mathf.Sin(horizonShift);
			tempCtoM.y = beginCharacterToMouse.y;

			float XZ = Mathf.Sqrt (Mathf.Pow (tempCtoM.x, 2) + Mathf.Pow (tempCtoM.z, 2));// * Mathf.Sign (tempCtoM.x); 
			float verticalShift = - (currentMousePosition - beginMousePosition).y * sensitivity * 0.75f;
			if (verticalShift > (Mathf.Atan (XZ / tempCtoM.y) - Mathf.Acos (0.9f))) {
				verticalShift = (Mathf.Atan (XZ / tempCtoM.y) - Mathf.Acos (0.9f));
			} else if (verticalShift < 0f) {
				if (verticalShift < (Mathf.Atan(XZ / tempCtoM.y) - Mathf.Acos(0.001f))){
					verticalShift = (Mathf.Atan(XZ / tempCtoM.y) - Mathf.Acos(0.001f));
				}
			}

			float XZupdate = XZ * Mathf.Cos (verticalShift) - tempCtoM.y * Mathf.Sin (verticalShift);

			Vector3 temp2CtoM;
			temp2CtoM.x = tempCtoM.x / XZ * XZupdate;
			temp2CtoM.z = tempCtoM.z / XZ * XZupdate;
			temp2CtoM.y = tempCtoM.y * Mathf.Cos (verticalShift) + XZ * Mathf.Sin (verticalShift);

			currentCharacterToMouse = temp2CtoM;
			offset = currentCharacterToMouse;
			targetCamPos = offset + target.position;
			Quaternion newRotation = Quaternion.LookRotation (- currentCharacterToMouse);
			transform.rotation = newRotation;

		}
			
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);


		//Zoom out  
		if (Input.GetAxis("Mouse ScrollWheel") <0)  
		{  
			if(pcCamera.fieldOfView<=100)  
				pcCamera.fieldOfView +=2f;  
			if(pcCamera.orthographicSize<=20)  
				pcCamera.orthographicSize +=2F;  
		}  
		//Zoom in  
		if (Input.GetAxis("Mouse ScrollWheel") > 0)  
		{  
			if(pcCamera.fieldOfView>2)  
				pcCamera.fieldOfView-=2f;  
			if(pcCamera.orthographicSize>=1)  
				pcCamera.orthographicSize-=2F;  
		}  



//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		RaycastHit floorHit;
//
//		if (Input.GetMouseButtonDown(0)) {
//			inAdjust = true;
//
//			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
//				beginCharacterToMouse = transform.position - target.position;
//				beginFlootHit = floorHit.point - target.position;
//			}
//		}
//
//		if (Input.GetMouseButtonUp(0)) {
//			inAdjust = false;
//		}
//
//		if (inAdjust) {
//
//			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
//				currentFlootHit = floorHit.point - target.position;
//				cuurentCharacterToMouse = (beginFlootHit - currentFlootHit) * 7f + beginCharacterToMouse;
//				//Debug.Log ((beginFlootHit - currentFlootHit).x);
//			}
//				
//			//Debug.Log ("camera adjusting");
//			Vector3 targetCamPos = cuurentCharacterToMouse;
//			Quaternion newRotation = Quaternion.LookRotation (- targetCamPos);
//			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
//			transform.rotation = newRotation;
//		}
	}
}
