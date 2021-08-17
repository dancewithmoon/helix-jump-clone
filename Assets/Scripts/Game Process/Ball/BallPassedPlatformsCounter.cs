using System;
using UnityEngine;

public class BallPassedPlatformsCounter : MonoBehaviour
{
    private int _passedPlatforms = 0;

    public event Action<int> PlatformPassed;

    public void PassPlatform()
    {
        _passedPlatforms++;
        PlatformPassed?.Invoke(_passedPlatforms);
    }
}
