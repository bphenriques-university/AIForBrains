using UnityEngine;
using System.Collections;

public class EnemyAttack : ReactiveBehaviour
{
	ZombieState zombieState;	

	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

	protected override bool IsInSituation ()
	{
		return zombieState.CanStartToAttack() && zombieState.CanAttack();
	}

	protected override void Execute ()
	{
		zombieState.isAttacking = true;
		zombieState.Attack ();
	}
}