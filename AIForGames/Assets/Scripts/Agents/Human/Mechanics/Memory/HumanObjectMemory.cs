using UnityEngine;
using System.Collections.Generic;

public class HumanObjectMemory
{
    Collider sightCollider;

    public Memory FoodMemory;
    public Memory AmmoMemory;
    public Memory HumanMemory;
    public Memory ZombieMemory;
   

    public HumanObjectMemory(Collider sightCollider)
    {
        this.sightCollider = sightCollider;
        FoodMemory = new Memory();
        ZombieMemory = new Memory();
        HumanMemory = new Memory();
        AmmoMemory = new Memory();
    }


    public void RememberFood(GameObject food)
    {
        FoodMemory.AddMemory(food);
    }

    public void RememberHuman(GameObject human)
    {
        HumanMemory.AddMemory(human);
    }

    public void RememberZombie(GameObject zombie)
    {
        ZombieMemory.AddMemory(zombie);
    }

    public void RememberAmmo(GameObject ammo)
    {
        AmmoMemory.AddMemory(ammo);
    }

    public void CleanWrongMemories()
    {
        Bounds bounds = sightCollider.bounds;

        FoodMemory.CleanMemory(bounds);
        ZombieMemory.CleanMemory(bounds);
        HumanMemory.CleanMemory(bounds);
        AmmoMemory.CleanMemory(bounds);
        
    }

   
}
