using UnityEngine;
using System.Collections;

public class SightBelief : Belief
{
    private Food foodSeen = null;
    private Ammo ammoSeen = null;
    private GameObject zombieSeen = null;
    private GameObject exitSeen = null;
	private HumanState humanState = null;

    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        foodSeen = humanState.FoodSeen();
        ammoSeen = humanState.ammoSeen;
        zombieSeen = humanState.zombieSeen;
        exitSeen = humanState.exitSeen;
		this.humanState = humanState;
    }

	public float DistanceToZombie(){
		return Vector3.Distance (humanState.transform.position, zombieSeen.gameObject.transform.position);
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

    public Ammo GetAmmoSeen()
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
