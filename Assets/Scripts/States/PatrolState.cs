using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    [SerializeField]
    private PatrolManager currentPatrol;

    private WaypointData currentWaypoint;

    [SerializeField]
    private float minDistance = 0.5f;

    [SerializeField]
    private float waitTime = 1.5f;

    private bool delayed;

    public override void StateStarted()
    {
        if (currentPatrol != null)
        {
            currentWaypoint = currentPatrol.GetFirstWaypoint();
            owningManager.agent.destination = currentWaypoint.pos;
        }
    }
    public override void StateUpdated()
    {
        if(currentPatrol != null)
        {
            if (Vector3.Distance(this.transform.position, currentWaypoint.pos) < minDistance && !delayed)
            {
                delayed = true;
                StartCoroutine(StopAtPatrolPoint());
            }
        }
    }

    IEnumerator StopAtPatrolPoint()
    {
        yield return new WaitForSeconds(waitTime);
        currentWaypoint = currentPatrol.GetNextPoint(currentWaypoint.index);
        owningManager.agent.destination = currentWaypoint.pos;
        delayed = false;
    }
}
