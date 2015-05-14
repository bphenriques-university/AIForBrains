using UnityEngine;
using System.Collections;

public partial class Sensors : MonoBehaviour
{


    public bool IsGrabbed()
    {
        return movement.isBeingGrabbed();
    }

    public float HungerLevel()
    {
        return hunger.GetHungerLevel();
    }

    public int HealthLevel()
    {
        return health.getHealthLevel();
    }

    public int MaxHealthLevel()
    {
        return health.getMaxHealthLevel();
    }

    public bool WasAttacked()
    {
        if (lastSeenHealth > health.currentHealth)
        {
            lastSeenHealth = health.currentHealth;
            return true;
        }
        else
        {
            return false;
        }
    }

}
