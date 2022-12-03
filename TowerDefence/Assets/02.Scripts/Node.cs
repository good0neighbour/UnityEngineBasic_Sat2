using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool IsTowerExist => _towerBuilt;
    private Tower _towerBuilt;
    private Renderer _renderer;
    private Material _matOrigin;
    [SerializeField] private Material _buildAvailableMat;
    [SerializeField] private Material _buildNotAvailableMat;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _matOrigin = _renderer.sharedMaterial;
    }

    private void OnMouseEnter()
    {
        if (IsTowerExist)
            _renderer.material = _buildNotAvailableMat;
        else
            _renderer.material = _buildAvailableMat;
    }

    private void OnMouseExit()
    {
        _renderer.material = _matOrigin;
    }
}
