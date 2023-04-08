using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMachineMonitor : StateMachineBehaviour
{
    public event Action<int> OnEnter;
    public event Action<int> OnExit;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineEnter(animator, stateMachinePathHash);

        OnEnter?.Invoke(stateMachinePathHash);
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineExit(animator, stateMachinePathHash);

        OnExit?.Invoke(stateMachinePathHash);
    }
}
