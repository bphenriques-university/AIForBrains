using UnityEngine;
using System.Collections;

public class EnemyAttack : ReactiveBehaviour
{
	ZombieState zombieState;	
	GameObject player;

	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			zombieState.targetObjectInRangeToAttack = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			zombieState.targetObjectInRangeToAttack = false;
		}
	}

	protected override bool IsInSituation ()
	{
		return zombieState.CanAttack();
	}

	protected override void Execute ()
	{
		zombieState.Attack ();
	}
	
	

}