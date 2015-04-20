using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReleaseEscape : MonoBehaviour {

	public float timeUntilEscape = 40f;
	public GameObject escapeObstacle;
	public float obstacleSize = 2f;

	public Text HumansEscaped;

	Vector3 finalObstaclePosition;

	void Start () {
		finalObstaclePosition = escapeObstacle.transform.position + escapeObstacle.transform.right * obstacleSize * 2.0f;
	}
	
	void Update () {
		timeUntilEscape -= Time.deltaTime;
		if (timeUntilEscape < 0) {
			moveObstacle();
		}

		HumansEscaped.text = GameOverManager.humansAlive + " Remaining";
	}

	void OnTriggerEnter (Collider other)
	{
		GameObject go = other.gameObject;
		if(go.tag == "Human" || go.tag == "Player")
		{
			GameOverManager.humansAlive--;
			Object.Destroy(go);
		}
	}

	void moveObstacle() {
		escapeObstacle.transform.position = Vector3.Lerp (escapeObstacle.transform.position, finalObstaclePosition, Time.deltaTime);
	}
}