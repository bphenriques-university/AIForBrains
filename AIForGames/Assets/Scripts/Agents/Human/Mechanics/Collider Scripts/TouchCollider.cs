using UnityEngine;
using System.Collections;

public class TouchCollider : MonoBehaviour
{

    public GameObject ammoColided;
	public GameObject foodColided;
	public GameObject humanColided;

	
	void OnCollisionEnter (Collision other){
		
		if (other.gameObject.tag == "Ammo") {
            ammoColided = other.gameObject;
		}
        if (other.gameObject.tag == "Food") {
            foodColided = other.gameObject;
		}
		if (other.gameObject.tag == "Human") {
			humanColided = other.gameObject;
		}
	}



    void OnCollisionExit(Collision other)
    {

        if (other.gameObject.Equals(ammoColided))
        {
            ammoColided = null;
        }
        if (other.gameObject.Equals(foodColided))
        {
            foodColided = null;
        }
    }
}

