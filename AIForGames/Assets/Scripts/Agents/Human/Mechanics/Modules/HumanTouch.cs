using UnityEngine;
using System.Collections;

public class HumanTouch : MonoBehaviour
{
    public GameObject foodTouched;
    public GameObject ammoTouched;


    public void ProcessTouch(TouchCollider colider)
    {
        foodTouched = colider.foodColided;
        ammoTouched = colider.ammoColided;
    }


}
