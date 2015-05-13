using UnityEngine;
using System.Collections;

public class CatchAmmoPlanComponent : PlanComponent
{
	
	private Ammo ammoToBeCaught;
	
	public CatchAmmoPlanComponent(HumanState humanState, Ammo desiredAmmo)
		: base(humanState)
	{
		this.ammoToBeCaught = desiredAmmo;
	}
	
	
	public override bool TryExecuteAction()
	{
		float lastAmmoLevel = humanState.AmmoLevel();

		humanState.actuator.GrabAmmo();

		return lastAmmoLevel < humanState.AmmoLevel();	
	}
}

