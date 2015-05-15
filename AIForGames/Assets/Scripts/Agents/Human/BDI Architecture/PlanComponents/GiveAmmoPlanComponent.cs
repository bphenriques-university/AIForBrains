using UnityEngine;
using System.Collections;

public class GiveAmmoPlanComponent : PlanComponent
{
	Human destination;
	int numBulelts = 0;
	public GiveAmmoPlanComponent(Human human, int numBullets)
		: base(human)
	{
		destination = human;
		this.numBulelts = numBulelts;
	}
	
	
	public override bool TryExecuteAction()
	{
		human.Actuators.GiveAmmo(numBulelts);
		
		return true;
	}
}

