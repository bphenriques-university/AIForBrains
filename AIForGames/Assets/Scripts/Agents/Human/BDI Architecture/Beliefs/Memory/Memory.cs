using UnityEngine;
using System.Collections.Generic;

public class Memory {

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

    public Dictionary<int, MemoryEntry> Memories = new Dictionary<int, MemoryEntry>();
 

    public MemoryEntry AddMemory(GameObject gObject)
    {
        MemoryEntry entry;
        if (Memories.TryGetValue(gObject.GetInstanceID(), out entry))
            entry.updatePosition(gObject.transform.position);
        else
            Memories.Add(gObject.GetInstanceID(), new MemoryEntry(gObject, gObject.transform.position));
        return entry;
    }


    public void CleanMemory(Bounds sightBounds)
    {
        GameObject gObject;
        IList<int> wrongMemoriesIds = new List<int>();

        foreach (MemoryEntry memory in Memories.Values)
        {
            if (sightBounds.Contains(memory.getLastKnownPosition()))
            {
                gObject = memory.getGameObject();
                if (gObject && gObject.transform.position.Equals(memory.getLastKnownPosition()) == false)
                {
                    wrongMemoriesIds.Add(gObject.GetInstanceID());
                }
            }
        }

        foreach (int wrongMemoryId in wrongMemoriesIds)
        {
            Memories.Remove(wrongMemoryId);
        }
    }
    
}
