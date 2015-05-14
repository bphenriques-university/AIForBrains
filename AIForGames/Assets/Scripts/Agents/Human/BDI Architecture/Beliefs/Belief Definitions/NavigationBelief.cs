using UnityEngine;
using System.Collections;

public class NavigationBelief : Belief
{

    private Transform currentPosition;
    

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        currentPosition = human.Sensors.CurrentPosition();
    }

    public Transform CurrentPosition()
    {
        return currentPosition;
    }
}
