using System;
using UnityEngine;

public class HumanAim : ReactiveBehaviour
{
	Human humanState;
	public float distanceToAim = 1f;


	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}	


	
	protected override bool IsInSituation ()
	{

		return humanState.Sensors.SawZombies() && 
				!humanState.IsAimingToZombie(humanState.Sensors.GetClosestZombie()) && 
				(humanState.getDistanceToObject (humanState.Sensors.GetClosestZombie()) > distanceToAim) &&
				humanState.CanShoot();

	}

	protected override void Execute ()
	{
		Vector3 zombiePosition = humanState.Sensors.GetClosestZombie().transform.position;
		humanState.Actuators.Stop ();
		humanState.Actuators.turnTo (zombiePosition);
	}

}


