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
        levelSwitcher.LevelStarted += (Level level) =>
        {
            screenSwitcher.HideAllScreens();
            level.Generator.LevelGenerated += (levelProgress) => screenSwitcher.ShowScreen(UIScreenName.ProgressHUD, levelProgress);
            level.Lost += () => screenSwitcher.ShowScreen(UIScreenName.LoseScreen, levelSwitcher);
            level.Passed += () => screenSwitcher.ShowScreen(UIScreenName.WinScreen, levelSwitcher);
        };
    }
}
