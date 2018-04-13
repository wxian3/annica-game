using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float smoothTime = 1f;		// a public variable to adjust smoothing of camera motion
    public float maxSpeed = 50f;        //max speed camera can move
	public Transform desiredPose;			// the desired pose for the camera, specified by a transform in the game
	
    protected Vector3 currentPositionCorrectionVelocity;
    protected Vector3 currentFacingCorrectionVelocity;

	
	void LateUpdate ()
	{

        if (desiredPose != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPose.position, ref currentPositionCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
            transform.forward = Vector3.SmoothDamp(transform.forward, desiredPose.forward, ref currentFacingCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
        }
	}
}
