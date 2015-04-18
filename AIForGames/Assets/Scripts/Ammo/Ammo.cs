using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{

	public int ammountAmmo;

	public virtual int GrabAmmo(){
		print("AMMOBOX HERE");
		Object.Destroy (this.gameObject);
		return ammountAmmo;
	}
}

