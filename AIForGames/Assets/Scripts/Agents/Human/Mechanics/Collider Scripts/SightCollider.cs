using UnityEngine;
using System.Collections.Generic;

public class SightCollider : MonoBehaviour {


    private const float RANGE = 20f;

	RaycastHit shootHit;
	int shootableMask;

    public IList<GameObject> SeenGameObjects = new List<GameObject>();

	
	void Awake(){
		shootableMask = LayerMask.GetMask ("Shootable") | LayerMask.GetMask ("Viewable");
	}

    void Update()
    {
        cleanNullPointers();
    }

	void OnTriggerEnter (Collider other){
        if (isVisible(other))
            SeenGameObjects.Add(other.gameObject);
	}

	void OnTriggerStay(Collider other)
	{
		OnTriggerEnter (other);
	}


	void OnTriggerExit(Collider other){

        GameObject gameObject = other.gameObject;

        if (SeenGameObjects.Contains(gameObject))
            SeenGameObjects.Remove(gameObject);
	
	}



    private void cleanNullPointers()
    {
        IList<GameObject> gameObjectsToRemove = new List<GameObject>();
        foreach (GameObject seenGameObject in SeenGameObjects)
        {
            if (!seenGameObject)
                gameObjectsToRemove.Add(seenGameObject);
        }

        foreach (GameObject deleteGameObject in gameObjectsToRemove)
        {
            SeenGameObjects.Remove(deleteGameObject);
        }
    }


	private bool isVisible (Collider other)
	{
		Vector3 direction = (other.transform.position) - transform.position;
		if (Physics.Raycast (transform.position, direction.normalized, out shootHit, RANGE, shootableMask)) {
			//Debug.Log ("VI: Daqui: " + transform.position + "para ali: " + other.transform.position + "vendo um " + shootHit.collider.gameObject);
			if (shootHit.collider.gameObject.Equals (other.gameObject)) {
				//Debug.Log ("VI MESMO um " + shootHit.collider.gameObject);
				return true;
			}
		}
		
		return false;
	}

	private bool isCloser(GameObject a, GameObject b){

		float distance;
		Vector3 distanceVector = a.transform.position - transform.position;
		distance = distanceVector.sqrMagnitude;
		
		float currentDistance;
		Vector3 currentDistanceVector = b.transform.position - transform.position;
		currentDistance = currentDistanceVector.sqrMagnitude;

		return distance < currentDistance;
		
	}


    

}
