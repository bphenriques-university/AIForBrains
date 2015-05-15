using UnityEngine;
using System.Collections.Generic;

public class NavMap : MonoBehaviour
{
    public GameObject navPoint;

    public IList<NavPoint> navPoints = new List<NavPoint>();

    private const int stepNumber = 16;

    private Vector3 startingPosition = new Vector3(-33, 0, 0);
    private float stepLength = Mathf.Sqrt(8f);


    void Awake()
    {
        IList<Vector3> positions = GeneratePositions(startingPosition, stepLength, stepNumber);
        int i = 0;
        foreach (Vector3 position in positions)
        {
            GameObject clone = Instantiate(navPoint, position, Quaternion.identity) as GameObject;
            clone.transform.parent = transform;
            NavPoint point = clone.GetComponent<NavPoint>();
            navPoints.Add(point);

            point.id = i++;
        }
    }

    public static IList<Vector3> GeneratePositions(Vector3 startingPosition, float stepLength, int stepNumber)
    {
        IList<Vector3> result = new List<Vector3>();

        Vector3 position = startingPosition;

        for (int i = 1; i < stepNumber; i++)
        {
            for (int j = 0; j < stepNumber; j++)
            {
                NavMeshHit hit;
                if (!NavMesh.SamplePosition(position, out hit, 0.1f, NavMesh.AllAreas))
                {
                    position.x += stepLength;
                    position.z += stepLength;
                    continue;
                }

                NavMeshHit edgeHit;
                NavMesh.FindClosestEdge(position, out edgeHit, NavMesh.AllAreas);

                if (edgeHit.distance < 1f)
                {
                    position.x += stepLength;
                    position.z += stepLength;
                    continue;
                }

                result.Add(position);


                position.x += stepLength;
                position.z += stepLength;
            }

            position = startingPosition;

            position.x += (stepLength * i);
            position.z -= (stepLength * i);

        }

        return result;
    }

}
