using UnityEngine;
using System.Collections;

public class NotifyExitPlanComponent : PlanComponent
{

    GameObject exit;

    public NotifyExitPlanComponent(Human human, GameObject exit)
        : base(human)
    {
        this.exit = exit;
    }

    public override bool TryExecuteAction()
    {
        human.Actuators.SayExit(exit);
        return true;
    }
}
