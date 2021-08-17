using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private float swipeSpeed;

    public event Action<float> Swiped;

    public void OnDrag(PointerEventData eventData)
    {
        Swiped?.Invoke(eventData.delta.x * Time.deltaTime * swipeSpeed);
    }
}
