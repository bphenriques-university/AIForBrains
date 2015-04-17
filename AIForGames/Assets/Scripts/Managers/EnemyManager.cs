using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public GameObject enemy;
	public Transform[] spawnAreas;
	public float radius;
	public int max_number_zombies;

	void Start ()
	{

		int numZombiesPerArea = max_number_zombies / spawnAreas.Length;
		print ("numZombiesPerArea = " + numZombiesPerArea);

		int remainingZombies = max_number_zombies - (numZombiesPerArea * spawnAreas.Length);
		Instantiate (enemy, spawnAreas [0].position, spawnAreas [0].rotation);

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
	}
}