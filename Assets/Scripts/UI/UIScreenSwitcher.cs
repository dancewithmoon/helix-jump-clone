using System.Collections.Generic;
using UnityEngine;

public enum UIScreenName
{
    LoseScreen
}

public class UIScreenSwitcher : MonoBehaviour
{
    [SerializeField] private UIScreensContainer _screensContainer;

    private readonly Dictionary<UIScreenName, UIView> _uiScreens = new Dictionary<UIScreenName, UIView>();
    private readonly Dictionary<UIScreenName, UIView> _loaded = new Dictionary<UIScreenName, UIView>();

    private void Awake()
    {
        _uiScreens.Add(UIScreenName.LoseScreen, _screensContainer.UILoseScreen);
    }

    public void ShowScreen(UIScreenName screenName, IControllable controllable)
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
