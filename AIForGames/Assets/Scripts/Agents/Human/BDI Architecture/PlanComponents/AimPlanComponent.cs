using UnityEngine;
using System.Collections;

public class AimPlanComponent : PlanComponent
{
	GameObject zombie;
	
	public AimPlanComponent(Human human, GameObject zombie) : base(human){
		this.zombie = zombie;
	}

	public override bool TryExecuteAction ()
	{
		human.Actuators.TurnTo (zombie.transform.position);

		return human.Sensors.IsAimingToObject (zombie);
	}

}

