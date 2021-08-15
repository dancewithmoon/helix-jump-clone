﻿using UnityEngine;

[RequireComponent(typeof(BallPassedPlatformsCounter), typeof(BallWrongBehaviour))]
public class BallPlatformBreakBehaviour : MonoBehaviour
{
    [SerializeField] private int _needPassToBreakPlatform;
    private BallPassedPlatformsCounter _passedPlatformsCounter;
    private BallWrongBehaviour _ballWrongBehaviour;
    private int _passedPlatformsFromLastTouch = 0;

    private bool CanBreakPlatform => _passedPlatformsFromLastTouch > _needPassToBreakPlatform;

    private void Awake()
    {
        _passedPlatformsCounter = GetComponent<BallPassedPlatformsCounter>();
        _ballWrongBehaviour = GetComponent<BallWrongBehaviour>();
    }

    private void OnEnable()
    {
        _passedPlatformsCounter.PlatformPassed += OnPlatformPassed;
    }

    private void OnPlatformPassed(int passedCount)
    {
        _passedPlatformsFromLastTouch++;
        if(CanBreakPlatform)
        {
            _ballWrongBehaviour.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BreakablePlatform platform = collision.gameObject.GetComponentInParent<BreakablePlatform>();
        if (platform != null)
        {
            if(CanBreakPlatform)
            {
                platform.Break();
            }
            _ballWrongBehaviour.enabled = true;
            _passedPlatformsFromLastTouch = 0;
        }
    }

    private void OnDisable()
    {
        _passedPlatformsCounter.PlatformPassed -= OnPlatformPassed;
    }
}