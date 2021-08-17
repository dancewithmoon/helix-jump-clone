using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WrongSegment : PlatformSegment
{
    private Collider _self;

    private void Awake()
    {
        _self = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BallWrongBehaviour wrong))
        {
            wrong.TouchWrong();
            _self.enabled = false;
        }
    }
}
