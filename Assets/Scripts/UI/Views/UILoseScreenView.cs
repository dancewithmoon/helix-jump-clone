using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UILoseScreenView : UIView
{
    [SerializeField] private Button _restart;
    private LevelSwitcher _levelSwitcher;

    public override void Load(IControllable controllable)
    {
        _levelSwitcher = controllable as LevelSwitcher;
        _restart.onClick.AddListener(_levelSwitcher.RestartCurrentLevel);
    }

    private void OnEnable()
    {
        if (_levelSwitcher != null)
        {
            _restart.onClick.AddListener(_levelSwitcher.RestartCurrentLevel);
        }
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveAllListeners();
    }
}
