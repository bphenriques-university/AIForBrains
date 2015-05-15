using UnityEngine;
using System.Collections.Generic;

public class ObjectsFoundBelief : Belief
{

    HumanObjectMemory memory = new HumanObjectMemory();



    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        RememberFood(beliefs.GetSightBelief().FoodSeen());
        RememberAmmo(beliefs.GetSightBelief().AmmoSeen());
    }

    private void RememberFood(IList<Food> list)
    {
        foreach (Food food in list)
        {
            memory.RememberFood(food.gameObject);
        }
    }

    private void RememberAmmo(IList<Ammo> list)
    {
        foreach (Ammo ammo in list)
        {
            memory.RememberAmmo(ammo.gameObject);
        }
    }

    public HumanObjectMemory GetMemory()
    {
        return memory;
    }
}
