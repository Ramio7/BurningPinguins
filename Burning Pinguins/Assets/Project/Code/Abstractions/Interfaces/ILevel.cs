using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    public List<SpawnPoint> SpawnPoints { get; }
    public Transform BallStartingPoint { get; }
}
