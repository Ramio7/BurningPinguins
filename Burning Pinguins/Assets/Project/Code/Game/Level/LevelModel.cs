using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    public Transform GetEmptySpawnPointTransform(List<SpawnPoint> spawnPoints)
    {
        var freeSpawns = new List<SpawnPoint>();
        foreach (var spawnPoint in spawnPoints)
        {
            if (!spawnPoint.IsOccupied) freeSpawns.Add(spawnPoint);
        }
        var index = Random.Range(0, freeSpawns.Count);
        return spawnPoints[index].transform;
    }
}
