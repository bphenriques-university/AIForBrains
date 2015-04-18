using UnityEngine;
using System.Collections;

public class GUIObjectLabel : MonoBehaviour {
	
	public Transform target;  // Object that this label should follow
	public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
	public bool useMainCamera = true;   // Use the camera tagged MainCamera
	public Camera cameraToUse ;   // Only use this if useMainCamera is false
	Camera cam ;
	Transform thisTransform;
	
	void Start () 
	{
		thisTransform = transform;
		if (useMainCamera)
			cam = Camera.main;
		else
			cam = cameraToUse;
	}
	
	
	void Update()
	{
			thisTransform.position = cam.WorldToScreenPoint(target.position + offset);
	}
}