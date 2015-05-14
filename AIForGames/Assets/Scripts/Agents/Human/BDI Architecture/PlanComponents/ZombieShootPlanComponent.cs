using UnityEngine;

public class ZombieShootPlanComponent : PlanComponent
{
	GameObject zombie;

	public ZombieShootPlanComponent(Human human, GameObject zombie) : base(human){
		this.zombie = zombie;
	}

	public override bool TryExecuteAction ()
	{
		throw new System.NotImplementedException ();
	}


}
