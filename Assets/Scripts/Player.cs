using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _playerNumber;

    public Controller Controller { get; private set; }
    UIPlayerText _uiPlayerText;

    public bool HasController { get { return Controller != null; } }
    public int PlayerNumber { get { return _playerNumber; } }

    private void Awake()
    {
        _uiPlayerText = GetComponentInChildren<UIPlayerText>();
    }

    public void InitializePlayer(Controller controller)
    {
        Controller = controller;

        gameObject.name = string.Format("Player {0} - {1}", PlayerNumber, controller.gameObject.name);

        _uiPlayerText.HandlePlayerInitialized();
    }
}
