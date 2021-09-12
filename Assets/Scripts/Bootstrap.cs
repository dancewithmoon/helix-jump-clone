using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelSwitcher _levelSwitcher;
    [SerializeField] private UIScreenSwitcher _screenSwitcher;
    [SerializeField] private Canvas _swipeInputCanvas;

    private void Start()
    {
        Instantiate(_swipeInputCanvas);
        UIScreenSwitcher screenSwitcher = Instantiate(_screenSwitcher);

        LevelSwitcher levelSwitcher = Instantiate(_levelSwitcher);
        levelSwitcher.NextLevelStarted += () =>
        {
            screenSwitcher.HideScreen(UIScreenName.WinScreen);
            screenSwitcher.HideScreen(UIScreenName.ProgressHUD);
        };
        levelSwitcher.CurrentLevelRestarted += () =>
        {
            screenSwitcher.HideScreen(UIScreenName.LoseScreen);
            screenSwitcher.HideScreen(UIScreenName.ProgressHUD);
        };
        levelSwitcher.LevelLost += () => screenSwitcher.ShowScreen(UIScreenName.LoseScreen, levelSwitcher);
        levelSwitcher.LevelPassed += () => screenSwitcher.ShowScreen(UIScreenName.WinScreen, levelSwitcher);
        levelSwitcher.LevelGenerated += (LevelProgressModel progressModel) => screenSwitcher.ShowScreen(UIScreenName.ProgressHUD, progressModel);
    }
}
