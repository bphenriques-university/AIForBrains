using UnityEngine;
using System.Collections;

public class GoToPlanComponent : PlanComponent
{

    private const float MIN_STOPPING_DISTANCE = 0.3f;
    private Transform goToPosition;

    public GoToPlanComponent(HumanState humanState, Transform goToPosition)
        : base(humanState)
    {
        this.goToPosition = goToPosition;
    }


    public override bool TryExecuteAction()
    {
        humanState.actuator.ChangeDestination(goToPosition.position);
        Vector3 currentPosition = humanState.CurrentPosition().position;
        return ((currentPosition - goToPosition.position).magnitude < MIN_STOPPING_DISTANCE);
    }
}
