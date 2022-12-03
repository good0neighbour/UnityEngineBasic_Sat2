using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public TowerInfo Info;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float _detectRange;
    [SerializeField] protected LayerMask TargetLayer;
    protected Transform Target;

    private void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _detectRange, TargetLayer);

        if (cols.Length > 0)
        {
            Target = cols[0].transform;
            _rotationPoint.LookAt(Target);
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
    }
}
