using UnityEngine;
using System.Collections.Generic;

public class MemoryBelief : Belief
{

    HumanObjectMemory memory = new HumanObjectMemory();
    GameObject exit = null;
    bool saidExit = false;

    Collider meshCollider;

    public MemoryBelief(Collider meshCollider)
    {
        this.meshCollider = meshCollider;
    }

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        RememberFood(human.Sensors.FoodSeen());
        RememberAmmo(human.Sensors.AmmoSeen());
        RememberExit(human.Sensors.ExitSeen());
        RememberZombie(human.Sensors.ZombiesSeen());
        RememberHuman(human.Sensors.HumansSeen());

        saidExit = human.Sensors.SaidExit();
        memory.CleanWrongMemories(meshCollider);
    }

    public bool RemembersZombie()
    {
        return memory.ZombieMemory.Memories.Count > 0;
    }

    public bool RemembersFood()
    {
        return memory.FoodMemory.Memories.Count > 0;
    }

    public GameObject GetClosestHuman(Vector3 currentPostition)
    {
        return GetClosest(currentPostition, memory.HumanMemory.Memories);
    }

    public GameObject GetClosestZombie(Vector3 currentPostition)
    {
        return GetClosest(currentPostition, memory.ZombieMemory.Memories);
    }

    public GameObject GetClosestAmmo(Vector3 currentPostition)
    {
        return GetClosest(currentPostition, memory.AmmoMemory.Memories);
    }

    public GameObject GetClosestFood(Vector3 currentPostition)
    {
        return GetClosest(currentPostition, memory.FoodMemory.Memories);
    }

    private GameObject GetClosest(Vector3 currentPostition, Dictionary<int, Memory.MemoryEntry> list)
    {
        if (list.Count <= 0)
            return null;

        GameObject closest = null;
        foreach (Memory.MemoryEntry value in list.Values)
        {
            if (value.getGameObject() == null)
                continue;

            if (closest == null)
            {
                closest = value.getGameObject();
            }

            float distance = (currentPostition - value.getLastKnownPosition()).magnitude;
            float distanceToCurrentClosestObject = (currentPostition - closest.transform.position).magnitude;

            if (distance < distanceToCurrentClosestObject)
            {
                closest = value.getGameObject();
            }
        }

        return closest;
    }

    private void RememberHuman(IList<GameObject> list)
    {
        foreach (GameObject human in list)
        {
            memory.RememberHuman(human);
        }
    }

    private void RememberZombie(IList<GameObject> list)
    {
        foreach (GameObject zombie in list)
        {
            memory.RememberZombie(zombie);
        }
    }

    private void RememberExit(GameObject gameObject)
    {
        exit = gameObject;
    }

    private void RememberFood(IList<Food> list)
    {
        foreach (Food food in list)
        {
            memory.RememberFood(food.gameObject);
        }
    }

    private void RememberAmmo(IList<Ammo> list)
    {
        foreach (Ammo ammo in list)
        {
            memory.RememberAmmo(ammo.gameObject);
        }
    }

    public HumanObjectMemory GetMemory()
    {
        return memory;
    }

    public GameObject GetExit()
    {
        return exit;
    }

    public bool SaidExit()
    {
        return saidExit;
    }
}
