using UnityEngine;
using System.Collections;

public class EnemyAttack : ReactiveBehaviour
{
	ZombieState zombieState;	

	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			zombieState.targetObjectInRangeToAttack = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
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