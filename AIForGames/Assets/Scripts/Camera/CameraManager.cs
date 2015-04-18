using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public CameraBehaviour[] cameras;
	public float timeBetweenCameraChange = 0.1f;

	int cameraSelected = 0;
	float timer = 0f;

	void Start() {
		foreach (CameraBehaviour cam in cameras) {
			cam.enabled = false;
		}

		cameras [cameraSelected].enabled = true;

	}

	// Update is called once per frame
	void Update () {

		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		if (Input.GetButton ("CameraChange") && timer > timeBetweenCameraChange) {
			timer = 0f; 
			cameras[cameraSelected].enabled = false;
			cameraSelected = (cameraSelected + 1) % cameras.Length;
			cameras[cameraSelected].enabled = true;
		}

	}
}
