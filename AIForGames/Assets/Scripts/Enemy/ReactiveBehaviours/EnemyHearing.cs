using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : ReactiveBehaviour 
{
	public ZombieState zombieState;

	GameObject player;
	bool heardSound = false;
	NavMeshAgent nav;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = this.transform.parent.gameObject.GetComponent <NavMeshAgent> ();
	}

	void heardShot(GameObject from){
		print ("HeardShot!");
		heardSound = true;
		zombieState.lastKnownObject = from;
	}

	
	
	protected override bool IsInSituation ()
	{
		return heardSound;
	}
	
	protected override void Execute ()
	{
		nav.SetDestination (zombieState.lastKnownObject.transform.position);
	}
}