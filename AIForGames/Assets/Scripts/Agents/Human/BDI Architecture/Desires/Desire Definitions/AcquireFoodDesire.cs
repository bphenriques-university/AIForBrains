using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AcquireFoodDesire : Desire
{


    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        //TODO
    }

    public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        throw new System.NotImplementedException();
    }
}
