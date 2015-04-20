using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public GameObject[] spawneeObjects;
	public Transform[] spawnAreas;
	public float radius;
	public int max_number_spawns;

	void Start ()
	{
		if (max_number_spawns <= 0)
			return;
	
		while (max_number_spawns > 0) {
			max_number_spawns--;

			Transform copy = spawnAreas [Random.Range(0, spawnAreas.Length)];
			
			copy.position = copy.position + Random.insideUnitSphere * radius;
			Vector3 newPos = copy.position;
			newPos.y = 0;
			copy.position = newPos;
			
			int randomNumber = Random.Range (0, spawneeObjects.Length);
			Instantiate (spawneeObjects[randomNumber], copy.position, copy.rotation);
		}
	}
}