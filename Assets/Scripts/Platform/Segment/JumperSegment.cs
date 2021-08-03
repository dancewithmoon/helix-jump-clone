using UnityEngine;

public class JumperSegment : PlatformSegment
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BallJumpBehaviour jumper))
        {
            jumper.Jump();
        }
    }
}
