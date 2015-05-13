using UnityEngine;
using System.Collections;

public class RandomWalkPlanComponent : PlanComponent
{

    private const float WALK_RANGE = 2f;
    private Vector3 newDirection;

    public RandomWalkPlanComponent(HumanState humanState) : base(humanState) {

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
                newDirection = humanState.transform.position + randomDirection;
                return;
            }
        }
    }

    public override bool TryExecuteAction()
    {
        int randomNum = Random.Range (0, 100);
		if (randomNum < 70)
            humanState.actuator.ChangeDestination(newDirection);
        humanState.actuator.Walk();

        if ((humanState.CurrentPosition().position - newDirection).magnitude < 0.5f)
            return true;
        else
            return false;
    }

}
