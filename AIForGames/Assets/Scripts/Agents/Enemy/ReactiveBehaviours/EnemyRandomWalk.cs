using UnityEngine;
using System.Collections;

public class EnemyRandomWalk : ReactiveBehaviour
{
	ZombieState zombieState;

	void Awake(){
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

	protected override bool IsInSituation ()
	{
		return !zombieState.IsSensingHuman() && zombieState.DidArrivedAtTargetPosition();
	}
	
	protected override void Execute ()
	{
		zombieState.RandomWalk ();
	}


}