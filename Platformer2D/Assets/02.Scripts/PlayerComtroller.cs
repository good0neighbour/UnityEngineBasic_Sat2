using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    public enum States
    {
        Idle,
        Move,
        Attack,
        Jump,
        Fall
    }

    public enum JumpStates
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum FallStates
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum AttackStates
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    States _state;
    JumpStates _jumpStates;
    FallStates _fallStates;
    AttackStates _attackStates;
}
