using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessStar : MonoBehaviour
{
    [SerializeField] private Animation _anim;

    public void Show()
    {
        _anim.Play();
    }
}
