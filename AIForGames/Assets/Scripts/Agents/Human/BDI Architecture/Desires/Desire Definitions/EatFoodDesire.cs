using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EatFoodDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        desireLevel = 100f - beliefs.GetHungerBelief().GetFoodLevel();
    }


    public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        IList<Intention> desiredIntentions = new List<Intention>();
        IList<Food> carriedFoods = beliefs.GetInventoryBelief().Foods();
        if (carriedFoods.Count > 0)
        {
            EatFoodIntention intention = new EatFoodIntention(carriedFoods[0], desireLevel);
            desiredIntentions.Add(intention);
        }
        else {
            if (beliefs.GetSightBelief().SawFood())
            {
                //TODO - FIX this hack
                EatFoodIntention intention = new EatFoodIntention(beliefs.GetSightBelief().FoodSeen()[0], desireLevel);
                desiredIntentions.Add(intention);
            }
        }


        return desiredIntentions;
    }
}
