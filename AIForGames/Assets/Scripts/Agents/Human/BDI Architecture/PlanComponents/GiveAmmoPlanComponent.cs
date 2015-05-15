using UnityEngine;
using System.Collections;

public class GiveAmmoPlanComponent : PlanComponent
{
	Human destination;
	int numBullets = 0;
	public GiveAmmoPlanComponent(Human human, int numBullets)
		: base(human)
	{
		destination = human;
		this.numBullets = numBullets;
	}
	
	
	public override bool TryExecuteAction()
	{
		human.Actuators.GiveAmmo(human, numBullets);
		
		return true;
	}
}

