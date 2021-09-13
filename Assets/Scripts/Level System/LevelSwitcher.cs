using System;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour, IControllable
{
    [SerializeField] private Level[] _levels;
    private Level _currentLevel;
    private int _currentLevelId = 0;
    private bool IsLastLevel => _currentLevelId == _levels.Length;

    public event Action NextLevelStarted;
    public event Action CurrentLevelRestarted;
    public event Action LevelLost;
    public event Action LevelPassed;
    public event Action<LevelProgressModel> LevelGenerated;

    private void Awake()
    {
        StartLevel(_currentLevelId);
    }

    public void StartNextLevel()
    {
        NextLevelStarted?.Invoke();
        _currentLevelId++;
        if (IsLastLevel)
        {
            _currentLevelId = 0;
        }
        StartLevel(_currentLevelId);
    }


    public void RestartCurrentLevel()
    {
        CurrentLevelRestarted?.Invoke();
        StartLevel(_currentLevelId);
    }

    private void StartLevel(int levelId)
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levels[levelId]);
        _currentLevel.Passed += () => LevelPassed?.Invoke();
        _currentLevel.Lost += () => LevelLost?.Invoke();
        _currentLevel.LevelGenerated += (LevelProgressModel progressModel) => LevelGenerated?.Invoke(progressModel);
    }

    private void OnDestroy()
    {
        NextLevelStarted = null;
        CurrentLevelRestarted = null;
        LevelLost = null;
        LevelPassed = null;
        LevelGenerated = null;
    }
}
