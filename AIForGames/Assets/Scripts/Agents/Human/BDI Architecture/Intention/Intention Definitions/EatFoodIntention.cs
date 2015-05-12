using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EatFoodIntention : Intention
{
    private Food foodToBeEaten;

    public EatFoodIntention(Food foodToBeEaten, float desiredIntentValue)
        : base(desiredIntentValue)
    {
        this.foodToBeEaten = foodToBeEaten;
    }
 
    public override bool Succeeded()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsImpossible()
    {
        throw new System.NotImplementedException();
    }

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (beliefs.GetInventoryBelief().Foods().Contains(foodToBeEaten)) {
            intentValue = 50;
        } else {
            Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition().position;
            Vector3 foodPosition = foodToBeEaten.transform.position;
            intentValue = 50 / ((currentPosition - foodPosition).magnitude);
        }
        
        
        return true;
    }
}
