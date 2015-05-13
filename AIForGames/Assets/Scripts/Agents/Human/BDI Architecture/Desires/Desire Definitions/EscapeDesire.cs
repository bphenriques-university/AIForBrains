using UnityEngine;
using System.Collections.Generic;

public class EscapeDesire : Desire
{

    private const float BASE_DESIRE_LEVEL = 50f;
    private const float SAW_EXIT_DESIRE_LEVEL = 120f;


    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (beliefs.GetSightBelief().SawExit()) {
            desireLevel = SAW_EXIT_DESIRE_LEVEL;
        }
        else
        {
            desireLevel = BASE_DESIRE_LEVEL;
        }
    }

    public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        IList<Intention> desiredIntentions = new List<Intention>();
        //if (beliefs.GetSightBelief().SawExit()) {
        //    desiredIntentions.Add()

        return desiredIntentions;
        
    }
}
