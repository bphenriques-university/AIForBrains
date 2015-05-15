using UnityEngine;
using System.Collections.Generic;

public class MemoryBelief : Belief
{

    HumanObjectMemory memory = new HumanObjectMemory();
    GameObject exit = null;
    bool saidExit = false;

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        RememberFood(beliefs.GetSightBelief().FoodSeen());
        RememberAmmo(beliefs.GetSightBelief().AmmoSeen());
        RememberExit(beliefs.GetSightBelief().GetExitSeen());
        RememberZombie(beliefs.GetSightBelief().ZombieSeen());
        RememberHuman(beliefs.GetSightBelief().HumanSeen());

        saidExit = human.Sensors.SaidExit();
    }



    private GameObject GetClosest(IList<GameObject> list)
    {
        if (list.Count <= 0)
            return null;

        GameObject closest = null;
        foreach (GameObject gObject in list)
        {
            if (gObject == null)
                continue;

            if (closest == null)
            {
                closest = gObject;
            }

            float distance = (transform.position - gObject.transform.position).magnitude;
            float distanceToCurrentClosestObject = (transform.position - closest.transform.position).magnitude;

            if (distance < distanceToCurrentClosestObject)
            {
                closest = gObject;
            }
        }

        return closest;
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

    public bool SaidExit()
    {
        return saidExit;
    }
}
