using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField]
    Transform playerPos;
    public override void StateStarted()
    {
        
    }

    public override void StateUpdated()
    {
        if(playerPos != null)
        {
            owningManager.agent.destination = playerPos.position;
        }
    }
}
