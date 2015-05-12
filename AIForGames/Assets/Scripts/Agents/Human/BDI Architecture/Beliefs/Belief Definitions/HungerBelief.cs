using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HungerBelief : Belief
{
    private float hungerLevel;


    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        hungerLevel = humanState.HungerLevel();
    }


    public float GetFoodLevel()
    {
        return hungerLevel;
    }

}

