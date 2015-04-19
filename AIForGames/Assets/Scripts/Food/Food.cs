using UnityEngine;
using System.Collections;

public abstract class Food : MonoBehaviour
{

	public float foodPoints;

	public virtual float eat(){
		Object.Destroy (this.gameObject);
		return foodPoints;
	}
}

