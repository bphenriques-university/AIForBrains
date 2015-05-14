using UnityEngine;
using System.Collections;

public abstract class Food : MonoBehaviour
{

	public int foodPoints;
    private bool catched = false;
    private bool eaten = false;

	public virtual Food catchFood(){
		Object.Destroy (this.gameObject);
        catched = true;
		return this;
	}

    public bool Catched () {
        return catched;
    }

    public bool Eaten()
    {
        return eaten;
    }

    public float Eat()
    {
        eaten = true;
        return foodPoints;
    }
}

