using UnityEngine;
using System.Collections;

public abstract class Food : MonoBehaviour
{

	public float foodPoints;

	public virtual Food catchFood(){
		print("COMIDA AQUI COM " + foodPoints + "Pts!");
		Object.Destroy (this.gameObject);
		return this;
	}
}

