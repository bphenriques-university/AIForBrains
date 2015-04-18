using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
	public int ammountAmmo = 3;

	public virtual int GrabAmmo(){
		Object.Destroy (this.gameObject);
		return ammountAmmo;
	}
}

