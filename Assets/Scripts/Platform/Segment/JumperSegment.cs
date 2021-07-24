using UnityEngine;

public class JumperSegment : PlatformSegment
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BallJumper jumper))
        {
            jumper.Jump();
        }
    }
}
