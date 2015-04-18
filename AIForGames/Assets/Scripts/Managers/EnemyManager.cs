using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
	public GameObject spawneeObject;
	public Transform[] spawnAreas;
	public float radius;
	public int max_number_spawns;

	void Start ()
	{
		if (max_number_spawns <= 0)
			return;

		int numSpawnsPerArea = max_number_spawns / spawnAreas.Length;
		print ("numSpawnPerArea = " + numSpawnsPerArea);
	
		
		foreach (Transform t in spawnAreas) {
			for(int i = 0; i < numSpawnsPerArea ; i++){

				Transform copy = t;

				copy.position = t.position + Random.insideUnitSphere * radius;
				Vector3 newPos = copy.position;
				newPos.y = 0;
				copy.position = newPos;

				Instantiate (spawneeObject, copy.position, copy.rotation);
			}
		}


		int remainingSpawns = max_number_spawns - (numSpawnsPerArea * spawnAreas.Length);
		for (int i = 0; i < remainingSpawns; i++) {
			
			Transform copy = spawnAreas [0];
			
			copy.position = copy.position + Random.insideUnitSphere * radius;
			Vector3 newPos = copy.position;
			newPos.y = 0;
			copy.position = newPos;
			
			Instantiate (spawneeObject, copy.position, copy.rotation);
		}
	}
}