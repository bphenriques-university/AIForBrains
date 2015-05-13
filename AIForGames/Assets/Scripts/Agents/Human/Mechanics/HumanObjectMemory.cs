using UnityEngine;
using System.Collections.Generic;

public class HumanObjectMemory
{
    Collider sightCollider;

    public struct MemoryEntry
    {
        private GameObject gObject;
        private Vector3 position;

        public MemoryEntry(GameObject memory, Vector3 position)
        {
            this.gObject = memory;
            this.position = position;
        }

        public GameObject getGameObject()
        {
            return gObject;
        }

        public Vector3 getLastKnownPosition()
        {
            return position;
        }

        public void updatePosition(Vector3 position)
        {
            this.position = position;
        }
    }

    public HumanObjectMemory(Collider sightCollider)
    {
        this.sightCollider = sightCollider;
        FoodMemory = new Dictionary<int, MemoryEntry>();
        ZombieMemory = new Dictionary<int, MemoryEntry>();
        HumanMemory = new Dictionary<int, MemoryEntry>();
        AmmoMemory = new Dictionary<int, MemoryEntry>();
    }


   

    public Dictionary<int, MemoryEntry> FoodMemory;
    public Dictionary<int, MemoryEntry> AmmoMemory;
    public Dictionary<int, MemoryEntry> HumanMemory;
    public Dictionary<int, MemoryEntry> ZombieMemory;

    public void rememberFood(GameObject food)
    {
        MemoryEntry entry;

        if (FoodMemory.TryGetValue(food.GetInstanceID(), out entry))
            entry.updatePosition(food.transform.position);
        else
            FoodMemory.Add(food.GetInstanceID(), new MemoryEntry(food, food.transform.position));
    }

    public void rememberHuman(GameObject human)
    {
        MemoryEntry entry;

        if (HumanMemory.TryGetValue(human.GetInstanceID(), out entry))
            entry.updatePosition(human.transform.position);
        else
            HumanMemory.Add(human.GetInstanceID(), new MemoryEntry(human, human.transform.position));
    }

    public void rememberZombie(GameObject zombie)
    {
        MemoryEntry entry;

        if (ZombieMemory.TryGetValue(zombie.GetInstanceID(), out entry))
            entry.updatePosition(zombie.transform.position);
        else
            ZombieMemory.Add(zombie.GetInstanceID(), new MemoryEntry(zombie, zombie.transform.position));
    }

    public void rememberAmmo(GameObject ammo)
    {
        MemoryEntry entry;

        if (AmmoMemory.TryGetValue(ammo.GetInstanceID(), out entry))
            entry.updatePosition(ammo.transform.position);
        else
            AmmoMemory.Add(ammo.GetInstanceID(), new MemoryEntry(ammo, ammo.transform.position));
    }

    public Dictionary<int, MemoryEntry> getFoodMemory()
    {

        return FoodMemory;

    }

    public Dictionary<int, MemoryEntry> getAmmoMemory()
    {

        return AmmoMemory;

    }
    public Dictionary<int, MemoryEntry> getZombieMemory()
    {

        return ZombieMemory;

    }

    public Dictionary<int, MemoryEntry> getHumanMemory()
    {

        return HumanMemory;

    }

    public void cleanWrongMemories()
    {
        Bounds bounds = sightCollider.bounds;
        GameObject gObject;


        foreach (MemoryEntry memory in FoodMemory.Values)
        {
            if (bounds.Contains(memory.getLastKnownPosition()))
            {
                gObject = memory.getGameObject();
                if (gObject.transform.position.Equals(memory.getLastKnownPosition()) == false)
                {
                    FoodMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach (MemoryEntry memory in ZombieMemory.Values)
        {
            if (bounds.Contains(memory.getLastKnownPosition()))
            {
                gObject = memory.getGameObject();
                if (gObject.transform.position.Equals(memory.getLastKnownPosition()) == false)
                {
                    ZombieMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach (MemoryEntry memory in HumanMemory.Values)
        {
            if (bounds.Contains(memory.getLastKnownPosition()))
            {
                gObject = memory.getGameObject();
                if (gObject.transform.position.Equals(memory.getLastKnownPosition()) == false)
                {
                    HumanMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach (MemoryEntry memory in AmmoMemory.Values)
        {
            if (bounds.Contains(memory.getLastKnownPosition()))
            {
                gObject = memory.getGameObject();
                if (gObject.transform.position.Equals(memory.getLastKnownPosition()) == false)
                {
                    AmmoMemory.Remove(gObject.GetInstanceID());
                }
            }
        }
    }
}
