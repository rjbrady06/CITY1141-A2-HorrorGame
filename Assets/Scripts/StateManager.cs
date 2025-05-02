using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class StateManager : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent => this.GetComponent<NavMeshAgent>();
    
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
    private void OnCollisionEnter(Collision collision)
    {/*
        if (collision != null)
        {
            ChangeState(ChaseState);
        }

       */
    }
}
