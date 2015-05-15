using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planner
{
    private const float MAX_WALK_DISTANCE = 2f;

    private Human humanState;

    public Planner(Human humanState)
    {
        this.humanState = humanState;
    }

    public Plan GeneratePlan(BeliefsManager beliefs, IList<Intention> intentions)
    {

        List<PlanComponent> newPlan = new List<PlanComponent>();
        foreach (Intention intention in intentions)
        {
            newPlan.AddRange(intention.GivePlanComponents(humanState, beliefs));
        }
        
        Debug.Log("GENERATING PLAN");
        return new Plan(newPlan);
    }


    public static IList<PlanComponent> CreateWalkPath(Human human, Vector3 currentPosition, Vector3 destinationPosition)
    {

        List<PlanComponent> plan = new List<PlanComponent>();
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(currentPosition, destinationPosition, NavMesh.AllAreas, path);

        Vector3[] pathCorners = path.corners;
        for (int i = 1; i < pathCorners.Length; i++ )
        {
            Vector3 corner = pathCorners[i];

            Vector3 position = currentPosition;
            plan.AddRange(CreateStraightWalkPath(human, position, corner));
            position = corner;
        }

        return plan;
    }

    public static IList<PlanComponent> CreateStraightWalkPath (Human human, Vector3 currentPosition, Vector3 destinationPosition) {

        IList<PlanComponent> plan = new List<PlanComponent>();

        Vector3 direction = (destinationPosition - currentPosition).normalized;

        float distance = (destinationPosition - currentPosition).magnitude;
        float steps =  Mathf.Ceil(distance/MAX_WALK_DISTANCE);


        Vector3 position = currentPosition;

        for (int i = 0; i < steps; i++)
        {
            if (i - 1 == steps)
            {
                plan.Add(new WalkToPlanComponent(human, destinationPosition));
            }
            else
            {
                Vector3 newDestination = position + direction * MAX_WALK_DISTANCE;
                plan.Add(new WalkToPlanComponent(human, newDestination));
                position = newDestination;
            }
        }

        return plan;

    }


}
