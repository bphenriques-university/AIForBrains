using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodLevelBelief : Belief
{
    private float foodLevel;

    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {


    }


    public float GetFoodLevel()
    {
        return foodLevel;
    }

}

