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
        Vector3 currentPosistion = beliefs.GetNavigationBelief().CurrentPosition().position;


        if (carriedFoods.Count > 0)
        {
            EatFoodIntention intention = new EatFoodIntention(carriedFoods[0], desireLevel);
            desiredIntentions.Add(intention);
        }
        else if (beliefs.GetTouchBelief().IsTouchingFood())
        {
            //FIXME: Dirty hack to compile
            EatFoodIntention intention = new EatFoodIntention(beliefs.GetTouchBelief().GetTouchingFood(), desireLevel);
            desiredIntentions.Add(intention);
        }
        else if (beliefs.GetSightBelief().SawFood())
     	{
			//FIXME: Dirty hack to compile
			EatFoodIntention intention = new EatFoodIntention(beliefs.GetSightBelief().GetClosestFood(), desireLevel);
            desiredIntentions.Add(intention);
        }
        else if (beliefs.GetMemoryBelief().RemembersFood()) {
            GameObject foodObject = beliefs.GetMemoryBelief().GetClosestFood(currentPosistion);
            if (foodObject != null) {
                EatFoodIntention intention = new EatFoodIntention(beliefs.GetMemoryBelief().GetClosestFood(currentPosistion).GetComponent<Food>(), desireLevel);
                desiredIntentions.Add(intention);
            }
        }
        


        return desiredIntentions;
    }
}
