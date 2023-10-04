using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    public List<SpawnPoint> SpawnPoints { get => _spawnPoints; }
}