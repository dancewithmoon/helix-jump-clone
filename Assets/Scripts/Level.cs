using System;
using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private TowerBuilder _towerPrefab;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private BallTracking _trackingPrefab;

    private Tower _buildedTower;
    private Ball _spawnedBall;

    public event Action Passed;
    public event Action Lost;

    private void Awake()
    {
        StartCoroutine(GenerateLevel());
    }

    private IEnumerator GenerateLevel()
    {
        TowerBuilder builder = Instantiate(_towerPrefab, transform);
        yield return StartCoroutine(builder.Build());

        _buildedTower = builder.BuildedTower;
        _spawnedBall = Instantiate(_ballPrefab, _buildedTower.StartPlatform.SpawnPoint, Quaternion.identity, transform);
        yield return null;

        BallTracking tracking = Instantiate(_trackingPrefab, transform);
        tracking.Init(_spawnedBall, _buildedTower.Beam);
        
        SubscribeOnEvents();
    }

    private void SubscribeOnEvents()
    {
        _buildedTower.FinishPlatform.Touched += Pass;
        _spawnedBall.GetComponent<BallWrongBehaviour>().Lose += Lose;
    }

    private void Lose()
    {
        PauseLevel();
        Lost?.Invoke();
    }

    private void Pass()
    {
        PauseLevel();
        Passed?.Invoke();
    }

    private void PauseLevel()
    {
        _spawnedBall.GetComponent<Rigidbody>().isKinematic = true;
        _buildedTower.Beam.GetComponentInParent<Rigidbody>().isKinematic = true;
    }

    private void OnDestroy()
    {
        Passed = null;
        Lost = null;
    }
}
