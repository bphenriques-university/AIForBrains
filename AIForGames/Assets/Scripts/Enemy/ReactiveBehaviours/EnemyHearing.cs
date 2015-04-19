using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : ReactiveBehaviour 
{
	ZombieState zombieState;

	void Awake(){
		zombieState = transform.root.GetComponent <ZombieState> ();
	}

	public void HeardShot(Transform from){
		zombieState.hearing = true;
		zombieState.targetPosition = from.position;

	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			HumanShooting shoot = other.gameObject.GetComponentInChildren<HumanShooting>();
			shoot.addEnemyAbleToHear(this);
		}
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