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
			HumanHealth hp = other.gameObject.GetComponent<HumanHealth>();
			if (!hp.isHumanDead()) {
				zombieState.smelling = true;
				zombieState.targetObject = other.gameObject;
				zombieState.targetObjectHP = hp;
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{

			zombieState.smelling = false;
			zombieState.targetPosition = other.gameObject.transform.position;
			zombieState.targetObjectHP = null;
		

		}
	}
}