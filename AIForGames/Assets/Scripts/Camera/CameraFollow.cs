using UnityEngine;
using System.Collections;

public class CameraFollow : CameraBehaviour
{
	public Transform target;            // The position that that camera will be following.
	public float smoothing = 5f;        // The speed with which the camera will be following.
	public float rotateSmoothing = 0.1f;        // The speed with which the camera will be reseting rotation.
	public float xOffset = 0f;
	public float zOffset = -4f;


	Vector3 offset;                     // The initial offset from the target.
	Quaternion initialRotation;

	void Awake () {
		initialRotation= transform.rotation;
		// Calculate the initial offset.
		offset.x = target.position.x + xOffset;
		offset.y = target.position.y + transform.position.y;
		offset.z = target.position.z + zOffset;
	}

	
	void FixedUpdate ()
	{
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = target.position + offset;
		
		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.time * rotateSmoothing); 
	}
}