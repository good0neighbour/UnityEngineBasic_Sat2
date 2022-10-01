using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    enum Commands
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }
    Commands Current { get; }
    bool IsExcecuteOK { get; }
    void Execute();
    void ForceStop();
    StateMachine.StateType Update();
    void FixedUpdate();
    void MoveNext();
}
