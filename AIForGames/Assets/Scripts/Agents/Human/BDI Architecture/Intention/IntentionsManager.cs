using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntentionsManager : MonoBehaviour
{

    public IList<Intention> Filter(BeliefsManager beliefs, IList<Desire> desires, IList<Intention> previousIntentions)
    {
        IList<Intention> desiredIntentions = new List<Intention>();
        foreach (Desire desire in desires)
        {
            IList<Intention> intentions = desire.GenerateIntentions(beliefs, previousIntentions);
            addIntentions(desiredIntentions, intentions);
        }

        foreach (Intention desiredIntention in desiredIntentions)
        {
            if (desiredIntention.Evaluate(beliefs, previousIntentions) == false)
            {
                desiredIntentions.Remove(desiredIntention);
            }
        }

        //For now let's just return the top intention...
        desiredIntentions = getTopIntention(desiredIntentions);

        return desiredIntentions;
    }

    private IList<Intention> getTopIntention(IList<Intention> desiredIntentions)
    {
        
        Intention topIntention;
            topIntention = desiredIntentions[0];

        foreach (Intention intention in desiredIntentions)
        {
            if (intention.IntentValue() > topIntention.IntentValue())
                topIntention = intention;
        }

        IList<Intention> newDesiredIntentions = new List<Intention>();
        if (topIntention != null)
            newDesiredIntentions.Add(topIntention);

        return newDesiredIntentions;
    }

    private void addIntentions(IList<Intention> desiredIntentions, IList<Intention> intentions)
    {
        foreach (Intention intention in intentions)
        {
            foreach (Intention desiredIntention in desiredIntentions)
            {
                if (intention.GetType() == desiredIntention.GetType())
                {
                    desiredIntention.IncreaseIntentionNumber(intention.IntentValue());
                }
                else
                {
                    desiredIntentions.Add(intention);
                }
            }
        }
    }


}
