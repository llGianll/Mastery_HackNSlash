using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacterSelectionMenu : MonoBehaviour
{
    [SerializeField] UICharacterSelectionPanel _leftPanel;
    [SerializeField] UICharacterSelectionPanel _rightPanel;

    [SerializeField] TextMeshProUGUI _startGameText;
    UICharacterSelectionMarker[] _markers;

    public UICharacterSelectionPanel LeftPanel { get { return _leftPanel; } }
    public UICharacterSelectionPanel RightPanel { get { return _rightPanel; } }

    private void Awake()
    {
        _markers = GetComponentsInChildren<UICharacterSelectionMarker>();
    }

    private void Update()
    {
        int playerCount = 0;
        int lockedCount = 0;

        foreach (var marker in _markers)
        {
            if (marker.IsPlayerIn)
                playerCount++;

            if (marker.IsLockedIn)
                lockedCount++;
        }

        bool startEnabled = playerCount > 0 && playerCount == lockedCount;
        _startGameText.gameObject.SetActive(startEnabled);
    }
}
