using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{

    /**
     * Sight sensors
     */

    public IList<Food> FoodSeen()
    {
        IList<Food> foods = new List<Food>();

        foreach (GameObject foodObject in sight.FoodsSeen)
        {
            if (foodObject != null)
                foods.Add(foodObject.GetComponent<Food>());
        }
        return foods;
    }

    public IList<Ammo> AmmoSeen()
    {
        IList<Ammo> ammo = new List<Ammo>();

        foreach (GameObject ammoObject in sight.AmmoSeen)
        {
            ammo.Add(ammoObject.GetComponent<Ammo>());
        }
        return ammo;
    }
    

    public IList<GameObject> HumansSeen()
    {
        return sight.HumansSeen;
    }

    public IList<GameObject> ZombiesSeen()
    {
        return sight.ZombiesSeen;
    }

    public IList<NavPoint> NavPointsSeen()
    {
        IList<NavPoint> navPoints = new List<NavPoint>();

        foreach (GameObject navPoint in sight.NavPointsSeen)
        {
            navPoints.Add(navPoint.GetComponent<NavPoint>());
        }
        return navPoints;
    }

    public GameObject ExitSeen()
    {
        return sight.ExitSeen;
    }

    public GameObject GetClosestZombie()
    {
        return GetClosest(sight.ZombiesSeen);
    }

    public GameObject GetClosestAmmoSeen()
    {
        return GetClosest(sight.AmmoSeen);
    }

    public GameObject GetClosestFoodSeen()
    {
        return GetClosest(sight.FoodsSeen);
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

    private GameObject GetClosestZombie(IList<GameObject> list)
    {
        if (list.Count <= 0)
            return null;

        GameObject closest = null;
        foreach (GameObject gObject in list)
        {
            if (gObject == null)
                continue;

            if (gObject.GetComponent<EnemyHealth>().currentHealth <= 0)
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


    
    public bool SawFood()
    {
        return sight.FoodsSeen.Count > 0;
    }

    public bool SawAmmo()
    {
        return sight.AmmoSeen.Count > 0;
    }
    
    public bool SawHumans()
    {
        return sight.HumansSeen.Count > 0;
    }

    public bool SawZombies()
    {
        return sight.ZombiesSeen.Count > 0;
    }

    public bool SawExit()
    {
        return sight.ExitSeen;
    }


    public bool IsAimingToObject(GameObject target)
    {
        Ray shootRay = new Ray();
        RaycastHit shootHit;
        float range = 100f;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;



        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            if (shootHit.collider.gameObject == target)
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                // If the EnemyHealth component exist...
                return enemyHealth != null;
            }
        }
        return false;
    }

    public float GetDistanceToObject(GameObject gameObject)
    {
        return (transform.position - gameObject.transform.position).magnitude;
    }

}
