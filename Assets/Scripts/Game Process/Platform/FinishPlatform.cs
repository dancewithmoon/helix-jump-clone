using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinishPlatform : Platform
{
    private List<PlatformSegment> _segments;

    public event Action Touched;


    private void Awake()
    {
        _segments = GetComponentsInChildren<PlatformSegment>().ToList();
    }

    private void OnEnable()
    {
        _segments.ForEach((segment) => segment.BallTouched += Finish);
    }

    private void Finish(Ball ball)
    {
        _segments.ForEach((segment) => segment.enabled = false);
        Touched?.Invoke();
    }

    private void OnDisable()
    {
        _segments.ForEach((segment) => segment.BallTouched -= Finish);
    }
}
