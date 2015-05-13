using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
	public int ammountAmmo = 3;
	public bool wasPickedUp = false;


	public virtual int GrabAmmo(){
		Object.Destroy (this.gameObject);
		wasPickedUp = true;
		return ammountAmmo;
	}

	public bool WasPickedUp(){
		return wasPickedUp;
	}
}

