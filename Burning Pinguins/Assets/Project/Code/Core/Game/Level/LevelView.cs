using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour, ILevel
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Transform _ballStartingPoint;

    public List<SpawnPoint> SpawnPoints { get => _spawnPoints; }
    public Transform BallStartingPoint { get => _ballStartingPoint; }
}