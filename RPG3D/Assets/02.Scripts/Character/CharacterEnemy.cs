using BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemy : CharacterBase
{
    [SerializeField] private float _detectRange = 5.0f;
    [SerializeField] private float _attackRange = 1.0f;
    [SerializeField] private LayerMask _targetLayouyt;
    [SerializeField] private float _aiBehaviourTimeMin = 0.5f;
    [SerializeField] private float _aiBehaviourTimeMax = 3.0f;
    private Transform _target;

    private BehaviourTree _bt;
    private bool _btEnabled = true;

    protected override CharacterStateMachine InitMachine()
    {
        return new EnemyStateMachine(gameObject);
    }

    protected override void UpdateMachine()
    {
        machine.Update();
    }

    protected override void Awake()
    {
        base.Awake();
        BuildBehaviourTree();
        OnHpMin += () =>
        {
            _btEnabled = false;
            machine.ChangeState(CharacterStateMachine.StateType.Die);
        };
    }

    protected override void Update()
    {
        base.Update();

        if (_btEnabled)
            _bt.Tick();
    }

    private void BuildBehaviourTree()
    {
        EnemyMovement movement = GetComponent<EnemyMovement>();

        _bt = new BehaviourTree();
        _bt.StartBuild()
            .Selector()
                .Selector()
                    // in attack range?
                    .Condition(() =>
                    {
                        Collider[] cols = Physics.OverlapSphere(transform.position, _attackRange, _targetLayouyt);
                        if (cols.Length > 0)
                        {
                            _target = cols[0].transform;
                            return true;
                        }
                        else
                        {
                            _target = null;
                            return false;
                        }
                    })
                        // do attack
                        .Execution(() =>
                        {
                            machine.ChangeState(CharacterStateMachine.StateType.Attack);
                            return machine.currentType == CharacterStateMachine.StateType.Attack ? Status.Success : Status.Failure;
                        })
                    // in detect range?
                    .Condition(() =>
                    {
                        Collider[] cols = Physics.OverlapSphere(transform.position, _detectRange, _targetLayouyt);
                        if (cols.Length > 0)
                        {
                            _target = cols[0].transform;
                            return true;
                        }
                        else
                        {
                            _target = null;
                            return false;
                        }
                    })
                        // do follow
                        .Execution(() =>
                        {
                            transform.LookAt(_target);
                            movement.DoMove();
                            machine.ChangeState(CharacterStateMachine.StateType.Move);
                            return machine.currentType == CharacterStateMachine.StateType.Move ? Status.Success : Status.Failure;
                        })
                .ExitCurrentComposite()
                .RandomSelector()
                    .RandomSleep(_aiBehaviourTimeMin, _aiBehaviourTimeMax)
                        .Execution(() =>
                        {
                            transform.eulerAngles = Vector3.up * Random.Range(0.0f, 360.0f);
                            movement.StopMove();
                            machine.ChangeState(CharacterStateMachine.StateType.Move);
                            return machine.currentType == CharacterStateMachine.StateType.Move ? Status.Success : Status.Failure;
                        })
                    .RandomSleep(_aiBehaviourTimeMin, _aiBehaviourTimeMax)
                        .Execution(() =>
                        {
                            movement.DoMove();
                            machine.ChangeState(CharacterStateMachine.StateType.Move);
                            return machine.currentType == CharacterStateMachine.StateType.Move ? Status.Success : Status.Failure;
                        });
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
