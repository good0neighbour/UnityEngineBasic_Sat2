using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitType
{
    Bad,
    Miss,
    Good,
    Great,
    Cool
}
public class Note : MonoBehaviour
{
    public KeyCode Key;

    public void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.Bad:
                break;
            case HitType.Miss:
                break;
            case HitType.Good:
                break;
            case HitType.Great:
                break;
            case HitType.Cool:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.down * Time.fixedDeltaTime);
    }
}
