using UnityEngine;
using System.Collections;

public class SightBelief : Belief
{
    private Food foodSeen = null;
    private GameObject ammoSeen = null;
    private GameObject zombieSeen = null;
    private GameObject exitSeen = null;

    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        foodSeen = humanState.FoodSeen();
        ammoSeen = humanState.ammoSeen;
        zombieSeen = humanState.zombieSeen;
        exitSeen = humanState.exitSeen;
    }

    public bool SawFood()
    {
        return foodSeen != null;
    }

    public bool SawAmmo()
    {
        return ammoSeen != null;
    }

    public bool SawZombie()
    {
        return zombieSeen != null;
    }

    public bool SawExit()
    {
        return exitSeen != null;
    }

    public Food GetFoodSeen()
    {
        return foodSeen;
    }

    public GameObject GetAmmoSeen()
    {
        return ammoSeen;
    }

    public GameObject GetZombieSeen()
    {
        return zombieSeen;
    }

    public GameObject GetExitSeen()
    {
        return exitSeen;
    }
}
