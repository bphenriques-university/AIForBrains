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
		throw new System.NotImplementedException ();
	}

}

