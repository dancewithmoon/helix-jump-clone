using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerPrefab;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private BallTracking _trackingPrefab;

    private void Awake()
    {
        StartCoroutine(GenerateLevel());
    }

    private IEnumerator GenerateLevel()
    {
        TowerBuilder builder = Instantiate(_towerPrefab, transform);
        yield return StartCoroutine(builder.Build());

        Tower tower = builder.BuildedTower;
        Ball ball = Instantiate(_ballPrefab, tower.StartPlatform.SpawnPoint, Quaternion.identity, transform);
        yield return null;

        BallTracking tracking = Instantiate(_trackingPrefab, transform);
        tracking.Init(ball, tower.Beam);
    }
}
