using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : ReactiveBehaviour 
{
	ZombieState zombieState;

	void Awake(){
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

	void HeardShot(GameObject from){
		print ("HeardShot!");
		zombieState.hearing = true;
		zombieState.targetPosition = from.transform.position;

	}

	protected override bool IsInSituation ()
	{
		return zombieState.DidHeardHuman();
	}
	
	protected override void Execute ()
	{
		zombieState.GoToHeardDirection ();
		zombieState.hearing = false;
	}
}