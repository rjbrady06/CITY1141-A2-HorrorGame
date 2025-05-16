using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class StateManager : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent => this.GetComponent<NavMeshAgent>();

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    State patrolState;

    [SerializeField]
    State chaseState;

    [SerializeField]
    Transform playerPos;

    public float distance = 10f;

    [SerializeField]
    State currentState;

    private void Start()
    {
        
        if (currentState != null)
        {
            currentState.StateStarted();
        }
    }
    // Update is called once per frame
    void Update()
    {
        RunCurrentState();

        if (Vector3.Distance(this.gameObject.transform.position, playerPos.position) <= distance)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = Vector3.Normalize(playerPos.position - transform.position);

            if (Vector3.Dot(forward, toOther) > 0)
            {
                
                ChangeState(chaseState);
            }
            else
            {
                ChangeState(patrolState);
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, (playerPos.position - transform.position).normalized, out hit, distance, layerMask))
            {
                if (hit.transform != playerPos)
                {
                    Debug.Log("Player is out of sight");

                    ChangeState(patrolState);
                }
                else
                {
                    Debug.Log("Player is in sight");

                    ChangeState(chaseState);
                }
            }
        }
       
    }
    private void RunCurrentState()
    {

        if(currentState != null)
        {
            currentState.StateUpdated();
        }
    }

   public void ChangeState(State newState)
   {
        if(newState != null && newState != currentState)
        {
            currentState = newState;
            currentState.StateStarted();
        }
   }
    
}
