using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Fall,
        Attack,
        Crouch,
        EdgeGrab,
        LadderUp,
        LadderDown,
        Hurt,
        Die,
        EOF
    }
    public StateType Current;
    private Dictionary<StateType, StateBase> _states = new Dictionary<StateType, StateBase>();
    private StateBase _currentState;
    private bool _isStateChanged;
    private CharacterBase _character;

    private float _h => Input.GetAxis("Horizontal");
    private float _v => Input.GetAxis("Vertical");
    private Vector2 _move;
    public bool IsMovable { get; set; }
    public bool IsDirectionChangable { get; set; }
    // -1 : left, 1 : right
    private int _direction;
    public int Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
            else
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }
    [SerializeField] private int _directionInit;

    private Rigidbody2D _rb;
    [SerializeField] private Vector2 _knockBackForce = new Vector2(1.0f, 1.0f);
    public void Knockback(int knockBackDirection)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(_knockBackForce.x * knockBackDirection,
                                 _knockBackForce.y),
                     ForceMode2D.Impulse);
    }

    public void ForceChangeState(StateType newStateType)
    {
        _currentState.ForceStop(); // ���� ���� �ߴ�
        _currentState = _states[newStateType]; // ���� ����
        _currentState.Execute(); // ���ŵ� ���� ����
        Current = newStateType;
    }

    public void StopMove()
    {
        _move.x = 0.0f;
    }

    public void SetMove(Vector2 move)
    {
        _move = move;
    }

    private void Awake()
    {
        _character = GetComponent<CharacterBase>();
        _rb = GetComponent<Rigidbody2D>();
        Init();
    }

    private void Init()
    {
        for (StateType stateType = StateType.Idle; stateType < StateType.EOF; stateType++)
        {
            AddState(stateType);
        }
        _currentState = _states[StateType.Idle];
        Current = StateType.Idle;

        IsDirectionChangable = true;
        IsMovable = true;

        ResisterShortCuts();
    }

    private void ResisterShortCuts()
    {
        // down actions
        InputHandler.ResigterKeyDownAction(KeyCode.DownArrow, () => ChangeState(StateType.LadderDown));
        InputHandler.ResigterKeyDownAction(KeyCode.UpArrow, () => ChangeState(StateType.LadderUp));

        // press actions
        InputHandler.ResigterKeyPressAction(KeyCode.LeftAlt, () => ChangeState(StateType.Jump));
        InputHandler.ResigterKeyPressAction(KeyCode.DownArrow, () => ChangeState(StateType.Crouch));
        InputHandler.ResigterKeyPressAction(KeyCode.A, () => ChangeState(StateType.Attack));
        InputHandler.ResigterKeyPressAction(KeyCode.UpArrow, () => ChangeState(StateType.EdgeGrab));
    }

    private void AddState(StateType stateType)
    {
        // �̹� ���°� ��� �Ǿ��ٸ�
        if (_states.ContainsKey(stateType))
            return;

        string stateName = Convert.ToString(stateType);
        string typeName = "State" + stateName;
        Debug.Log($"[StateMachine] : Adding state ... {stateName}");

        Type type = Type.GetType(typeName);

        if (type != null)
        {
            ConstructorInfo constructor = type.GetConstructor(new Type[]
            {
                typeof(StateType),
                typeof(StateMachine)
            });


            StateBase state
                = constructor.Invoke(new object[2]
                  {
                      stateType,
                      this
                  }) as StateBase;

            _states.Add(stateType, state);
            Debug.Log($"[StateMachine] : {stateName} state is successfully added");
        }
    }

    private void Update()
    {
        _isStateChanged = false;

        if (IsDirectionChangable)
        {
            if (_h < 0.0f)
                Direction = Constants.DIRECTION_LEFT;
            else if (_h > 0.0f)
                Direction = Constants.DIRECTION_RIGHT;
        }

        if (IsMovable)
        {
            _move.x = _h;
            if (Math.Abs(_move.x) > 0.0f)
                ChangeState(StateType.Move);
            else
                ChangeState(StateType.Idle);
        }

        ChangeState(_currentState.Update());
    }
    private void FixedUpdate()
    {
        _currentState.FixedUpdate();
        transform.position += new Vector3(_move.x * _character.MoveSpeed, _move.y, 0.0f) * Time.fixedDeltaTime;
    }

    public bool ChangeState(StateType newStateType)
    {
        //�̹� ���°� �ش� �����ӿ��� �� �� �ٲ���ٸ�
        if (_isStateChanged)
            return false;

        // ���°� �ٲ��� �ʾ�����
        if (Current == newStateType)
            return false;

        // �ٲٷ��� ���°� ���� �������� ������
        if (_states[newStateType].IsExcecuteOK == false)
            return false;

        _currentState.ForceStop(); // ���� ���� �ߴ�
        _currentState = _states[newStateType]; // ���� ����
        _currentState.Execute(); // ���ŵ� ���� ����
        Current = newStateType;
        _isStateChanged = true;
        return true;
    }
}
