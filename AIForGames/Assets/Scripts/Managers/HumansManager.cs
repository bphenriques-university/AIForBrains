using UnityEngine;
using UnityEngine.UI;

public class HumansManager : MonoBehaviour
{
	public GameObject spawneeObject;
	public GameObject spawneeLabel;
	public GameObject labels;
	public Transform[] spawnAreas;
	public float radius;
	public int max_number_spawns;

	public string[] agentNames;

	private int nameIndex = 0;


	
	void Start ()
	{
		if (max_number_spawns <= 0)
			return;
		
		int numSpawnsPerArea = max_number_spawns / spawnAreas.Length;
		
		foreach (Transform t in spawnAreas) {
			spawn (t, numSpawnsPerArea);
		}
		
		
		int remainingSpawns = max_number_spawns - (numSpawnsPerArea * spawnAreas.Length);
		spawn(spawnAreas [0], remainingSpawns);
	}



	private void spawn(Transform t, int nTimes) {
		for (int i = 0; i < nTimes; i++) {
			Transform copy = t;
		
			copy.position = t.position + Random.insideUnitSphere * radius;
			Vector3 newPos = copy.position;
			newPos.y = 0;
			copy.position = newPos;
		

			GameObject human = Instantiate (spawneeObject, copy.position, copy.rotation) as GameObject;
			GameObject label = Instantiate (spawneeLabel, copy.position, Quaternion.identity) as GameObject;

			label.transform.SetParent(labels.transform, false);
			label.GetComponent<GUIObjectLabel>().target = human.transform;

			label.GetComponent<Text>().text = agentNames[nameIndex];
			nameIndex = (nameIndex + 1) % agentNames.Length;

			Slider[] sliders = label.GetComponentsInChildren<Slider>();
			human.GetComponent<HumanHealth>().healthSlider = sliders[0];
			human.GetComponent<HumanHunger>().hungerSlider = sliders[1];

			GameOverManager.humansAlive++;
		}
	}

}
