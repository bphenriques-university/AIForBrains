using UnityEngine;
using System.Collections.Generic;

public class ObjectsFoundBelief : Belief
{

    HumanObjectMemory memory = new HumanObjectMemory();
    GameObject exit = null;



    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        RememberFood(beliefs.GetSightBelief().FoodSeen());
        RememberAmmo(beliefs.GetSightBelief().AmmoSeen());
        RememberExit(beliefs.GetSightBelief().GetExitSeen());
        RememberZombie(beliefs.GetSightBelief().ZombieSeen());
        RememberHuman(beliefs.GetSightBelief().HumanSeen());
    }

    private void RememberHuman(IList<GameObject> list)
    {
        foreach (GameObject human in list)
        {
            memory.RememberHuman(human);
        }
    }

    private void RememberZombie(IList<GameObject> list)
    {
        foreach (GameObject zombie in list)
        {
            memory.RememberZombie(zombie);
        }
    }

    private void RememberExit(GameObject gameObject)
    {
        exit = gameObject;
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

    public GameObject GetExit()
    {
        return exit;
    }
}
