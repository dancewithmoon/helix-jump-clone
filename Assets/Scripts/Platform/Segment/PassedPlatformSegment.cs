using UnityEngine;

public class PassedPlatformSegment : PlatformSegment
{
    private void OnEnable()
    {
        BallTriggered += PassPlatform;
    }

    private void PassPlatform(Ball ball)
    {
        if (ball.TryGetComponent(out BallPassedPlatformsCounter passedCounter))
        {
            passedCounter.PassPlatform();
            GetComponentInParent<Platform>().Pass();
        }
    }

    private void OnDisable()
    {
        BallTriggered -= PassPlatform;
    }
}
