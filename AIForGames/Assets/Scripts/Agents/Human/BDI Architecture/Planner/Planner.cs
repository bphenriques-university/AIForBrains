using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planner
{
    private HumanState humanState;

    public Planner(HumanState humanState)
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


}
