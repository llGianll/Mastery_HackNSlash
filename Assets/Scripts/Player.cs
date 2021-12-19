using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _playerNumber;
    Controller _controller;

    public bool HasController { get { return _controller != null; } }
    public int PlayerNumber { get { return _playerNumber; } }

    public void InitializePlayer(Controller controller)
    {
        _controller = controller;

        gameObject.name = string.Format("Player {0} - {1}", PlayerNumber, controller.gameObject.name);
    }
}
