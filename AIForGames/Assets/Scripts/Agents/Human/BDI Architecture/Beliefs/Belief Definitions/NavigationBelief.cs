using UnityEngine;
using System.Collections.Generic;

public class NavigationBelief : Belief
{
    private Transform currentPosition;
    private HumanNavMap humanNavMap;

    public NavigationBelief(NavMap navMap)
    {
        this.humanNavMap = new HumanNavMap(navMap);
    }
    



    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        currentPosition = human.Sensors.CurrentPosition();

        IList<NavPoint> navPoints = beliefs.GetSightBelief().NavPointsSeen();

        foreach (NavPoint navPoint in navPoints)
        {
            humanNavMap.CheckNavPoint(navPoint);
        }
    }

    public Transform CurrentPosition()
    {
        return currentPosition;
    }

    public HumanNavMap HumanNavMap()
    {
        return humanNavMap;
    }
}
