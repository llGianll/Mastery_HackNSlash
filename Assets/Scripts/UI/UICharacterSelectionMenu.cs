using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterSelectionMenu : MonoBehaviour
{
    [SerializeField] UICharacterSelectionPanel _leftPanel;
    [SerializeField] UICharacterSelectionPanel _rightPanel;

    public UICharacterSelectionPanel LeftPanel { get { return _leftPanel; } }
    public UICharacterSelectionPanel RightPanel { get { return _rightPanel; } }
}
