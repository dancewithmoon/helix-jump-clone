using System;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour, IControllable
{
    [SerializeField] private Level[] _levels;
    private Level _currentLevel;
    private int _currentLevelId = 0;
    private bool IsLastLevel => _currentLevelId == _levels.Length;

    public event Action<Level> LevelStarted;

    private void Start()
    {
        StartLevel(_currentLevelId);
    }

    public void StartNextLevel()
    {
        _currentLevelId++;
        if (IsLastLevel == true)
        {
            _currentLevelId = 0;
        }
        StartLevel(_currentLevelId);
    }


    public void RestartCurrentLevel()
    {
        StartLevel(_currentLevelId);
    }

    private void StartLevel(int levelId)
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levels[levelId]);
        LevelStarted?.Invoke(_currentLevel);
        _currentLevel.Generate();
    }

    private void OnDestroy()
    {
        LevelStarted = null;
    }
}
