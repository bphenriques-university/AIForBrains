using UnityEngine;
using System.Collections.Generic;

public class SightBelief : Belief
{
    private IList<Food> foodSeen = null;
    private IList<Ammo> ammoSeen = null;
    private IList<GameObject> zombieSeen = null;
    private IList<GameObject> humansSeen = null;
    private IList<NavPoint> navPointsSeen = null;
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
        navPointsSeen = human.Sensors.NavPointsSeen();

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

    public IList<GameObject> ZombieSeen()
    {
        return zombieSeen;
    }
    public IList<GameObject> HumanSeen()
    {
        return humansSeen;
    }

    public IList<NavPoint> NavPointsSeen()
    {
        return navPointsSeen;
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

	public bool IsAimingAt(Transform transform, GameObject target)
	{
		Ray shootRay = new Ray ();
		RaycastHit shootHit;
		float range = 100f;
		
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		
		int shootableMask = LayerMask.GetMask ("Shootable");
		
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			if (shootHit.collider.gameObject == target) {
				EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
				
				// If the EnemyHealth component exist...
				return enemyHealth != null;
			}
		}

		return false;
	}

}
