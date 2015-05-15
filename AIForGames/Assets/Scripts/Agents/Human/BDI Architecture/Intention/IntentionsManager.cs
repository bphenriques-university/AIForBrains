using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntentionsManager
{

    public IList<Intention> Filter(BeliefsManager beliefs, IList<Desire> desires, IList<Intention> previousIntentions)
    {
        Debug.Log("Running Filter");
        IList<Intention> desiredIntentions = new List<Intention>();
        foreach (Desire desire in desires)
        {
           
            IList<Intention> intentions = desire.GenerateIntentions(beliefs, previousIntentions);
            addIntentions(desiredIntentions, intentions);
        }

        List<Intention> intentionsToDelete = new List<Intention>();
        foreach (Intention desiredIntention in desiredIntentions)
        {
            if (desiredIntention.Evaluate(beliefs, previousIntentions) == false)
            {
                intentionsToDelete.Add(desiredIntention);
            }

            Debug.Log("Evaluated " + desiredIntention.GetType() + ": " + desiredIntention.IntentValue());
        }

        foreach (Intention intention in intentionsToDelete)
        {
            desiredIntentions.Remove(intention);
        }

        //For now let's just return the top intention...
        desiredIntentions = getMostDesiredIntention(desiredIntentions);
        return desiredIntentions;
    }

    private IList<Intention> getMostDesiredIntention(IList<Intention> desiredIntentions)
    {


        IList<Intention> newDesiredIntentions = new List<Intention>();
        if (desiredIntentions.Count <= 0)
            return newDesiredIntentions;

        Intention topIntention;
            topIntention = desiredIntentions[0];

        foreach (Intention intention in desiredIntentions)
        {
            if (intention.IntentValue() > topIntention.IntentValue())
                topIntention = intention;
        }

        newDesiredIntentions.Add(topIntention);

        return newDesiredIntentions;
    }

    private void addIntentions(IList<Intention> desiredIntentions, IList<Intention> intentions)
    {
        bool repeated = false;
        
        foreach (Intention intention in intentions)
        {
            foreach (Intention desiredIntention in desiredIntentions)
            {
                if (intention.GetType() == desiredIntention.GetType())
                {
                    desiredIntention.IncreaseIntentionNumber(intention.IntentValue());
                    repeated = true;
                }
            }
            if (!repeated)
            {
                desiredIntentions.Add(intention);
            }
            repeated = false;
        }
        
    }


}
