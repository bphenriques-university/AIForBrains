using UnityEngine;
using System.Collections;

public class CatchAmmoPlanComponent : PlanComponent
{
	
	private Ammo ammoToBeCaught;
	
	public CatchAmmoPlanComponent(Human human, Ammo desiredAmmo)
		: base(human)
	{
		this.ammoToBeCaught = desiredAmmo;
	}
	
	
	public override bool TryExecuteAction()
	{
		float lastAmmoLevel = human.Sensors.AmmoLevel();

        human.Actuators.GrabAmmo(ammoToBeCaught);

        return lastAmmoLevel < human.Sensors.AmmoLevel();	
	}
}

