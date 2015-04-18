using UnityEngine;
using System.Collections;

public class EnemyRandomWalk : ReactiveBehaviour
{

	public ZombieState zombieState;

	public float randomWalkSpeed = 1.0f;
	public float SecondsUntilRandomPosition = 15;
	public Transform[] spawnPoints;
	
	NavMeshAgent nav;
	GameObject parent;
	
	void Awake ()
	{
		parent = transform.root.gameObject;
		nav = transform.root.gameObject.GetComponent <NavMeshAgent> ();
	}

	protected override bool IsInSituation ()
	{
		return true;
	}
	
	protected override void Execute ()
	{
		Vector3 randomPos = GenerateRandomPosition ();
		zombieState.targetPosition = randomPos;

		nav.SetDestination (zombieState.targetPosition);
		nav.speed = randomWalkSpeed;
	}

	private Vector3 GenerateRandomPosition(){
		int spawnPointIndex = Random.Range (0, spawnPoints.Length - 1);
		return spawnPoints [spawnPointIndex].position;
	}
}