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

    private void Awake()
    {
        _menu = GetComponentInParent<UICharacterSelectionMenu>();
        _markerImage.gameObject.SetActive(false);
        _lockImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_player.HasController == false)
            return;

        if (!_initializing)
            StartCoroutine(Initialize());

        if (!_initialized)
            return;

        //Check for player controls and selection + locking character
    }

    private IEnumerator Initialize()
    {
        _initializing = true;
        yield return new WaitForSeconds(0.5f);
        _markerImage.gameObject.SetActive(true);
        _initialized = true;
    }
}
