using System;
using UnityEngine;

public class FinishPlatform : Platform
{
    public event Action Touched;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            Touched?.Invoke();
        }
    }
}
