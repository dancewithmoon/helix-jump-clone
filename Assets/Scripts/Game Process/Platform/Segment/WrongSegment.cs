using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WrongSegment : PlatformSegment
{
    private Collider _self;

    private void Awake()
    {
        _self = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        BallTouched += Touch;
    }

    private void Touch(Ball ball)
    {
        if (ball.TryGetComponent(out BallWrongBehaviour wrong))
        {
            wrong.TouchWrong();
            _self.enabled = false;
        }
    }

    private void OnDisable()
    {
        BallTouched -= Touch;
    }
}
