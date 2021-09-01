using System;
using UnityEngine;

public class LevelProgressModel : IControllable 
{
    public int PlatformCount { get; private set; }

    public event Action<int> PlatformPassed;

    public LevelProgressModel(Tower tower, BallPassedPlatformsCounter platformsCounter)
    {
        if(platformsCounter == null)
        {
            Debug.LogError($"{nameof(BallPassedPlatformsCounter)} is null");
        }

        PlatformCount = tower.PlatformsCount;
        platformsCounter.PlatformPassed += InvokePlatformPassed;
    }

    private void InvokePlatformPassed(int passedCount)
    {
        PlatformPassed?.Invoke(passedCount);
    }
}
