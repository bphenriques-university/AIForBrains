using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntentionsManager
{

    public IList<Intention> Filter(BeliefsManager beliefs, IList<Desire> desires, IList<Intention> previousIntentions)
    {
        IList<Intention> desiredIntentions = new List<Intention>();
        foreach (Desire desire in desires)
        {
           
            IList<Intention> intentions = desire.GenerateIntentions(beliefs, previousIntentions);
            foreach (Intention intention in intentions)
            {
                Debug.Log("Adding intention " + intention);
            }
            addIntentions(desiredIntentions, intentions);

            foreach (Intention intention in desiredIntentions)
            {
                Debug.Log("Added intention " + intention);
            }
        }

        //foreach (Intention desiredIntention in desiredIntentions)
        //{
        //    if (desiredIntention.Evaluate(beliefs, previousIntentions) == false)
        //    {
        //        desiredIntentions.Remove(desiredIntention);
        //    }
        //}

        //For now let's just return the top intention...
        desiredIntentions = getTopIntention(desiredIntentions);
        return desiredIntentions;
    }

    private IList<Intention> getTopIntention(IList<Intention> desiredIntentions)
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
