using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Each Controller gameobject is attached to the Input Setting Axis through the _attackButton string
    string _attackButton;
    public bool _attack;

    public int Index { get; private set; }
    public bool IsAssigned { get; set; }

    private void Update()
    {
        if(!string.IsNullOrEmpty(_attackButton))
            _attack = Input.GetButton(_attackButton);
    }

    public void SetIndex(int index)
    {
        Index = index;
        gameObject.name = "Controller " + Index;
        _attackButton = "Attack" + Index;
    }

    public bool AnyButtonDown()
    {
        return _attack;
    }
}
