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
        Instantiate(_screenSwitcher);
        Instantiate(_levelSwitcher);
    }
}
