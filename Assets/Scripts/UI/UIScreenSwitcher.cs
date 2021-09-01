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

    private void OnEnable()
    {
        UIScreenEvents.ShowScreenEvent += ShowScreen;
        UIScreenEvents.HideScreenEvent += HideScreen;
    }

    public void ShowScreen(UIScreenName screenName, IControllable controllable)
    {
        if (_loaded.ContainsKey(screenName))
        {
            _loaded[screenName].gameObject.SetActive(true);
        }
        else
        {
            UIView view = Instantiate(_uiScreens[screenName]);
            view.Load(controllable);
            _loaded.Add(screenName, view);
        }
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

    private void OnDisable()
    {
        UIScreenEvents.ShowScreenEvent -= ShowScreen;
        UIScreenEvents.HideScreenEvent -= HideScreen;
    }
}
