using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        Instantiate(_ballPrefab, _spawnPoint.position, Quaternion.identity);
    }
}
