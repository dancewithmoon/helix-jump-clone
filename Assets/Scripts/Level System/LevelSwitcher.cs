using UnityEngine;

public class LevelSwitcher : MonoBehaviour, IControllable
{
    [SerializeField] private Level[] _levels;
    private Level _currentLevel;
    private int _currentLevelId = 0;

    private void Awake()
    {
        StartLevel(_currentLevelId);
    }

    public void StartNextLevel()
    {
        UIScreenEvents.HideScreen(UIScreenName.WinScreen);
        _currentLevelId++;
        StartLevel(_currentLevelId);
    }

    public void RestartCurrentLevel()
    {
        UIScreenEvents.HideScreen(UIScreenName.LoseScreen);
        StartLevel(_currentLevelId);
    }

    private void LevelLost()
    {
        UIScreenEvents.ShowScreen(UIScreenName.LoseScreen, this);
    }

    private void LevelPassed()
    {
        UIScreenEvents.ShowScreen(UIScreenName.WinScreen, this);
    }

    private void StartLevel(int levelId)
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levels[levelId]);
        _currentLevel.Passed += LevelPassed;
        _currentLevel.Lost += LevelLost;
    }
}
