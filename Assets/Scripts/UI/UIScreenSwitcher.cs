using System.Collections.Generic;
using UnityEngine;

public enum UIScreenName
{
    LoseScreen,
    WinScreen,
    ProgressHUD
}

public class UIScreenSwitcher : MonoBehaviour
{
    [SerializeField] private UIScreensContainer _screensContainer;

    private readonly Dictionary<UIScreenName, UIView> _uiScreens = new Dictionary<UIScreenName, UIView>();
    private readonly Dictionary<UIScreenName, UIView> _loaded = new Dictionary<UIScreenName, UIView>();

    private void Awake()
    {
        _uiScreens.Add(UIScreenName.LoseScreen, _screensContainer.UILoseScreen);
        _uiScreens.Add(UIScreenName.WinScreen, _screensContainer.UIWinScreen);
        _uiScreens.Add(UIScreenName.ProgressHUD, _screensContainer.UIProgressView);
    }

    public void ShowScreen(UIScreenName screenName, IControllable controllable)
    {
        if (IsScreenInstanceExists(screenName))
            ShowExistingScreenInstance(screenName);
        else
            CreateNewScreenInstance(screenName, controllable);
    }

    private bool IsScreenInstanceExists(UIScreenName screenName)
    {
        return _loaded.ContainsKey(screenName);
    }

    private void ShowExistingScreenInstance(UIScreenName screenName)
    {
        _loaded[screenName].gameObject.SetActive(true);
    }

    private void CreateNewScreenInstance(UIScreenName screenName, IControllable controllable)
    {
        UIView view = Instantiate(_uiScreens[screenName]);
        view.Load(controllable);
        _loaded.Add(screenName, view);
    }

    public void HideScreen(UIScreenName screenName)
    {
        UIView view = _loaded[screenName];
        if (view != null)
        {
            Destroy(view.gameObject);
            _loaded.Remove(screenName);
        }
    }
}
