using System;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
public class Level : MonoBehaviour
{
    public LevelGenerator Generator { get; private set; }

    public event Action Passed;
    public event Action Lost;

    private void Awake()
    {
        Generator = GetComponent<LevelGenerator>();
    }

    private void OnEnable()
    {
        Generator.LevelGenerated += SubscribeEvents;
    }

    private void SubscribeEvents(LevelProgressModel progressModel)
    {
        Generator.BuildedTower.FinishPlatform.Touched += Pass;
        Generator.SpawnedBall.GetComponent<BallWrongBehaviour>().Lose += Lose;
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
        Generator.SpawnedBall.Pause();
        Generator.BuildedTower.Pause();
    }

    private void OnDestroy()
    {
        Passed = null;
        Lost = null;
    }
}
