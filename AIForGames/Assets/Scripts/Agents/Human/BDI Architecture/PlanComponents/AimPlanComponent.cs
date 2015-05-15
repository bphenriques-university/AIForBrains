using UnityEngine;
using System.Collections;

public class AimPlanComponent : PlanComponent
{
	GameObject zombie;
    float adjust = 1.0f;
	
	public AimPlanComponent(Human human, GameObject zombie) : base(human){
		this.zombie = zombie;
	}

	public override bool TryExecuteAction ()
	{
        Debug.Log("Aiming to " + zombie.transform.position);

        human.Actuators.Stop();

		human.Actuators.TurnTo (zombie.transform.position + zombie.transform.forward * adjust);


        return true;
	}

}

