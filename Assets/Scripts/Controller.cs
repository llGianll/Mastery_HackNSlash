using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    string _attackButton;
    public bool _attack;

    public int Index;

    private void Start()
    {
        //Index = 1;
        _attackButton = "Attack" + Index;
    }

    private void Update()
    {
        _attack = Input.GetButton(_attackButton);
    }
}
