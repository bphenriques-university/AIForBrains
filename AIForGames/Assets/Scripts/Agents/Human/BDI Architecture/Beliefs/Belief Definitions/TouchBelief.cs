using UnityEngine;
using System.Collections;

public class TouchBelief : Belief
{

    private Food foodTouched;
    private Ammo ammoTouched;



    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        foodTouched = human.Sensors.GetTouchingFood().GetComponent<Food>();
        ammoTouched = human.Sensors.GetTouchingAmmo().GetComponent<Ammo>();
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
            return ammoTouched;
        else
            return null;
    }

    public Food GetTouchingFood()
    {
        if (foodTouched)
            return foodTouched;
        else
            return null;
    }

}
