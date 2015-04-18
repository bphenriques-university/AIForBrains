using UnityEngine;
using System;

public class EnemyFollowLastKnown : ReactiveBehaviour
{
	public ZombieState zombieState;
	public float followLastPositionSpeed = 2.0f;


	GameObject player;
	PlayerHealth playerHealth;
	NavMeshAgent nav;
	GameObject parent;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();

		nav = transform.root.gameObject.GetComponent <NavMeshAgent> ();
		parent = transform.root.gameObject;
	}

	protected override bool IsInSituation ()
	{
		return !zombieState.sensingHuman && !zombieState.arrivedAtTargetPosition;
	}
	
	protected override void Execute ()
	{
		nav.speed = followLastPositionSpeed;
		nav.SetDestination (zombieState.targetPosition);
	}

}

