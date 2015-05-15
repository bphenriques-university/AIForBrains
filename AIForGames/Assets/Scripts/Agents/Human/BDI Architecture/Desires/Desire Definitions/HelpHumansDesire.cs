using UnityEngine;
using System.Collections;

public class HelpHumansDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		HearingBelief hearing = beliefs.GetHearingBelief ();
		if (hearing.GetMessageLog ().Count > 0)
			desireLevel = 50;
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
        throw new System.NotImplementedException();
    }
}
