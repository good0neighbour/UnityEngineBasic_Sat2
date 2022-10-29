using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private static Dictionary<KeyCode, Func<bool>> _keyDownActions = new Dictionary<KeyCode, Func<bool>>();
    private static Dictionary<KeyCode, Func<bool>> _keyPressActions = new Dictionary<KeyCode, Func<bool>>();

    public static void ResigterKeyDownAction(KeyCode keyCode, Func<bool> action)
    {
        if (_keyDownActions.ContainsKey(keyCode))
        {
            _keyDownActions[keyCode] += action;
        }
        else
        {
            _keyDownActions.Add(keyCode, action);
        }
    }

    public static void ResigterKeyPressAction(KeyCode keyCode, Func<bool> action)
    {
        if (_keyPressActions.ContainsKey(keyCode))
        {
            _keyPressActions[keyCode] += action;
        }
        else
        {
            _keyPressActions.Add(keyCode, action);
        }
    }

    private void Update()
    {
        foreach (KeyValuePair<KeyCode, Func<bool>> pair in _keyDownActions)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                if (pair.Value.Invoke())
                    return;
            }
        }

        foreach (KeyValuePair<KeyCode, Func<bool>> pair in _keyPressActions)
        {
            if (Input.GetKey(pair.Key))
            {
                if (pair.Value.Invoke())
                    return;
            }
        }
    }
}
