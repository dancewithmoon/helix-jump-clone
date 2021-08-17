using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 500;
    [SerializeField] private float _bounceRadius = 100;

    private Platform _platform;

    private void Awake()
    {
        _platform = GetComponent<Platform>();
    }

    private void OnEnable()
    {
        _platform.Passed += Break;
    }

    private void OnDisable()
    {
        _platform.Passed -= Break;
    }

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach (PlatformSegment segment in segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
