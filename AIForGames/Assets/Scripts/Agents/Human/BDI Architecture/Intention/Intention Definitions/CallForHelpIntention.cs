using UnityEngine;
using System.Collections.Generic;

public class CallForHelpIntention : Intention
{
    HumanSpeak.Message m;

    public CallForHelpIntention(HumanSpeak.Message m, float desireLevel) : base(desireLevel) {
        this.m = m;
    }

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (m == HumanSpeak.Message.NeedFood)
        {
            desiredIntentValue = (100f - beliefs.GetHungerBelief().GetFoodLevel())/2;
        }
        else if (m == HumanSpeak.Message.NeedAmmo)
        {
            desiredIntentValue = (50f - beliefs.GetInventoryBelief().AmmoLevel());
        }
        else if (m == HumanSpeak.Message.IAmGrabbed)
        {
            desiredIntentValue = 50f;
        }
        else if (m == HumanSpeak.Message.ExitIsOpen)
        {
            desiredIntentValue = 50f;
        }

        return true;
    }

    public override IList<PlanComponent> GivePlanComponents(Human me, BeliefsManager beliefs)
    {
        List<PlanComponent> plan = new List<PlanComponent>();

        plan.Add(new ShoutForHelpPlanComponent(me ,m));

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
