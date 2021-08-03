﻿using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Transform _spawnPoint;

    public Vector3 SpawnPoint => _spawnPoint.position;
}
