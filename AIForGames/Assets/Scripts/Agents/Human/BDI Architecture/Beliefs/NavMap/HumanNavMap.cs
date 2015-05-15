using UnityEngine;
using System.Collections.Generic;

public class HumanNavMap
{
    public IList<HumanNavPoint> navPoints = new List<HumanNavPoint>();

    public HumanNavMap(NavMap navMap)
    {
        foreach (NavPoint navPoint in navMap.navPoints)
        {
            navPoints.Add(new HumanNavPoint(navPoint));
        }

    }

    public void CheckNavPoint(NavPoint navPoint)
    {
        navPoints[navPoint.id].SetSeen(true);
    }

    public Vector3 GetRandomUnvisitedPosition(Vector3 originPosition, float radius)
    {

        //Put more random in here
        int index = Random.Range(0, navPoints.Count);
        int limit = index;

        for (; index != limit - 1; index = ++index % navPoints.Count)
        {
            HumanNavPoint navPoint = navPoints[index];

            if (!navPoint.Seen())
            {
                Vector3 navPointPosition = navPoint.navPoint.transform.position;
                if ((navPointPosition - originPosition).magnitude < radius)
                    return navPoint.navPoint.transform.position;
            }
        }

        cleanNavPointsSeen();
        return GetRandomUnvisitedPosition(originPosition, radius);
    }

    private void cleanNavPointsSeen()
    {
        Debug.Log("Cleaning NavMap");
        foreach (HumanNavPoint navPoint in navPoints)
        {
            navPoint.SetSeen(false);
        }
    }
}
