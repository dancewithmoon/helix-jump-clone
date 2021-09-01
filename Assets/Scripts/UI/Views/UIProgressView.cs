using UnityEngine;

public class UIProgressView : UIView
{
    [SerializeField] private UIProgressBar _progressBar;
    private LevelProgressModel _progress;
    private int _totalPlatformsCount;

    public override void Load(IControllable controllable)
    {
        _progress = controllable as LevelProgressModel;
        _totalPlatformsCount = _progress.PlatformCount;
        _progress.PlatformPassed += UpdateProgress;
    }

    private void OnEnable()
    {
        if (_progress != null)
        {
            _progress.PlatformPassed += UpdateProgress;
        }
    }

    private void UpdateProgress(int passedPlatforms)
    {
        _progressBar.UpdateProgress((float)passedPlatforms / (_totalPlatformsCount - 1));
    }

    private void OnDisable()
    {
        _progress.PlatformPassed -= UpdateProgress;
    }
}
