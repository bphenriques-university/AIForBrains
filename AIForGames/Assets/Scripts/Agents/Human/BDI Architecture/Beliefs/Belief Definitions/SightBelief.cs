using UnityEngine;
using System.Collections.Generic;

public class SightBelief : Belief
{
    private IList<Food> foodSeen = null;
    private IList<Ammo> ammoSeen = null;
    private IList<GameObject> zombieSeen = null;
    private IList<GameObject> humansSeen = null;
    private GameObject exitSeen = null;

    private bool sawFood = false;
    private bool sawAmmo = false;
    private bool sawZombie = false;
    private bool sawExit = false;
    private bool sawHuman = false;


    private Vector3 currentPosition;

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        foodSeen = human.Sensors.FoodSeen();
        ammoSeen = human.Sensors.AmmoSeen();
        zombieSeen = human.Sensors.ZombiesSeen();
        humansSeen = human.Sensors.HumansSeen();
        exitSeen = human.Sensors.ExitSeen();

        sawFood = human.Sensors.SawFood();
        sawAmmo = human.Sensors.SawAmmo();
        sawZombie = human.Sensors.SawZombies();
        sawExit = human.Sensors.SawExit();
        sawHuman = human.Sensors.SawHumans();

        currentPosition = human.Sensors.CurrentPosition().position;
    }

	public float DistanceToZombie(GameObject zombie){
        return Vector3.Distance(currentPosition, zombie.gameObject.transform.position);
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

    public IList<Food> FoodSeen()
    {
        return foodSeen;
    }

    public IList<Ammo> AmmoSeen()
    {
        return ammoSeen;
    }

    public IList<GameObject> GetZombieSeen()
    {
        return zombieSeen;
    }

    public GameObject GetExitSeen()
    {
        return exitSeen;
    }

    internal int DistanceToClosestZombie()
    {
        throw new System.NotImplementedException();
    }

    internal GameObject GetClosestZombie()
    {
        throw new System.NotImplementedException();
    }
}
