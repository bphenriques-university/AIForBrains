using UnityEngine;
using System.Collections;

public class EnemyLeave : ReactiveBehaviour
{
	ZombieState zombieState;	
	
	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}
	

	
	protected override bool IsInSituation ()
	{
		return zombieState.IsTargetDead();
	}
	
	protected override void Execute ()
	{
		zombieState.UnFollowTarget();
	}
	
}