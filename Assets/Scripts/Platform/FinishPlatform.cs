using System;
using UnityEngine;

public class FinishPlatform : Platform
{
    private bool _isTouched = false;

    public event Action Touched;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball) && _isTouched == false)
        {
            _isTouched = true;
            Touched?.Invoke();
        }
    }
}
