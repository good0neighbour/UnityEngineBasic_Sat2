using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _yOffset = 0f;

    private void Update()
    {
        this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _yOffset, -10);
    }
}
