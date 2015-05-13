using UnityEngine;
using System.Collections;

public class GoToPlanComponent : PlanComponent
{

    private const float MIN_STOPPING_DISTANCE = 0.3f;
    private Vector3 goToPosition;

    public GoToPlanComponent(HumanState humanState, Vector3 goToPosition)
        : base(humanState)
    {
        this.goToPosition = goToPosition;
    }


    public override bool TryExecuteAction()
    {
        humanState.actuator.ChangeDestination(goToPosition);
        humanState.actuator.Walk();
        Vector3 currentPosition = humanState.CurrentPosition().position;
        return ((currentPosition - goToPosition).magnitude < MIN_STOPPING_DISTANCE);
    }
}
