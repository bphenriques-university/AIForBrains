using System;
using UnityEngine;
using System.Collections;

public class EnemySmell : ReactiveBehaviour
{
	ZombieState zombieState;

	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}


	protected override bool IsInSituation ()
	{
		return zombieState.IsSmellingHuman();
	}
	
	protected override void Execute ()
	{
		zombieState.FollowTargetObject ();
	}

	void OnTriggerEnter (Collider other)
	{
		//will change this to collider
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			print ("Smelled delicious human");
			zombieState.smelling = true;
			zombieState.targetObject = other.gameObject;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			print ("Not smelling delicious human");
			zombieState.smelling = false;
			zombieState.targetPosition = other.gameObject.transform.position;
		}
	}
}