using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private State currentStateRunning;
    private State nextState;

    public void ChangeState(State newState)
    {
        if(this.currentStateRunning != null)
        {
            this.currentStateRunning.Exit();
        }
        this.nextState = this.currentStateRunning;

        this.currentStateRunning = newState;
        this.currentStateRunning.Enter();
    }

    public void ExecuteStateUpdate()
    {
        var runningState = this.currentStateRunning;
        if(runningState != null) {
            runningState.Execute();
        }
    }
    public void SwitchToNextState()
    {
        this.currentStateRunning.Exit();
        this.currentStateRunning = this.nextState;
        this.currentStateRunning.Enter();
    }

}
