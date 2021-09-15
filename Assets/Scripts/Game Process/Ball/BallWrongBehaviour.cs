using System;
using UnityEngine;

public class BallWrongBehaviour : MonoBehaviour
{
    public event Action Lose;
    public void TouchWrong()
    {
        if (enabled == true)
        {
            Lose?.Invoke();
        }
    }
}
