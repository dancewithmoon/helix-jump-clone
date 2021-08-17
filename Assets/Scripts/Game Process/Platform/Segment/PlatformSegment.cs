using System;
using UnityEngine;

public class PlatformSegment : MonoBehaviour
{
    public event Action<Ball> BallTouched;
    public event Action<Ball> BallTriggered;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            BallTouched?.Invoke(ball);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            BallTriggered?.Invoke(ball);
        }
    }

    public void Bounce(float force, Vector3 center, float radius)
    {
        if(TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, center, radius);
        }
    }
}
