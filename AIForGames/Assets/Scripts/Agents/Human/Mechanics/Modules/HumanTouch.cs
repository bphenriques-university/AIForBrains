using UnityEngine;
using System.Collections;

public class HumanTouch : MonoBehaviour
{
    public GameObject foodTouched;
    public GameObject ammoTouched;
	public GameObject humanTouched;

    public void ProcessTouch(TouchCollider colider)
    {
        foodTouched = colider.foodColided;
        ammoTouched = colider.ammoColided;
		humanTouched = colider.humanColided;

    }


}
