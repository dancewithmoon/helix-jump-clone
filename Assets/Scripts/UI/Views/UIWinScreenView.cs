using UnityEngine;
using UnityEngine.UI;

public class UIWinScreenView : UIView
{
    [SerializeField] private Button _nextLevel;
    private LevelSwitcher _levelSwitcher;

    public override void Load(IControllable controllable)
    {
        _levelSwitcher = controllable as LevelSwitcher;
        _nextLevel.onClick.AddListener(_levelSwitcher.StartNextLevel);
    }

    private void OnEnable()
    {
        if (_levelSwitcher)
        {
            _nextLevel.onClick.AddListener(_levelSwitcher.StartNextLevel);
        }
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveAllListeners();
    }

}
