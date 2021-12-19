using UnityEngine;

public class UICharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] Character _characterPrefab;

    public Character CharacterPrefab { get { return _characterPrefab; } }
}
