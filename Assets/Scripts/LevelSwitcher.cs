using UnityEngine;

public class LevelSwitcher : MonoBehaviour, IControllable
{
    [SerializeField] private UIScreenSwitcher _screenSwitcher;
    [SerializeField] private Level[] _levels;
    private Level _currentLevel;
    private int _currentLevelId = 0;

    private void Awake()
    {
        StartLevel(_currentLevelId);
    }

    public void StartNextLevel()
    {
        _currentLevelId++;
        StartLevel(_currentLevelId);
    }

    public void RestartCurrentLevel()
    {
        _screenSwitcher.HideScreen(UIScreenName.LoseScreen);
        StartLevel(_currentLevelId);
    }

    private void LevelLost()
    {
        _screenSwitcher.ShowScreen(UIScreenName.LoseScreen, this);
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

    private void LevelPassed()
    {
    }

}
