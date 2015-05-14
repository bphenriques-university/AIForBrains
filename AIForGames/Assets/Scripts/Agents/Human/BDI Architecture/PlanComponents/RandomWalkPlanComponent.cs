using UnityEngine;
using System.Collections;

public class RandomWalkPlanComponent : PlanComponent
{

    private const float MIN_STOPPING_DISTANCE = 0.1f;
    private const float WALK_RANGE = 2f;
    private const float KEEP_DIRECTION_CHANCE = 70f;
    private Vector3 newDirection;

    public RandomWalkPlanComponent(Human humanState) : base(humanState) {

        
        while (true)
        {
            Vector3 direction;
            int randomNum = Random.Range(0, 100);
            if (randomNum < KEEP_DIRECTION_CHANCE)
            {
                Transform currentPosition = humanState.CurrentPosition();
                direction = currentPosition.forward;
            }
            else
            {
                direction = Random.onUnitSphere;
                direction.y = 0;
            }

            NavMeshHit navHit;

            direction.Normalize();
            direction *= WALK_RANGE;
            newDirection = humanState.transform.position + direction;

            if (NavMesh.FindClosestEdge(newDirection, out navHit, NavMesh.AllAreas))
            {
                if (navHit.distance < 1.0f)
                    continue;
                else
                    return;
            }
            else
            {
                continue;
            }
        }   
    }

    public override bool TryExecuteAction()
    {
        
        humanState.Actuators.ChangeDestination(newDirection);
        humanState.Actuators.Walk();

        if ((humanState.CurrentPosition().position - newDirection).magnitude < MIN_STOPPING_DISTANCE)
            return true;
        else
            return false;
    }

}
