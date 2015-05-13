using UnityEngine;
using System.Collections;

public class SightBelief : Belief
{
    private Food foodSeen = null;
    private Ammo ammoSeen = null;
    private GameObject zombieSeen = null;
    private GameObject exitSeen = null;
	private HumanState humanState = null;

    private bool sawFood = false;
    private bool sawAmmo = false;
    private bool sawZombie = false;
    private bool sawExit = false;
    private bool sawHuman = false;


    private Vector3 currentPosition;

    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        foodSeen = humanState.FoodSeen();
        ammoSeen = humanState.ammoSeen;
        zombieSeen = humanState.zombieSeen;
        exitSeen = humanState.exitSeen;

        sawFood = humanState.sawFood;
        sawAmmo = humanState.sawAmmo;
        sawZombie = humanState.sawZombie;
        sawExit = humanState.sawExitDoor;
        sawHuman = humanState.sawHumanInDanger;

        currentPosition = humanState.CurrentPosition().position;
    }

	public float DistanceToZombie(){
        return Vector3.Distance(currentPosition, zombieSeen.gameObject.transform.position);
	}

    public bool SawFood()
    {
        return sawFood;
    }

    public bool SawAmmo()
    {
        return sawAmmo;
    }

    public bool SawZombie()
    {
        return sawZombie;
    }

    public bool SawExit()
    {
        return sawExit;
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
