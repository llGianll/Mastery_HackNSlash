using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelectionMarker : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Image _markerImage;
    [SerializeField] Image _lockImage;
    
    UICharacterSelectionMenu _menu;
    bool _initializing;
    private bool _initialized;

    public bool IsLockedIn { get; private set; }
    public bool IsPlayerIn { get { return _player.HasController; } }

    private void Awake()
    {
        _menu = GetComponentInParent<UICharacterSelectionMenu>();
        _markerImage.gameObject.SetActive(false);
        _lockImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (IsPlayerIn == false)
            return;

        if (!_initializing)
            StartCoroutine(Initialize());

        if (!_initialized)
            return;

        //Check for player controls and selection + locking character
        if (!IsLockedIn)
        {
            if (_player.Controller.horizontal > 0.5f)
            {
                MoveToCharacterPanel(_menu.RightPanel);
            }
            else if (_player.Controller.horizontal < -0.5f)
            {
                MoveToCharacterPanel(_menu.LeftPanel);
            }

            if (_player.Controller.attackPressed)
            {
                LockCharacter();
            }
        }
        else
        {
            if (_player.Controller.attackPressed)
            {
                _menu.TryStartGame();
            }
        }
    }

    private void LockCharacter()
    {
        IsLockedIn = true;
        _lockImage.gameObject.SetActive(true);
    }

    private void MoveToCharacterPanel(UICharacterSelectionPanel panel)
    {
        transform.position = panel.transform.position;
    }

    private IEnumerator Initialize()
    {
        _initializing = true;
        MoveToCharacterPanel(_menu.LeftPanel);
        yield return new WaitForSeconds(0.5f);
        _markerImage.gameObject.SetActive(true);
        _initialized = true;
    }
}
