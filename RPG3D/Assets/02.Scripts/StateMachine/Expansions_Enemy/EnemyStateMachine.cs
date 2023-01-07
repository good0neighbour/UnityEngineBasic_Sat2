using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : CharacterStateMachine
{
    public float speed;
    public float speedMax = 2.0f;

    public EnemyStateMachine(GameObject owner) : base(owner)
    {
    }

    public void DoMove()
    {
        speed = speedMax;
    }

    public void StopMove()
    {
        speed = 0.0f;
    }

    public override void InitStates()
    {
        GroundDetector groundDetetor = owner.GetComponent<GroundDetector>();
        Rigidbody rb = owner.GetComponent<Rigidbody>();

        IState move = new EnemyStateMove(id: (int)StateType.Move,
                                          owner: owner,
                                          executeCondition: () => true,
                                          transitions: new List<KeyValuePair<System.Func<bool>, int>>()
                                          {
                                              new KeyValuePair<Func<bool>, int>
                                              (
                                                  () => false,
                                                  0
                                              )
                                          });
        states.Add(StateType.Move, move);

        IState attack = new EnemyStateAttack(id: (int)StateType.Attack,
                                          owner: owner,
                                          executeCondition: () => currentType == StateType.Move,
                                          transitions: new List<KeyValuePair<Func<bool>, int>>()
                                          {
                                              new KeyValuePair<Func<bool>, int>
                                              (
                                                  () => true,
                                                  (int)StateType.Move
                                              )
                                          });
        states.Add(StateType.Attack, attack);
    }
}
