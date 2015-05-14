using System;
using UnityEngine;

public class HumanAim : ReactiveBehaviour
{
	Human human;
	public float distanceToAim = 1f;


	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}	


	
	protected override bool IsInSituation ()
	{

		return human.Sensors.SawZombies() && 
				!human.Sensors.IsAimingToZombie(human.Sensors.GetClosestZombie()) && 
				(human.Sensors.GetDistanceToObject (human.Sensors.GetClosestZombie()) > distanceToAim) &&
				human.Sensors.CanShoot();

	}

	protected override void Execute ()
	{
		Vector3 zombiePosition = human.Sensors.GetClosestZombie().transform.position;
		human.Actuators.Stop ();
		human.Actuators.turnTo (zombiePosition);
	}

}


