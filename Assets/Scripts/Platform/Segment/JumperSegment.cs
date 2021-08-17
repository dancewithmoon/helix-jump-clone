public class JumperSegment : PlatformSegment
{
    private void OnEnable()
    {
        BallTouched += CallBallJump;
    }

    private void CallBallJump(Ball ball)
    {
        if (ball.TryGetComponent(out BallJumpBehaviour jumper))
        {
            jumper.Jump();
        }
    }

    private void OnDisable()
    {
        BallTouched -= CallBallJump;
    }
}
