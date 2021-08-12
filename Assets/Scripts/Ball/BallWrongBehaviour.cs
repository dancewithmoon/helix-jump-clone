using System;
using UnityEngine;

public class BallWrongBehaviour : MonoBehaviour
{
    public event Action Lose;
    public void TouchWrong()
    {
        Lose?.Invoke();
    }
}
