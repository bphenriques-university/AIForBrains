using UnityEngine;
using System.Collections;

public class RandomWalkPlanComponent : PlanComponent
{

    private const float WALK_RANGE = 2f;

    public RandomWalkPlanComponent(HumanState humanState) : base(humanState) { }

    public override bool TryExecuteAction()
    {
        humanState.actuator.Walk();
        changeDirection();

        return true;
    }

    private void changeDirection()
    {
        while (true)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            randomDirection.y = 0;
            randomDirection.Normalize();

            Ray shootRay = new Ray();
            RaycastHit shootHit;

            shootRay.origin = humanState.transform.position;
            shootRay.direction = randomDirection;


            if (Physics.Raycast(shootRay, out shootHit, 0.5f))
            {
                continue;
            }
            else
            {
                randomDirection *= WALK_RANGE;
                humanState.actuator.ChangeDestination(humanState.transform.position + randomDirection);
                return;
            }
        }
    }
}
