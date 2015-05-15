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
        

        while (true) {
            int index = Mathf.FloorToInt(Random.Range(0, navPoints.Count));

            HumanNavPoint navPoint = navPoints[index];

            if (!navPoint.Seen())
            {
                return navPoint.navPoint.transform.position;
            }
        }

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
