using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryBelief : Belief
{

    private float ammoLevel;
    private IList<Food> foods;

    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        this.ammoLevel = humanState.AmmoLevel();
        this.foods = humanState.FoodsCarried();
    }

    public float AmmoLevel()
    {
        return ammoLevel;
    }

    public IList<Food> Foods()
    {
        return foods;
    }
}
