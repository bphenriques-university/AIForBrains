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

    public GameObject ExitSeen()
    {
        return sight.ExitSeen;
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


}
