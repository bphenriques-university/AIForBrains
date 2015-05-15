using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plan
{
    private IList<PlanComponent> planComponents;
    private Intention topIntention;

    public Plan(IList<PlanComponent> planComponents, IList<Intention> intentions)
    {
        this.planComponents = planComponents;
        if (intentions.Count > 0)
            topIntention = IntentionsManager.getMostDesiredIntention(intentions)[0];
    }

    public bool MakesSense(IList<Intention> intentions, BeliefsManager beliefs)
    {
        if (intentions.Count > 0)
            return topIntention.GetType() == IntentionsManager.getMostDesiredIntention(intentions)[0].GetType();
        return true;
    }

    public int Count()
    {
        return planComponents.Count;
    }

    public PlanComponent Head()
    {
        PlanComponent component = planComponents[0];
        return component;
    }

    public void Pop()
    {
        planComponents.Remove(planComponents[0]);
    }

}
