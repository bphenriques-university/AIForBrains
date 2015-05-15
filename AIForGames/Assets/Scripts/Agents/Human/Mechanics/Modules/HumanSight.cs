using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HumanSight : MonoBehaviour
{


    // If a new attribute list is added, remember to add to SeenLists in constructor.
    private IList<GameObject>[] seenLists;
    public IList<GameObject> FoodsSeen = new List<GameObject>();
    public IList<GameObject> AmmoSeen = new List<GameObject>();
    public IList<GameObject> ZombiesSeen = new List<GameObject>();
    public IList<GameObject> HumansSeen = new List<GameObject>();
    public IList<GameObject> NavPointsSeen = new List<GameObject>();


    public GameObject ExitSeen = null;

    void Start()
    {
        seenLists = new IList<GameObject>[] { FoodsSeen, AmmoSeen, ZombiesSeen , HumansSeen, NavPointsSeen};
    }

    public void ProcessSight(IList<GameObject> seenGameObjects)
    {


        foreach (GameObject seenGameObject in seenGameObjects) {
            if (seenGameObject != null)
            {
                switch (seenGameObject.tag)
                {
                    case "Food":
                        Process(FoodsSeen, seenGameObject);
                        break;
                    case "Enemy":
                        Process(ZombiesSeen, seenGameObject);
                        break;
                    case "Ammo":
                        Process(AmmoSeen, seenGameObject);
                        break;
                    case "Human":
                        Process(HumansSeen, seenGameObject);
                        break;
                    case "EscapeExit":
                        ProcessEscapeExit(seenGameObject);
                        break;
                    case "NavPoint":
                        Process(NavPointsSeen, seenGameObject);
                        break;
                }
            }
        }


        CleanOutOfSightGameObject(seenGameObjects);

    }

    private void Process(IList<GameObject> objectList,GameObject seenGameObject)
    {
 	    if (!objectList.Contains(seenGameObject))
        {
            objectList.Add(seenGameObject);
        }
    }

    private void CleanOutOfSightGameObject(IList<GameObject> seenGameObjects)
    {
        foreach (IList<GameObject> list in seenLists)
        {

            IList<GameObject> gameObjectsToDelete = new List<GameObject> ();

            foreach (GameObject gameObjectInList in list)
            {
                if (!seenGameObjects.Contains(gameObjectInList))
                    gameObjectsToDelete.Add(gameObjectInList); 
                
                if (gameObjectInList == null)
                    gameObjectsToDelete.Add(gameObjectInList);
            }

            foreach (GameObject gameObjectToDelete in gameObjectsToDelete)
            {
                list.Remove(gameObjectToDelete);
            }
        }
    }



    private void ProcessEscapeExit(GameObject seenGameObject)
    {
        ExitSeen = seenGameObject;
    }

}
