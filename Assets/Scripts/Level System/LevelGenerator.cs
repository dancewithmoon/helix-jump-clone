using System;
using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private TowerSettings _towerSettings;

    [Header("Prefabs")]
    [SerializeField] private TowerBuilder _towerPrefab;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private BallTracking _trackingPrefab;

    public Tower BuildedTower { get; private set; }
    public Ball SpawnedBall { get; private set; }

    public event Action<LevelProgressModel> LevelGenerated;

    public void Generate()
    {
        StartCoroutine(GenerateLevel());
    }

    private IEnumerator GenerateLevel()
    {
        TowerBuilder builder = Instantiate(_towerPrefab, transform);
        yield return StartCoroutine(builder.Build(_towerSettings));

        BuildedTower = builder.Tower;
        SpawnedBall = Instantiate(_ballPrefab, BuildedTower.StartPlatform.SpawnPoint, Quaternion.identity, transform);
        yield return null;

        BallTracking tracking = Instantiate(_trackingPrefab, transform);
        tracking.Init(SpawnedBall, BuildedTower.Beam);

        LevelGenerated?.Invoke(new LevelProgressModel(BuildedTower, SpawnedBall.GetComponent<BallPassedPlatformsCounter>()));
    }

    private void OnDestroy()
    {
        LevelGenerated = null;
    }
}
