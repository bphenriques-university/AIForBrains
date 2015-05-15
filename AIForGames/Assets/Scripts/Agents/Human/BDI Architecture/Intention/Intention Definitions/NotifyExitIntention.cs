using UnityEngine;
using System.Collections.Generic;

public class NotifyExitIntention : Intention
{
    public NotifyExitIntention(float desireLevel) : base(desireLevel) { 
        //FIXME
    }

    public override bool Evaluate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
        if (beliefs.GetSightBelief().SawExit() || beliefs.GetMemoryBelief().GetExit() != null)
        {
            intentValue = 100f;
            return true;
        }
        else
            return false;
    }

    public override IList<PlanComponent> GivePlanComponents(Human human, BeliefsManager beliefs)
    {
        IList<PlanComponent> plan = new List<PlanComponent>();
        GameObject exit;
        if (beliefs.GetSightBelief().SawExit())
            exit = beliefs.GetSightBelief().GetExitSeen();
        else 
            exit = beliefs.GetMemoryBelief().GetExit();

        if (exit != null) {
            plan.Add(new NotifyExitPlanComponent(human, exit));
        }
            
       
        return plan;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return true;
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        return false;
    }
}
