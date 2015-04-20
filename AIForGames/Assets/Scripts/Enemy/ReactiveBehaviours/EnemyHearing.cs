using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : ReactiveBehaviour 
{
	ZombieState zombieState;
	Transform lastHeardPosition;

	void Awake(){
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

	public void HeardShot(Transform from){

		Vector3 targetDistance = zombieState.targetPosition - transform.position;
		Vector3 fromDistance = from.position - transform.position;

		if (fromDistance.sqrMagnitude < targetDistance.sqrMagnitude) {

			zombieState.hearing = true;
			lastHeardPosition = from;
			zombieState.targetPosition = from.position;
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			HumanShooting shoot = other.gameObject.GetComponentInChildren<HumanShooting>();
			shoot.addEnemyAbleToHear(this);
		}
	}

	void OnTriggerStay(Collider other){
		OnTriggerEnter (other);
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			HumanShooting shoot = other.gameObject.GetComponentInChildren<HumanShooting>();
			shoot.removeEnemyAbleToHear(this);
		}
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