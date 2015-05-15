using UnityEngine;
using System.Collections;

public class WalkToPlanComponent : PlanComponent
{

    private const float MIN_STOPPING_DISTANCE = 0.3f;
    private Vector3 goToPosition;

    public WalkToPlanComponent(Human human, Vector3 goToPosition)
        : base(human)
    {
        this.goToPosition = goToPosition;
    }


    public override bool TryExecuteAction()
    {
        human.Actuators.ChangeDestination(goToPosition);
        human.Actuators.Walk();
        Vector3 currentPosition = human.Sensors.CurrentPosition().position;

        return ((currentPosition - goToPosition).magnitude < MIN_STOPPING_DISTANCE);
    }
}
