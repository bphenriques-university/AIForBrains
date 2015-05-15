using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GatherAmmunitionDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		desireLevel = 70/ (1.0f + beliefs.GetInventoryBelief ().AmmoLevel());
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		IList<Intention> desiredIntentions = new List<Intention>();

				
        //if (beliefs.GetSightBelief().SawAmmo())
        //    desiredIntentions.Add (new GatherAmmunitionIntention(desireLevel, beliefs.GetSightBelief()));
		
		return desiredIntentions;

    }
}
