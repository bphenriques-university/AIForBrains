using UnityEngine;
using System.Collections;

public class EnemyGrabHuman : ReactiveBehaviour
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
			zombieState.targetInRangeToGrab = true;
			zombieState.isAttacking = true;
			zombieState.targetObject = other.gameObject;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			zombieState.targetInRangeToGrab = false;
			zombieState.isAttacking = false;
			zombieState.Leave();
		}
	}
	
	protected override bool IsInSituation ()
	{
		return zombieState.CanGrab();
	}
	
	protected override void Execute ()
	{
		print ("GRABBING HUMAN!");
		zombieState.Grab ();
	}
	
}