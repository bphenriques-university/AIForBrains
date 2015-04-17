using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public GameObject enemy;
	public Transform[] spawnAreas;
	public float radius;
	public int max_number_zombies;

	void Start ()
	{
		if (max_number_zombies <= 0)
			return;

		int numZombiesPerArea = max_number_zombies / spawnAreas.Length;
		print ("numZombiesPerArea = " + numZombiesPerArea);
	
		
		foreach (Transform t in spawnAreas) {
			for(int i = 0; i < numZombiesPerArea ; i++){

				Transform copy = t;

				copy.position = t.position + Random.insideUnitSphere * radius;
				Vector3 newPos = copy.position;
				newPos.y = 0;
				copy.position = newPos;

				Instantiate (enemy, copy.position, copy.rotation);
			}
		}


		int remainingZombies = max_number_zombies - (numZombiesPerArea * spawnAreas.Length);
		for (int i = 0; i < remainingZombies; i++) {
			
			Transform copy = spawnAreas [0];
			
			copy.position = copy.position + Random.insideUnitSphere * radius;
			Vector3 newPos = copy.position;
			newPos.y = 0;
			copy.position = newPos;
			
			Instantiate (enemy, copy.position, copy.rotation);
		}
	}
}