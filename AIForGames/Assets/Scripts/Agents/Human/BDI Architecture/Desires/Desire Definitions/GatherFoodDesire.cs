using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GatherFoodDesire : Desire
{

    private const float BASE_DESIRE_LEVEL = 10f;

    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        desireLevel = BASE_DESIRE_LEVEL - (beliefs.GetInventoryBelief().Foods().Count * 10);
    }

    public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        IList<Intention> desiredIntentions = new List<Intention>();

        if (beliefs.GetSightBelief().SawFood())
        {
            desiredIntentions.Add(new GatherFoodIntention(desireLevel, beliefs.GetSightBelief().GetFoodSeen()));
        }
        else
        {
            desiredIntentions.Add(new LookForFoodIntention(desireLevel));
        }

        return desiredIntentions;
    }
}
