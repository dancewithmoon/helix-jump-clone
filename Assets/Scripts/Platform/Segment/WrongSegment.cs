using UnityEngine;

public class WrongSegment : PlatformSegment
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BallWrongBehaviour wrong))
        {
            wrong.TouchWrong();
        }
    }
}
