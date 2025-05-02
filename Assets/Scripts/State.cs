using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateManager owningManager;
    private void Start()
    {
        if(this.gameObject.GetComponentInParent<StateManager>() != null)
        {
            owningManager = this.gameObject.GetComponentInParent<StateManager>();
        }
    }

    public abstract void StateUpdated();

    public abstract void StateStarted();
}
