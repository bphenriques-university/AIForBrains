using UnityEngine;
using System.Collections;

public class TouchBelief : Belief
{

    private GameObject foodTouched;
    private GameObject ammoTouched;



    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        foodTouched = human.Sensors.GetTouchingFood();
        ammoTouched = human.Sensors.GetTouchingAmmo();
    }

    public bool IsTouchingFood()
    {
        return foodTouched;
    }
    public bool IsTouchingAmmo()
    {
        return ammoTouched;
    }

    public Ammo GetTouchingAmmo()
    {
        if (ammoTouched)
            return ammoTouched.GetComponent<Ammo>();
        else
            return null;
    }

    public Food GetTouchingFood()
    {
        if (foodTouched)
            return foodTouched.GetComponent<Food>();
        else
            return null;
    }

}
