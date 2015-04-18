using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : ReactiveBehaviour 
{
	public ZombieState zombieState;
	public float zombieSpeed = 2.5f;


	GameObject parent;
	NavMeshAgent nav;

	void Awake(){
		parent = transform.root.gameObject;
		nav = transform.root.gameObject.GetComponent <NavMeshAgent> ();
	}

	void HeardShot(GameObject from){
		print ("HeardShot!");
		zombieState.hearing = true;
		zombieState.targetPosition = from.transform.position;
	}

	protected override bool IsInSituation ()
	{
		return zombieState.hearing;
	}
	
	protected override void Execute ()
	{
		nav.speed = zombieSpeed;
		nav.SetDestination (zombieState.targetPosition);
		zombieState.hearing = false;
	}
}