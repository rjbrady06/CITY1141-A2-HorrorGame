using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WaypointData
{
    public Vector3 pos;
    public int index;

    public WaypointData(Vector3 p, int i)
    {
        pos = p; index = i;
    }
}


public class PatrolManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints = new List<Transform>();

    public WaypointData GetFirstWaypoint()
    {
        if(waypoints.Count > 0)
        {
            return new WaypointData(waypoints[0].transform.position, 0);
        }
        else
        {
            return new WaypointData();
        }
    }

    public WaypointData GetNextPoint(int currentPoint)
    {
        if(currentPoint < waypoints.Count - 1)
        {
            return new WaypointData(waypoints[currentPoint + 1].transform.position, currentPoint + 1);
        }
        else
        {
            return new WaypointData(waypoints[0].transform.position, 0);
        }
    }

}
