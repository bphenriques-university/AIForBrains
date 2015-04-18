using UnityEngine;
using System.Collections;

public class ReleaseEscape : MonoBehaviour {

	public float timeUntilEscape = 40f;
	public GameObject escapeObstacle;
	public float obstacleSize = 2f;

	Vector3 finalObstaclePosition;

	// Use this for initialization
	void Start () {
		finalObstaclePosition = escapeObstacle.transform.position + escapeObstacle.transform.right * obstacleSize;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilEscape -= Time.deltaTime;
		if (timeUntilEscape < 0) {
			moveObstacle();
		}



	}

	void OnTriggerEnter (Collider other)
	{
		GameObject go = other.gameObject;
		if(go.tag == "Human" || go.tag == "Player")
		{

			Object.Destroy(go);
		}
	}

	void moveObstacle() {
		escapeObstacle.transform.position = Vector3.Lerp (escapeObstacle.transform.position, finalObstaclePosition, Time.deltaTime);
	}
}
