using UnityEngine;
using System.Collections;

public class HumanNavPoint
{
    public NavPoint navPoint;
    private bool seen;


    public HumanNavPoint(NavPoint navPoint)
    {
        this.navPoint = navPoint;
    }

    public void SetSeen(bool seen)
    {
        this.seen = seen;
    }

    public bool Seen()
    {
        return seen;
    }
}
