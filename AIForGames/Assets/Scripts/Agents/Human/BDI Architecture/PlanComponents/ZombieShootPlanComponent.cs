using UnityEngine;

public class ZombieShootPlanComponent : PlanComponent
{
	GameObject zombie;

	public ZombieShootPlanComponent(Human human, GameObject zombie) : base(human){
		this.zombie = zombie;
	}

	public override bool TryExecuteAction ()
	{
		int ammoBefore = human.Sensors.AmmoLevel ();
        human.Actuators.TurnTo(zombie.transform.position);
		human.Actuators.FireWeapon ();

		return ammoBefore == human.Sensors.AmmoLevel () + 1;
	}


}
