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

	//private float bumperDistanceCheck = 100f; // length of bumper ray
	private float bumperCameraHeight = 1.0f; // adjust camera height while bumping
	private Vector3 bumperRayOffset; // allows offset of the bumper ray from target origin
	//private float damping = 5.0f;
	//private float distance = 3.0f;
	//private float height = 1.0f;



	void Awake() {
		pcCamera = GetComponent<Camera> ();
		if (pcCamera != null) {
			// Debug.Log ("get pc camera!");
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
			if (verticalShift > (Mathf.Atan (XZ / tempCtoM.y) - Mathf.Acos (0.99f))) {
				verticalShift = (Mathf.Atan (XZ / tempCtoM.y) - Mathf.Acos (0.99f));
			} else if (verticalShift < 0f) {
				if (verticalShift < (Mathf.Atan(XZ / tempCtoM.y) - Mathf.Acos(0.1f))){
					verticalShift = (Mathf.Atan(XZ / tempCtoM.y) - Mathf.Acos(0.1f));
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





//
//		//automatically zoom in part
//		Vector3 wantedPosition = targetCamPos;
//		bool frozen = false;
//
//		// check to see if there is anything behind the target
//		RaycastHit hit;
//		Vector3 back = transform.TransformDirection(offset); 
//
//		// cast the bumper ray out from rear and check to see if there is anything behind
//		if (Physics.Raycast(target.position, back, out hit) && hit.transform != target) // ignore ray-casts that hit the user. DR
//		{
//			Vector3 vec1 = targetCamPos - target.position;
//			Vector3 vec2 = hit.point - target.position;
//			float len1squ = Mathf.Pow (vec1.x, 2) + Mathf.Pow (vec1.y, 2) + Mathf.Pow (vec1.z, 2);
//			float len2squ = Mathf.Pow (vec2.x, 2) + Mathf.Pow (vec2.y, 2) + Mathf.Pow (vec2.z, 2);
//			if (len1squ > len2squ) {
//				// clamp wanted position to hit position
//				//frozen = true;
//				Debug.Log("camera hits something");
//				Debug.Log ("long: " + vec1 + " short: " + vec2);
//				wantedPosition.x = hit.point.x;
//				wantedPosition.z = hit.point.z;
//				wantedPosition.y = hit.point.y;
//				wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * smoothing);
//			}
//		} 
//			
//		//Debug.Log ("wanted: " + hit.point + ", origin: " + targetCamPos);
//		//transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothing * Time.deltaTime);
//
//



//		//without automatically zoom in, use this
//		if (frozen == false) {
//			
//		}

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);








		//Zoom out  
		if (Input.GetAxis("Mouse ScrollWheel") <0)  
		{  
			if(pcCamera.fieldOfView<=60)  
				pcCamera.fieldOfView +=2f;  
			if(pcCamera.orthographicSize<=20)  
				pcCamera.orthographicSize +=2F;  
		}  
		//Zoom in  
		if (Input.GetAxis("Mouse ScrollWheel") > 0)  
		{  
			if(pcCamera.fieldOfView>10)  
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
