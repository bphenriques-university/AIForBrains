using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchForExitIntention : Intention
{

    private const float SEARCH_RADIUS = 10f;

    public SearchForExitIntention(float desiredIntentLevel) : base(desiredIntentLevel) {}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        intentValue = 0f;
        return !beliefs.GetSightBelief().SawExit();
    }

    public override IList<PlanComponent> GivePlanComponents(Human human, BeliefsManager beliefs)
    {
        List<PlanComponent> plan = new List<PlanComponent> ();

        Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition().position;
        Vector3 randomPosition = beliefs.GetNavigationBelief().HumanNavMap().GetRandomUnvisitedPosition(currentPosition, SEARCH_RADIUS);
        plan.AddRange(Planner.CreateWalkPath(human, currentPosition, randomPosition));
        return plan;

    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return beliefs.GetSightBelief().SawExit();
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        return beliefs.GetSightBelief().SawExit();
    }

    public override bool IsImportant()
    {
        return false;
    }
}
