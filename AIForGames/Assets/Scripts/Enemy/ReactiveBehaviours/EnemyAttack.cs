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
		print ("zombieState.CanStartToAttack() = " + zombieState.CanStartToAttack ());
		return zombieState.CanStartToAttack() && zombieState.CanAttack();
	}

	protected override void Execute ()
	{
		print ("ATTACKING");
		zombieState.isAttacking = true;
		zombieState.Attack ();
	}
}