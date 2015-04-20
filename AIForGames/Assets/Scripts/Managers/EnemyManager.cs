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

		int numSpawnsPerArea = max_number_spawns / spawnAreas.Length;

		foreach (Transform t in spawnAreas) {
			for(int i = 0; i < numSpawnsPerArea ; i++){

				Transform copy = t;

				copy.position = t.position + Random.insideUnitSphere * radius;
				Vector3 newPos = copy.position;
				newPos.y = 0;
				copy.position = newPos;

				print (spawneeObjects.Length);
				int randomNumber = Random.Range (0, spawneeObjects.Length);

				Instantiate (spawneeObjects[randomNumber], copy.position, copy.rotation);
			}
		}


		int remainingSpawns = max_number_spawns - (numSpawnsPerArea * spawnAreas.Length);

		int spawnArea = 0;
		while (remainingSpawns > 0) {
			remainingSpawns--;

			Transform copy = spawnAreas [++spawnArea % spawnAreas.Length];
			
			copy.position = copy.position + Random.insideUnitSphere * radius;
			Vector3 newPos = copy.position;
			newPos.y = 0;
			copy.position = newPos;
			
			int randomNumber = Random.Range (0, spawneeObjects.Length);
			Instantiate (spawneeObjects[randomNumber], copy.position, copy.rotation);
		
		}
	}
}