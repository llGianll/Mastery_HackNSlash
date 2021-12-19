using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Each Controller gameobject is attached to the Input Setting Axis through the _attackButton string
    string _attackButton;
    string _horizontalAxis;
    string _verticalAxis;

    public bool attack;
    public float horizontal;
    public float vertical;

    public bool attackPressed;

    public int Index { get; private set; }
    public bool IsAssigned { get; set; }

    private void Update()
    {
        if (!string.IsNullOrEmpty(_attackButton))
        {
            attack = Input.GetButton(_attackButton);
            attackPressed = Input.GetButtonDown(_attackButton);
            horizontal = Input.GetAxis(_horizontalAxis);
            vertical = Input.GetAxis(_verticalAxis);
        }
    }

    public void SetIndex(int index)
    {
        Index = index;
        
        _attackButton = "Attack" + Index;
        _horizontalAxis = "Horizontal" + Index;
        _verticalAxis = "Vertical" + Index;

        gameObject.name = "Controller " + Index;
    }

    public bool AnyButtonDown()
    {
        return attack;
    }

    public Vector3 GetDirection()
    {
        return new Vector3(horizontal, 0, vertical);
    }
}
