using UnityEngine;
using System.Collections.Generic;

public class EscapeDesire : Desire
{

    private const float BASE_DESIRE_LEVEL = 10f;
    private const float SAW_EXIT_DESIRE_LEVEL = 80f;


    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (beliefs.GetSightBelief().SawExit() || beliefs.GetMemoryBelief().GetExit() != null) {
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
        if (beliefs.GetSightBelief().SawExit())
        {
            desiredIntentions.Add(new GoToExitIntention(beliefs.GetSightBelief().GetExitSeen(), desireLevel));
        }
        else if (beliefs.GetMemoryBelief().GetExit() != null)
        {
            desiredIntentions.Add(new GoToExitIntention(beliefs.GetMemoryBelief().GetExit(), desireLevel));
        }
        else if(beliefs.GetHearingBelief().FoundExitMessage()){

            desiredIntentions.Add(new GoToExitIntention(beliefs.GetHearingBelief().GetExit(), desireLevel));
        
        }else
        {
            desiredIntentions.Add(new SearchForExitIntention(desireLevel));
        }

        return desiredIntentions;
        
    }
}
