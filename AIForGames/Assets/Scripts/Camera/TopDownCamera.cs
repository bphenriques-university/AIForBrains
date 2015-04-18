using UnityEngine;
using System.Collections;

public class TopDownCamera : CameraBehaviour
{

	public float horizontalSpeed;
	public float horizontalMouseSpeed;

	public float verticalSpeed;
	public float verticalMouseSpeed;

	public float heightSpeed;

	public float cameraRotateSpeed;
	public float cameraDistance;
	public float screenEdgeBoundary;

	public override void setCameraHeight(float height) {
		//no need
	}

	void Update ()
	{
		float h = Input.GetAxisRaw ("HorizontalCamera") * horizontalSpeed * Time.deltaTime;
		float v = Input.GetAxisRaw ("VerticalCamera")* verticalSpeed * Time.deltaTime;
		float height = Input.GetAxisRaw ("HeightCamera")* heightSpeed * Time.deltaTime;
		float rotation = Input.GetAxisRaw ("Rotation") * cameraRotateSpeed * Time.deltaTime;


		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		
		if (Input.mousePosition.x > screenWidth - screenEdgeBoundary)
		{
			h+= horizontalSpeed * Time.deltaTime; // move on +X axis
		}
		
		if (Input.mousePosition.x < 0 + screenEdgeBoundary)
		{
			h-= horizontalSpeed * Time.deltaTime; // move on -X axis
		}
		
		if (Input.mousePosition.y > screenHeight - screenEdgeBoundary)
		{
			v+= verticalSpeed * Time.deltaTime; // move on +Z axis
		}
		
		if (Input.mousePosition.y < 0 + screenEdgeBoundary)
		{
			v-= verticalSpeed * Time.deltaTime; // move on -Z axis
		}



		transform.Translate	(Vector3.forward * v);
		transform.Translate (Vector3.right * h);
		transform.Translate (Vector3.up * height);

		if (rotation != 0) {	
			transform.Rotate (Vector3.up, rotation, Space.World);
		}
	}
}