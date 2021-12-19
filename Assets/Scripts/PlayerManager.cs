using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player[] _players;
    public static PlayerManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        _players = FindObjectsOfType<Player>();
    }

    public void AddPlayerToGame(Controller controller)
    {
        var firstNonActivePlayer = _players
            .OrderBy(t => t.PlayerNumber)
            .FirstOrDefault(t => t.HasController == false);
        firstNonActivePlayer.InitializePlayer(controller);
    }

    public void SpawnPlayerCharacters()
    {
        foreach (var player in _players)
        {
            if (player.HasController && player.CharacterPrefab != null)
                player.SpawnCharacter();
        }
    }
}
