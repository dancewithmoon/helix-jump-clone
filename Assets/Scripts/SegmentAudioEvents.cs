using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlatformSegment))]
public class SegmentAudioEvents : MonoBehaviour
{
    public UnityEvent Touched;
    public UnityEvent Triggered;

    private PlatformSegment _segment;

    private void Awake()
    {
        _segment = GetComponent<PlatformSegment>();
    }

    private void OnEnable()
    {
        _segment.BallTouched += InvokeTouchEvent;
        _segment.BallTriggered += InvokeTriggeredEvent;
    }

    private void InvokeTouchEvent(Ball ball)
    {
        Touched?.Invoke();
    }

    private void InvokeTriggeredEvent(Ball ball)
    {
        Triggered?.Invoke();
    }

    private void OnDisable()
    {
        _segment.BallTouched -= InvokeTouchEvent;
        _segment.BallTriggered -= InvokeTriggeredEvent;
    }
}
