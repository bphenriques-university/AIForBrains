using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIObjectLabel : MonoBehaviour {
	
	public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
	public bool useMainCamera = true;   // Use the camera tagged MainCamera
	public Camera cameraToUse ;   // Only use this if useMainCamera is false

	Camera cam ;
	Transform target;  // Object that this label should follow
	Transform thisTransform;


	void Awake(){
		target = transform.root.GetComponent<Transform> ();
	}

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