using System;

public static class UIScreenEvents
{
    public static event Action<UIScreenName, IControllable> ShowScreenEvent;
    public static event Action<UIScreenName> HideScreenEvent;

    public static void ShowScreen(UIScreenName screenName, IControllable controllable)
    {
        ShowScreenEvent?.Invoke(screenName, controllable);
    }

    public static void HideScreen(UIScreenName screenName)
    {
        HideScreenEvent?.Invoke(screenName);
    }
}
