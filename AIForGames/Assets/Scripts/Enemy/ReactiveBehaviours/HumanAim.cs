using System;
using UnityEngine;

public class HumanAim : ReactiveBehaviour
{
	HumanState humanState;
	public float distanceToAim = 0.79f;


	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}	


	
	protected override bool IsInSituation ()
	{

		return (humanState.getDistanceToZombie () > distanceToAim) && humanState.IsSeeingZombie() && humanState.CanShoot();

	}

	protected override void Execute ()
	{
		GameObject zombie = humanState.zombieSeen;

		Vector3 zombiePosition = zombie.transform.position;
		humanState.turnTo (zombiePosition);

	}

}


