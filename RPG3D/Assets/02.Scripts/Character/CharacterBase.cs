using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IDamageable
{
    protected CharacterStateMachine machine;

    public event Action<float> OnHpChanged;
    public event Action OnHpMin;
    public event Action OnHpMax;

    public float hp
    {
        get => _hp;
        set
        {
            if (value < hpMin)
                value = hpMin;
            else if (value > hpMax)
                value = hpMax;

            _hp = value;

            if (_hp <= hpMin) OnHpMin?.Invoke();
            else if (_hp >= hpMax) OnHpMax?.Invoke();
            OnHpChanged?.Invoke(_hp);
        }
    }

    public float hpMin => _hpMin;

    public float hpMax => _hpMax;

    private float _hp;
    [SerializeField] private float _hpMin = 0.0f;
    [SerializeField] private float _hpMax = 100.0f;

    protected abstract CharacterStateMachine InitMachine();
    protected abstract void UpdateMachine();

    protected virtual void Awake()
    {
        machine = InitMachine();
    }

    protected virtual void Start()
    {
        hp = hpMax;
    }

    protected virtual void Update()
    {
        UpdateMachine();
    }

    public void Damage(float amount)
    {
        hp -= amount;
    }
}
