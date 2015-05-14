using UnityEngine;
using System.Collections;

public class WalkToPlanComponent : PlanComponent
{

    private const float MIN_STOPPING_DISTANCE = 0.3f;
    private Vector3 goToPosition;

    public WalkToPlanComponent(Human humanState, Vector3 goToPosition)
        : base(humanState)
    {
        this.goToPosition = goToPosition;
    }


    public override bool TryExecuteAction()
    {
        humanState.Actuators.ChangeDestination(goToPosition);
        humanState.Actuators.Walk();
        Vector3 currentPosition = humanState.CurrentPosition().position;
        return ((currentPosition - goToPosition).magnitude < MIN_STOPPING_DISTANCE);
    }
}
