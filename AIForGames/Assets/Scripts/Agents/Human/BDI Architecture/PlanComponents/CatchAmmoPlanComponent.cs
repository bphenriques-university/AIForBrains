using UnityEngine;
using System.Collections;

public class CatchAmmoPlanComponent : PlanComponent
{
	
	private Ammo ammoToBeCaught;
	
	public CatchAmmoPlanComponent(Human humanState, Ammo desiredAmmo)
		: base(humanState)
	{
		this.ammoToBeCaught = desiredAmmo;
	}
	
	
	public override bool TryExecuteAction()
	{
		float lastAmmoLevel = humanState.Sensors.AmmoLevel();

        humanState.Actuators.GrabAmmo(ammoToBeCaught);

        return lastAmmoLevel < humanState.Sensors.AmmoLevel();	
	}
}

