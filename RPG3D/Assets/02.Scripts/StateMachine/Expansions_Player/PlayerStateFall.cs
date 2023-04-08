using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFall : CharacterStateBase
{

    public PlayerStateFall(int id, GameObject owner, Func<bool> executeCondition, List<KeyValuePair<Func<bool>, int>> transitions) : base(id, owner, executeCondition, transitions)
    {
    }

    public override void Execute()
    {
        base.Execute();
        movement.mode = Movement.Mode.Manual;
        animator.SetBool("doFall", true);
    }

    public override void Stop()
    {
        base.Stop();
        animator.SetBool("doFall", false);
    }

    public override int Update()
    {
        return base.Update();
    }
}
